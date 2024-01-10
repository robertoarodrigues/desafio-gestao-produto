﻿// <auto-generated />
using System;
using Gestao.Produto.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gestao.Produto.Data.Migrations
{
    [DbContext(typeof(GestaoProdutoContext))]
    [Migration("20240110124457_InsertData_Fornecedor")]
    partial class InsertData_Fornecedor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gestao.Produto.Domain.Entities.Fornecedor", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .HasColumnType("VARCHAR(18)");

                    b.Property<string>("Descricao")
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("Codigo")
                        .HasName("PkFornecedor");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("Gestao.Produto.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoFornecedor")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFabricacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .HasColumnType("VARCHAR(250)");

                    b.Property<bool>("SituacaoProduto")
                        .HasColumnType("bit");

                    b.HasKey("Codigo")
                        .HasName("PkProduto");

                    b.HasIndex("CodigoFornecedor");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Gestao.Produto.Domain.Entities.Produto", b =>
                {
                    b.HasOne("Gestao.Produto.Domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("CodigoFornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
