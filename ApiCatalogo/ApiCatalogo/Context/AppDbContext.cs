using ApiCatalogo.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Context
{
    public class AppDbContext : DbContext //herda de DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //Construtor herda base
        {}

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Combos> Combos { get; set; }
    }
}

