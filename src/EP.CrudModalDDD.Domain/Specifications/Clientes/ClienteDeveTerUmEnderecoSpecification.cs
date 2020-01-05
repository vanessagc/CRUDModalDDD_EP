using System.Linq;
using DomainValidation.Interfaces.Specification;
using EP.CrudModalDDD.Domain.Entities;

namespace EP.CrudModalDDD.Domain.Specifications.Clientes
{
    public class ClienteDeveTerUmEnderecoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return cliente.Enderecos != null && cliente.Enderecos.Any();
        }
    }
}