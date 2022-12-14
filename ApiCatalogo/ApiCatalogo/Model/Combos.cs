namespace ApiCatalogo.Model
{
    public class Combos
    {
        public int ComboId { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
