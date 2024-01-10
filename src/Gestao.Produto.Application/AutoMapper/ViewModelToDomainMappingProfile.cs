using AutoMapper;
using Gestao.Produto.Application.ViewModels;
using Gestao.Produto.Domain.Commands;

namespace Gestao.Produto.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, CadastrarProdutoCommand>()
                .ConstructUsing(c => new CadastrarProdutoCommand
                (
                    c.Descricao,
                    c.SituacaoProduto,
                    c.DataFabricacao,
                    c.DataValidade,
                    c.CodigoFornecedor
                 ));

            CreateMap<ProdutoViewModel, AlterarProdutoCommand>()
                    .ConstructUsing(c => new AlterarProdutoCommand
                    (
                        c.Codigo,
                        c.Descricao,
                        c.SituacaoProduto,
                        c.DataFabricacao,
                        c.DataValidade,
                        c.CodigoFornecedor
                    ));
        }
    }
}
