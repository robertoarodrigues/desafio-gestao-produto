using Gestao.Produto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Produto.Data.Context
{
    public class GestaoProdutoContext : DbContext
    {
        public GestaoProdutoContext(DbContextOptions<GestaoProdutoContext> options)
        : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Domain.Entities.Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(GestaoProdutoContext).Assembly);
            base.OnModelCreating(builder);

        }
    }
}
