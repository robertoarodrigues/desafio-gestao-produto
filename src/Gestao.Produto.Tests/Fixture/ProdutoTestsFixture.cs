using Bogus;
using System;
using Xunit;

namespace Gestao.Produto.Tests.Fixture
{
    [CollectionDefinition(nameof(ProdutoCollection))]
    public class ProdutoCollection : ICollectionFixture<ProdutoTestsFixture>
    { }

    public class ProdutoTestsFixture : IDisposable
    {
        public Domain.Entities.Produto GerarProduto()
        {
            var produto = new Faker<Domain.Entities.Produto>()
            .RuleFor(p => p.Codigo, f => f.IndexFaker)
            .RuleFor(p => p.Descricao, f => f.Commerce.ProductName())
            .RuleFor(p => p.SituacaoProduto, f => true)
            .RuleFor(p => p.DataFabricacao, f => f.Date.Past())
            .RuleFor(p => p.DataValidade, f => f.Date.Future());

            return produto;
        }

        public Domain.Entities.Produto GerarProdutoComDataFabricacaoMaiorQueDataValidade()
        {
            var produto = new Faker<Domain.Entities.Produto>()
            .RuleFor(p => p.Codigo, f => f.IndexFaker)
            .RuleFor(p => p.Descricao, f => f.Commerce.ProductName())
            .RuleFor(p => p.SituacaoProduto, f => true)
            .RuleFor(p => p.DataFabricacao, f => f.Date.Future())
            .RuleFor(p => p.DataValidade, f => f.Date.Past());

            return produto;
        }


        public void Dispose()
        {
        }
    }
}
