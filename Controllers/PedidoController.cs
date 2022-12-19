using CrudProduto.Data;
using CrudProduto.Models;
using CrudProduto.Services;
using CrudProduto.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudProduto.Controllers
{

    [ApiController]
    public class PedidoController : ControllerBase
    {

        [HttpGet("pedidos")]
        public IActionResult Get(
            [FromServices] AppDbContext context)
        {
            var listarPedidosService = new ListarPedidosService(context);
            var response = listarPedidosService.GetAll();

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("pedidos/{id:int}")]
        public IActionResult GetById(
           [FromRoute] int id,
           [FromServices] AppDbContext context)
        {
            var listarPedidosService = new ListarPedidosService(context);
            var response = listarPedidosService.GetById(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost("pedidos")]
        public IActionResult Post(
           [FromBody] EditorPedidoViewModel model,
           [FromServices] AppDbContext context)
        {
                var pedidos = new Pedido
                {
                    NomeCliente = model.NomeCliente,
                    EmailCliente = model.EmailCliente,
                    Pago = model.Pago,
                    DataCriacao = DateTime.Now,
                    ItensPedido = model.ItensPedido.Select(x => new ItensPedido()
                    {
                        IdProduto = x.IdProduto,
                        Quantidade = x.Quantidade
                    }).ToList()
                }; 

                context.Pedidos.Add(pedidos);
                context.SaveChanges();

                return Created($"pedidos/{pedidos.Id}", pedidos);
            
        }

        [HttpPut("pedidos/{id:int}")]
        public IActionResult Put(
           [FromRoute] int id,
           [FromBody] EditorPedidoViewModel model,
           [FromServices] AppDbContext context)
        {

            var pedido = context.Pedidos
               .Include(x => x.ItensPedido)
               .ThenInclude(y => y.Produto)
               .Where(x => x.Id == id).FirstOrDefault();

            if (pedido == null)
                return NotFound();

            pedido.NomeCliente = model.NomeCliente;
            pedido.EmailCliente = model.EmailCliente;
            pedido.Pago = model.Pago;

            context.ItensPedidos.RemoveRange(pedido.ItensPedido);

            pedido.ItensPedido = model.ItensPedido.Select(x => new ItensPedido()
            {
                IdProduto = x.IdProduto,
                Quantidade = x.Quantidade
            }).ToList();


            context.Pedidos.Update(pedido);
            context.SaveChanges();

            return Ok(pedido);
        }

        [HttpDelete("pedidos/{id:int}")]
        public IActionResult Delete(
          [FromRoute] int id,
          [FromServices] AppDbContext context)
        {
            var pedidos = context.Pedidos.FirstOrDefault(x => x.Id == id);

            if (pedidos == null)
                return NotFound();

            context.Pedidos.Remove(pedidos);
            context.SaveChanges();

            return Ok("Deletado com sucesso!");
        }

    }    
}
