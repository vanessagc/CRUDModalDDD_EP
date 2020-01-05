using DomainValidation.Interfaces.Specification;
using EP.CrudModalDDD.Domain.Entities;
using EP.CrudModalDDD.Domain.Validations.Documentos;

namespace EP.CrudModalDDD.Domain.Specifications.Clientes
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPFValidation.Validar(cliente.CPF);
        }
    }
}