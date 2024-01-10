using Gestao.Produto.Core.Communication.Mediator;
using Gestao.Produto.Domain.Commands;
using Gestao.Produto.Domain.Interface;
using Gestao.Produto.Tests.Fixture;
using Moq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Gestao.Produto.Tests
{
    [Collection(nameof(ProdutoCollection))]
    public class ProdutoCommandHandlerTests
    {
        readonly ProdutoTestsFixture _fixture;

        public ProdutoCommandHandlerTests(ProdutoTestsFixture produtoTestsFixture)
        {
            _fixture = produtoTestsFixture;
        }

        [Fact(DisplayName = "Adicionar Produto com Sucesso")]
        [Trait("Produto", "Produto Service Mock Tests")]
        public async Task ProdutoService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var produto = _fixture.GerarProduto();
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockMediatorHandler = new Mock<IMediatorHandler>();

            var cadastrarProdutoCommand = new CadastrarProdutoCommand(
                    produto.Descricao,
                    produto.SituacaoProduto,
                    produto.DataFabricacao,
                    produto.DataValidade,
                    produto.CodigoFornecedor
                );

            mockProdutoRepository
                .Setup(repo => repo.RegistroExiste(p => p.Descricao == produto.Descricao))
                .ReturnsAsync(Enumerable.Empty<Domain.Entities.Produto>());

            var cadastrarProdutoHandler = new ProdutoCommandHandler(
                mockProdutoRepository.Object,
                mockMediatorHandler.Object
            );

            // Act
            var resultado = await cadastrarProdutoHandler.Handle(cadastrarProdutoCommand, CancellationToken.None);

            // Assert
            Assert.True(resultado);
        }

        [Fact(DisplayName = "Adicionar Produto com Falha")]
        [Trait("Produto", "Produto Service Mock Tests")]
        public async Task ProdutoService_Adicionar_DeveFalharDevidoProdutoComDataFabriacaoMaiorQueDataValidade()
        {
            // Arrange
            var produto = _fixture.GerarProdutoComDataFabricacaoMaiorQueDataValidade();
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockMediatorHandler = new Mock<IMediatorHandler>();

            var cadastrarProdutoCommand = new CadastrarProdutoCommand(
                    produto.Descricao,
                    produto.SituacaoProduto,
                    produto.DataFabricacao,
                    produto.DataValidade,
                    produto.CodigoFornecedor
                );

            mockProdutoRepository
                .Setup(repo => repo.RegistroExiste(p => p.Descricao == produto.Descricao))
                .ReturnsAsync(Enumerable.Empty<Domain.Entities.Produto>());

            var cadastrarProdutoHandler = new ProdutoCommandHandler(
                mockProdutoRepository.Object,
                mockMediatorHandler.Object
            );

            // Act
            var resultado = await cadastrarProdutoHandler.Handle(cadastrarProdutoCommand, CancellationToken.None);

            // Assert
            Assert.False(resultado);
        }

        [Fact(DisplayName = "Adicionar Produto com Falha")]
        [Trait("Produto", "Produto Service Mock Tests")]
        public async Task ProdutoService_Adicionar_DeveFalharDevidoDescricaoProdutoVazio()
        {
            // Arrange
            var produto = _fixture.GerarProduto();
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockMediatorHandler = new Mock<IMediatorHandler>();

            var cadastrarProdutoCommand = new CadastrarProdutoCommand(
                    string.Empty,
                    produto.SituacaoProduto,
                    produto.DataFabricacao,
                    produto.DataValidade,
                    produto.CodigoFornecedor
                );

            mockProdutoRepository
                .Setup(repo => repo.RegistroExiste(p => p.Descricao == produto.Descricao))
                .ReturnsAsync(Enumerable.Empty<Domain.Entities.Produto>());

            var cadastrarProdutoHandler = new ProdutoCommandHandler(
                mockProdutoRepository.Object,
                mockMediatorHandler.Object
            );

            // Act
            var resultado = await cadastrarProdutoHandler.Handle(cadastrarProdutoCommand, CancellationToken.None);

            // Assert
            Assert.False(resultado);
        }
    }
}
