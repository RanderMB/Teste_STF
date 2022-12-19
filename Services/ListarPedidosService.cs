using CrudProduto.Data;
using CrudProduto.Models;
using CrudProduto.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CrudProduto.Services
{
    public class ListarPedidosService
    {
        public ListarPedidosService(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; }

        public GetPedidoViewModel GetById(int id)
        {
            var pedido = Context.Pedidos
                .Include(x => x.ItensPedido)
                .ThenInclude(y => y.Produto)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            GetPedidoViewModel viewMoel = null;
             
            if (pedido != null)
            {
                viewMoel = ConstruirResponse(pedido);
            }
      
            return viewMoel;
        }

        public List<GetPedidoViewModel> GetAll()
        {
            var pedidos = Context.Pedidos
                .Include(x => x.ItensPedido)
                .ThenInclude(y => y.Produto)
                .ToList();

            List<GetPedidoViewModel> viewModels =
                pedidos?.Select(a => ConstruirResponse(a)).ToList();


            return viewModels;
        }

        public GetPedidoViewModel ConstruirResponse(Pedido pedido)
        {
            var valorTotal = 0.0;
            foreach (var item in pedido.ItensPedido)
            {
                var valorTotalItem = item.Quantidade * item.Produto.Valor;
                valorTotal += valorTotalItem;
            }

            var viewModel = new GetPedidoViewModel
            {
                Id = pedido.Id,
                NomeCliente = pedido.NomeCliente,
                EmailCliente = pedido.EmailCliente,
                Pago = pedido.Pago,
                ValorTotal = valorTotal,
                ItensPedido = pedido.ItensPedido.Select(x => new GetItensPedidoViewModel
                {
                    Id = x.Id,
                    IdProduto = x.IdProduto,
                    NomeProduto = x.Produto.NomeProduto,
                    ValorUnitario = x.Produto.Valor,
                    Quantidade = x.Quantidade

                }).ToList()

            };

            return viewModel;
        }
    }
}
