using EP.CrudModalDDD.Domain.Entities;
using EP.CrudModalDDD.Domain.Interfaces.Repository;
using EP.CrudModalDDD.Infra.Data.Context;

namespace EP.CrudModalDDD.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(CrudModalDDDContext context)
            : base(context)
        {
            
        }
    }
}