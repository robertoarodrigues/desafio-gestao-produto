using AutoMapper;
using Gestao.Produto.Application.Interface;
using Gestao.Produto.Application.ViewModels;
using Gestao.Produto.Domain.Commands;
using Gestao.Produto.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao.Produto.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IMapper mapper, IMediator mediator, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterPorParametro(int pagina, int itensPorPagina, string descricao)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterPorParametro(pagina, itensPorPagina, descricao));
        }

        public async Task<ProdutoViewModel> ObterPorCodigo(int codigo)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorCodigo(codigo));
        }

        public async Task<bool> Adicionar(ProdutoViewModel produtoViewModel)
        {
            var command = _mapper.Map<CadastrarProdutoCommand>(produtoViewModel);
            return await _mediator.Send(command);
        }

        public async Task<bool> Atualizar(ProdutoViewModel produtoViewModel)
        {
            var command = _mapper.Map<AlterarProdutoCommand>(produtoViewModel);
            return await _mediator.Send(command);
        }

        public async Task<bool> Remover(int codigo)
        {
            var command = new RemoverProdutoCommand(codigo);
            return await _mediator.Send(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
