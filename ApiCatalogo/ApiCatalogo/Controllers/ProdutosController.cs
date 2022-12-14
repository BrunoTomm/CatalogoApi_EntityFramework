using ApiCatalogo.Context;
using ApiCatalogo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context; //Instancia DbContext

        public ProdutosController(AppDbContext context) //Construtor DbContext
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProdutos()//Coleção de objetos do tipo Produto, poderia ser usado list
        {
            var produtos = _context.Produtos.ToList();

            if (produtos is null) //Se nn houver produtos é necessário tratar
            {
                return NotFound("Produtos não encontrados");//Error 404 - Para poder utilizar é necessário o ActionResult
            }
            return produtos;
        }

        [HttpGet("{id:int}", Name = "ObterProduto")] //Rota nomeada
        public ActionResult<Produto> GetProdutoPorId(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(_ => _.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado!");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto) //Não é necessário [FromBody] desde a versão 2.2, ele entende que vem do body do request
        {
            if (produto is null)
            {
                return BadRequest();
            }

            _context.Produtos.Add(produto); //Incluindo no contexto do Entity
            _context.SaveChanges(); //Salva na tabela

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto); //201 Created - Retorna o produto no Body com a rota ObterProduto
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto) //Nessa abordagem é necessária uma atualização completa de todos os itens do Body
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }
            _context.Entry(produto).State = EntityState.Modified; //informa que o contexto esta sendo alterado, e deve depois ser salvo
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(_ => _.ProdutoId == id);
            //var produto = _context.Produtos.Find(id); //Para funcionar o id precisa ser a chave primaria na tabela

            if (produto is null)
            {
                return NotFound("Produto Não Localizado...");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
