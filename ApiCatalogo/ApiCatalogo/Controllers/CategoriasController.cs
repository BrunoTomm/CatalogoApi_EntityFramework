using ApiCatalogo.Context;
using ApiCatalogo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        #region Itens para melhorar desempenho Get 
        // Utilizar WHERE em includes ou pesquisas para delimitar o retorno
        // Utilizar Take para delimitar itens do que retornarão
        // Utilizar AsNoTracking em itens GET onde é somente leitura
        #endregion
        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            //return _context.Categorias.Include(_ => _.Produtos).ToList();
            return _context.Categorias.Include(_ => _.Produtos).Where(c => c.CategoriaId <= 5).ToList(); //Deve-se sempre delimitar a quantidade em um ambiente de prod.
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetProdutos()
        {
            var categorias = _context.Categorias.AsNoTracking().Take(10).ToList(); //AsNoTracking nao rastreia, deixando com melhor desempenho, porem, deve ser utilizado em somente leitura
                                                                                   //Utilizar o take, para delimitar a quantidade 
            if (categorias is null) 
            {
                return NotFound("Produtos não encontrados");
            }
            return categorias;
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")] 
        public ActionResult<Categoria> GetCategoriaPorId(int id)
        {
            try
            {
                var categoria = _context.Categorias.FirstOrDefault(_ => _.CategoriaId == id);

                if (categoria is null)
                {
                    return NotFound($"Categoria com id = {id}, não encontrado!");
                }
                return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest("Dados inválidos");
            }

            _context.Categorias.Add(categoria); 
            _context.SaveChanges(); 

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest("Dados inválidos");
            }
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(_ => _.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound($"Categoria com id = {id}, não Localizado...");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
    }
}
