namespace Carrinho.API.Domain.Entities
{
    public class ItemCarrinhoDeCompra
    {
        public string CodigoProduto {get;set;}
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string FornecedorUID { get; set; }
        public string Fornecedor { get; set; }
        public string ImagemProduto { get; set; }

        public decimal CalcularPrecoTotalDoItem()
        {
            return Quantidade * PrecoUnitario;
        }
    }
}