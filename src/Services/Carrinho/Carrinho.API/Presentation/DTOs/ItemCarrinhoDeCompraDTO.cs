namespace Carrinho.API.Presentation.DTOs
{
    public class ItemCarrinhoDeCompraDTO
    {
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string FornecedorUID { get; set; }
        public string Fornecedor { get; set; }
        public string ImagemProduto {get;set;}
    }
}