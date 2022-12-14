using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Model;

[Table("Categorias")]
public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>(); //boa pratica quando se tem uma coleção é inicializar a mesma.
    }
    [Key]
    public int CategoriaId { get; set; }
    [Required]
    [MaxLength(80)]
    public string? Nome { get; set; }
    [Required]
    [MaxLength(300)]
    public string? Imagem { get; set; }

    public ICollection<Produto>? Produtos { get; set; } //relacionamento entre tabelas. Uma categoria contem uma colecao de produtos

}
