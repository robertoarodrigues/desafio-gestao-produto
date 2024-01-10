using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao.Produto.Domain.Interface
{
    public interface IProdutoRepository : IRepository<Entities.Produto>
    {
        Task<IEnumerable<Domain.Entities.Produto>> ObterPorParametro(int pagina, int itensPorPagina, string descricao);
    }
}
