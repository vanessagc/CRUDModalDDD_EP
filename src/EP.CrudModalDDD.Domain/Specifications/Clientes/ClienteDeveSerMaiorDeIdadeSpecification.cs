using System;
using DomainValidation.Interfaces.Specification;
using EP.CrudModalDDD.Domain.Entities;

namespace EP.CrudModalDDD.Domain.Specifications.Clientes
{
    public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return DateTime.Now.Year - cliente.DataNascimento.Year >= 18;
        }
    }
}