using System.Collections.Generic;

namespace Carrinho.API.Presentation.DTOs
{
    public class CarrinhoDeCompraDTO
    {
        public decimal PrecoTotalDoCarrinhoSemFrete { get; set; }
        public IEnumerable<ItemCarrinhoDeCompraDTO> Itens {get;set;}
    }
}