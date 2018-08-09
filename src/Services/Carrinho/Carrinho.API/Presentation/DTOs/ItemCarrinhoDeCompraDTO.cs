namespace Carrinho.API.Presentation.DTOs
{
    public class ItemCarrinhoDeCompraDTO
    {
        public string CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string FornecedorUID { get; set; }
        public string Fornecedor { get; set; }
    }
}