using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Dapper;
using EP.CrudModalDDD.Domain.DTO;
using EP.CrudModalDDD.Domain.Entities;
using EP.CrudModalDDD.Domain.Interfaces.Repository;
using EP.CrudModalDDD.Infra.Data.Context;

namespace EP.CrudModalDDD.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {

        public ClienteRepository(CrudModalDDDContext context)
            : base(context)
        {
            
        }

        public Cliente ObterPorCpf(string cpf)
        {
            //return Db.Clientes.FirstOrDefault(c => c.CPF == cpf);
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public Paged<Cliente> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Clientes " +
                      "WHERE (@Nome IS NULL OR Nome LIKE @Nome + '%') " +
                      "ORDER BY [Nome] " +
                      "OFFSET " + pageSize*(pageNumber - 1) + " ROWS " +
                      "FETCH NEXT " + pageSize + " ROWS ONLY " +
                      " " +
                      "SELECT COUNT(ClienteId) FROM Clientes " +
                      "WHERE (@Nome IS NULL OR Nome LIKE @Nome + '%') ";

            var multi = cn.QueryMultiple(sql, new {Nome = nome});
            var clientes = multi.Read<Cliente>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<Cliente>()
            {
                List = clientes,
                Count = total
            };

            return pagedList;
        }

        public override Cliente ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Clientes c " +
                       "LEFT JOIN Enderecos e " +
                       "ON c.ClienteId = e.ClienteId " +
                       "WHERE c.ClienteId = @sid";

            var cliente = new List<Cliente>();
            cn.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) =>
                {
                    cliente.Add(c);
                    if(e != null)
                        cliente[0].Enderecos.Add(e);

                    return cliente.FirstOrDefault();
                }, new { sid = id }, splitOn: "ClienteId, EnderecoId");

            //throw new Exception("MORTE!!!");

            return cliente.FirstOrDefault();
        }
    }
}