using Gestao.Produto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Produto.Data.EntityConfiguration
{
    public class FornecedorEntityConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");

            builder.HasKey(e => e.Codigo).HasName("PkFornecedor");

            builder.Property(e => e.Codigo)
                .HasColumnType("int");

            builder.Property(e => e.Descricao)
                .HasColumnType("VARCHAR(250)");

            builder.Property(e => e.Cnpj)
                .HasColumnType("VARCHAR(18)");
        }
    }
}
