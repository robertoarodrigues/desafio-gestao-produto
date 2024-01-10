using Gestao.Produto.Core.Communication.Mediator;
using Gestao.Produto.Core.Messages;
using Gestao.Produto.Core.Messages.Notifications;
using Gestao.Produto.Domain.Interface;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gestao.Produto.Domain.Commands
{
    public class ProdutoCommandHandler :
        IRequestHandler<CadastrarProdutoCommand, bool>,
        IRequestHandler<AlterarProdutoCommand, bool>,
        IRequestHandler<RemoverProdutoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public ProdutoCommandHandler(IProdutoRepository produtoRepository, IMediatorHandler mediatorHandler)
        {
            _produtoRepository = produtoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(CadastrarProdutoCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarComando(command)) return false;

            var produto = new Entities.Produto(
                        command.Codigo,
                        command.Descricao,
                        command.SituacaoProduto,
                        command.DataFabricacao,
                        command.DataValidade,
                        command.CodigoFornecedor
                 );

            if (_produtoRepository.RegistroExiste(p => p.Descricao == produto.Descricao).Result.Any())
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("produto", "Já existe registro com esse nome cadastrado."));
                return false;
            }

            await _produtoRepository.Adicionar(produto);

            return true;
        }

        public async Task<bool> Handle(AlterarProdutoCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarComando(command)) return false;

            var produto = new Entities.Produto(
                        command.Codigo,
                        command.Descricao,
                        command.SituacaoProduto,
                        command.DataFabricacao,
                        command.DataValidade,
                        command.CodigoFornecedor
                 );

            if (_produtoRepository.RegistroExiste(p => p.Descricao == produto.Descricao && p.Codigo != produto.Codigo).Result.Any())
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("produto", "Já existe registro com esse nome cadastrado."));
                return false;
            }

            await _produtoRepository.Atualizar(produto);

            return true;
        }

        public async Task<bool> Handle(RemoverProdutoCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarComando(command)) return false;

            var produto = await _produtoRepository.ObterPorCodigo(command.Codigo);

            if (produto is null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("produto", "O registro não existe."));
                return false;
            }

            produto.Desativar();

            await _produtoRepository.Atualizar(produto);

            return true;
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));
            }

            return false;
        }
    }
}
