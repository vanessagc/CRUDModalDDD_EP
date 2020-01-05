using DomainValidation.Interfaces.Specification;
using EP.CrudModalDDD.Domain.Entities;
using EP.CrudModalDDD.Domain.Validations.Documentos;

namespace EP.CrudModalDDD.Domain.Specifications.Clientes
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return EmailValidation.Validate(cliente.Email);
        }
    }
}