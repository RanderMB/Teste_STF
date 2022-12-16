using System.ComponentModel.DataAnnotations.Schema;

namespace CrudProduto.Models
{
    public class ItensPedido
    {
        public int Id { get; set; }
        
        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }

        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        
        public int Quantidade { get; set; }

    }
}
