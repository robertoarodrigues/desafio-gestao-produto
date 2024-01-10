using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Produto.Data.EntityConfiguration
{
    public class ProdutoEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.Produto>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(e => e.Codigo).HasName("PkProduto");

            builder.Property(e => e.Codigo)
                .HasColumnType("int");

            builder.Property(e => e.Descricao)
                .HasColumnType("VARCHAR(250)");

            builder.Property(e => e.SituacaoProduto)
                .HasColumnType("bit");

            builder.Property(e => e.DataFabricacao)
                .HasColumnType("datetime");

            builder.Property(e => e.DataValidade)
                .HasColumnType("datetime");

            builder.HasOne(d => d.Fornecedor)
                .WithMany(p => p.Produtos)
                .HasForeignKey(d => d.CodigoFornecedor);
        }
    }
}
