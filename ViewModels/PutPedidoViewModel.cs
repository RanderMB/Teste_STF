namespace CrudProduto.ViewModels
{
    public class PutPedidoViewModel
    {
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public bool Pago { get; set; }
        public List<PutItensPedidoViewModel> ItensPedido { get; set; }


        public class PutItensPedidoViewModel
        {
            public int IdProduto { get; set; }
            public int Quantidade { get; set; }
        }
    }
}
