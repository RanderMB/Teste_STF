using CrudProduto.Data;
using CrudProduto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudProduto.Controllers
{
    
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet("produtos")]
        public IActionResult Get(
           [FromServices] AppDbContext context)
        {
            var produtos = context.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpGet("produtos/{id:int}")]
        public IActionResult GetById(
           [FromRoute] int id,
           [FromServices] AppDbContext context)
        {
            var produtos = context.Produtos.FirstOrDefault(x => x.Id == id);

            if (produtos == null)
                return NotFound();

            return Ok(produtos);
        }

        [HttpPost("produtos")]
        public IActionResult Post(
           [FromBody] Produto model,
           [FromServices] AppDbContext context)
        {
            context.Produtos.Add(model);
            context.SaveChanges();

            return Created($"produtos/{model.Id}", model);
        }

        [HttpPut("produtos/{id:int}")]
        public IActionResult Put(
           [FromRoute] int id,
           [FromBody] Produto model,
           [FromServices] AppDbContext context)
        {
            var produtos = context.Produtos.FirstOrDefault(x => x.Id == id);

            if (produtos == null)
                return NotFound();

            produtos.NomeProduto = model.NomeProduto;
            produtos.Valor = model.Valor;

            context.Produtos.Update(produtos);
            context.SaveChanges();

            return Created($"produtos/{model.Id}", model);
        }

        [HttpDelete("produtos/{id:int}")]
        public IActionResult Delete(
          [FromRoute] int id,
          [FromServices] AppDbContext context)
        {
            var produtos = context.Produtos.FirstOrDefault(x => x.Id == id);

            if (produtos == null)
                return NotFound();

            context.Produtos.Remove(produtos);
            context.SaveChanges();

            return Ok("Deletado com sucesso!");
        }
    }
}
