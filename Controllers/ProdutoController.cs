using CrudProduto.Data;
using CrudProduto.Models;
using CrudProduto.ViewModels;
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
           [FromBody] EditorProdutoViewModel model,
           [FromServices] AppDbContext context)
        {
            var produtos = new Produto
            {
                NomeProduto = model.NomeProduto,
                Valor = model.Valor
            };

            context.Produtos.Add(produtos);
            context.SaveChanges();

            return Created($"produtos/{produtos.Id}", produtos);
        }

        [HttpPut("produtos/{id:int}")]
        public IActionResult Put(
           [FromRoute] int id,
           [FromBody] EditorProdutoViewModel model,
           [FromServices] AppDbContext context)
        {
            var produto = context.Produtos.FirstOrDefault(x => x.Id == id);

            if (produto == null)
                return NotFound();



            produto.NomeProduto = model.NomeProduto;
            produto.Valor = model.Valor;
            

            context.Produtos.Update(produto);
            context.SaveChanges();

            return Ok(model);
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
