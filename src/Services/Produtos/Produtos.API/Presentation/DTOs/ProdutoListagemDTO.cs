namespace Presentation.DTO
{
    public class ProdutoListagemDTO
    {
        public string CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public string Fornecedor { get; set; }
        public string ImagemProduto { get; set; }
        public string FornecedorUID { get; set; }
    }
}