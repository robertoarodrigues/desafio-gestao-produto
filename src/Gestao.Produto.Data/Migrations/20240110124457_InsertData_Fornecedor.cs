using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao.Produto.Data.Migrations
{
    public partial class InsertData_Fornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                    schema: "dbo",
                    table: "Fornecedor",
                    columns: new[] { "Descricao", "Cnpj" },
                    values: new object[,]
                    {
                        {"Fonecedor 1", "14.085.369/0001-59"},
                        {"Fonecedor 2", "15.503.323/0001-75"},
                        {"Fonecedor 3", "93.659.062/0001-90"},
                        {"Fonecedor 4", "99.115.924/0001-09"},
                        {"Fonecedor 5", "63.905.871/0001-74"},
                    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
