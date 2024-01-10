using AutoMapper;
using Gestao.Produto.Application.ViewModels;

namespace Gestao.Produto.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Entities.Produto, ProdutoViewModel>();
        }
    }
}
