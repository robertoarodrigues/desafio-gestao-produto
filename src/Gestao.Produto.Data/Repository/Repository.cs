using Gestao.Produto.Data.Context;
using Gestao.Produto.Domain.Entities;
using Gestao.Produto.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gestao.Produto.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly GestaoProdutoContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(GestaoProdutoContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<TEntity> ObterPorCodigo(int codigo)
        {
            return await DbSet.FindAsync(codigo);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Adicionar(TEntity entidade)
        {
            DbSet.Add(entidade);
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entidade)
        {
            DbSet.Update(entidade);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> RegistroExiste(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
