using Gestao.Produto.Application.Interface;
using Gestao.Produto.Application.ViewModels;
using Gestao.Produto.Core.Communication.Mediator;
using Gestao.Produto.Core.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao.Produto.Api.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IProdutoService produtoService
        ) : base(notifications, mediatorHandler)
        {
            _produtoService = produtoService;
        }

        [HttpGet("produtos")]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return await _produtoService.ObterTodos();
        }

        [HttpGet("produtos-parâmetro")]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> ObterPorParametro(
                [FromQuery] int pagina = 1,
                [FromQuery] int itensPorPagina = 10,
                [FromQuery] string descricao = ""
            )
        {
            var produtos = await _produtoService.ObterPorParametro(pagina, itensPorPagina, descricao);
            return Ok(produtos);
        }

        [HttpGet("produto/{codigo:int}")]
        public async Task<ProdutoViewModel> ObterPorCodigo(int codigo)
        {
            return await _produtoService.ObterPorCodigo(codigo);
        }

        [HttpPost("produto")]
        public async Task<IActionResult> Inserir([FromBody] ProdutoViewModel produtoViewModel)
        {
            await _produtoService.Adicionar(produtoViewModel);

            if (OperacaoValida()) return Ok(produtoViewModel);

            return BadRequest(ObterMensagensErro());
        }

        [HttpPut("produto")]
        public async Task<IActionResult> Atualizar([FromBody] ProdutoViewModel produtoViewModel)
        {
            await _produtoService.Atualizar(produtoViewModel);

            if (OperacaoValida()) return Ok(produtoViewModel);

            return BadRequest(ObterMensagensErro());
        }

        [HttpDelete("produto")]
        public async Task<IActionResult> Remover(int codigo)
        {
            await _produtoService.Remover(codigo);

            if (OperacaoValida()) return Ok();

            return BadRequest(ObterMensagensErro());
        }
    }
}
