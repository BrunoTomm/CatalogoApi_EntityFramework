using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    public partial class PopulaCategoria : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categorias(Nome, Imagem) Values('Bebidas','bebidas.jpg')");
            mb.Sql("INSERT INTO Categorias(Nome, Imagem) Values('Lanches','lanches.jpg')");
            mb.Sql("INSERT INTO Categorias(Nome, Imagem) Values('Sobremesas','sobremesas.jpg')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
        }
    }
}
