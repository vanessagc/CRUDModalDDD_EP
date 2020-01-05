using System;
using EP.CrudModalDDD.Domain.DTO;
using EP.CrudModalDDD.Domain.Entities;

namespace EP.CrudModalDDD.Domain.Interfaces.Service
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente ObterPorId(Guid id);
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        Paged<Cliente> ObterTodos(string nome, int pageSize, int pageNumber);
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);

        Endereco AdicionarEndereco(Endereco endereco);
        Endereco AtualizarEndereco(Endereco endereco);
        Endereco ObterEnderecoPorId(Guid id);
        void RemoverEndereco(Guid id);
    }
}