namespace Pedidos.API.Presentation.DTOs
{
    public class PedidoFornecedorItemDTO
    {
        public string CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public string ImagemProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}