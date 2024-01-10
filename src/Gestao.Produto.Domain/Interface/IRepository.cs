using Gestao.Produto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gestao.Produto.Domain.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entidade);
        Task Atualizar(TEntity entidade);
        Task<TEntity> ObterPorCodigo(int codigo);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task<IEnumerable<TEntity>> RegistroExiste(Expression<Func<TEntity, bool>> predicate);
    }
}
