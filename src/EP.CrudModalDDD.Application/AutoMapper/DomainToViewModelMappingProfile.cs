using AutoMapper;
using EP.CrudModalDDD.Application.ViewModels;
using EP.CrudModalDDD.Domain.DTO;
using EP.CrudModalDDD.Domain.Entities;

namespace EP.CrudModalDDD.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Cliente, ClienteEnderecoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Endereco, ClienteEnderecoViewModel>();
            CreateMap<Paged<Cliente>, PagedViewModel<ClienteViewModel>>();
        }
    }
}