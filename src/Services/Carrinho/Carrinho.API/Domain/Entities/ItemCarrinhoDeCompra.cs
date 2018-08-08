namespace Carrinho.API.Domain.Entities
{
    public class ItemCarrinhoDeCompra
    {
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string FornecedorUID { get; set; }
        public string Fornecedor { get; set; }

        public decimal CalcularPrecoTotalDoItem()
        {
            return Quantidade * PrecoUnitario;
        }
    }
}