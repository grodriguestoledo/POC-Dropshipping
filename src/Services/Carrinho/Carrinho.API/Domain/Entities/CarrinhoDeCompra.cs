using System.Collections.Generic;
using System.Linq;

namespace Carrinho.API.Domain.Entities
{
    public class CarrinhoDeCompra
    {
        public IEnumerable<ItemCarrinhoDeCompra> Itens {get;set;}
        public CarrinhoDeCompra()
        {
            Itens = new List<ItemCarrinhoDeCompra>();
        }

        public decimal CalcularPrecoTotalDoCarrinho()
        {
            if(!Itens.Any()) return 0;

            return Itens.Sum(x=>x.PrecoUnitario * x.Quantidade);
        }
    }
}