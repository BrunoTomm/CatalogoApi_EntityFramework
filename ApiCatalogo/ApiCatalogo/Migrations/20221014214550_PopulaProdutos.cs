using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "VALUES('Coca-Cola','Refrigerante de 350 ml', 5.45 ,'cocacola.png', 50 , convert(varchar, getdate(),   9), 1)");

            mb.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "VALUES('Lanche de Atum','Lanche de atum com maionese', 8.45 ,'atum.png', 10 , convert(varchar, getdate(),   9), 2)");

            mb.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "VALUES('Pudim','Pudim de leite condensado', 6.45 ,'pudim.png', 20 , convert(varchar, getdate(),   9), 3)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM PRODUTOS");

        }
    }
}
