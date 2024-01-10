using Gestao.Produto.Data.Context;
using Gestao.Produto.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao.Produto.Data.Repository
{
    public class ProdutoRepository : Repository<Domain.Entities.Produto>, IProdutoRepository
    {
        public ProdutoRepository(GestaoProdutoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Entities.Produto>> ObterTodos()
        {
            return await DbSet.Include(t => t.Fornecedor).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Produto>> ObterPorParametro(int pagina, int itensPorPagina, string descricao)
        {
            var query = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(descricao))
            {
                query = query.Where(p => p.Descricao.Contains(descricao));
            }

            int totalItens = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItens / itensPorPagina);

            query = query.Skip((pagina - 1) * itensPorPagina)
                         .Take(itensPorPagina);

            return await query.ToListAsync();
        }
    }
}
