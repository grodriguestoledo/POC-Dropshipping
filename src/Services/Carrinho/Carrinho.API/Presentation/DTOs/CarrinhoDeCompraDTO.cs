using System.Collections.Generic;

namespace Carrinho.API.Presentation.DTOs
{
    public class CarrinhoDeCompraDTO
    {
        public IEnumerable<ItemCarrinhoDeCompraDTO> Itens {get;set;}
    }
}