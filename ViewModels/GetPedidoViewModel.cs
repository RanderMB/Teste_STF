namespace CrudProduto.ViewModels
{
    public class GetPedidoViewModel
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public bool Pago { get; set; }
        public double ValorTotal { get; set; }
        public List<GetItensPedidoViewModel> ItensPedido { get; set; }
    }

    public class GetItensPedidoViewModel
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public double ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
