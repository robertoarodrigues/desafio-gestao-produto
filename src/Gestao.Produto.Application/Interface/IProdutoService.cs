using Gestao.Produto.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao.Produto.Application.Interface
{
    public interface IProdutoService : IDisposable
    {
        Task<ProdutoViewModel> ObterPorCodigo(int codigo);
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
        Task<bool> Adicionar(ProdutoViewModel produtoViewModel);
        Task<bool> Atualizar(ProdutoViewModel produtoViewModel);

        Task<bool> Remover(int codigo);
        Task<IEnumerable<ProdutoViewModel>> ObterPorParametro(int pagina, int itensPorPagina, string descricao);
    }
}
