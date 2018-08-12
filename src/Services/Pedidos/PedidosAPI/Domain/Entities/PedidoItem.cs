using System;

namespace Pedidos.API.Domain.Entities
{
    public class PedidoItem
    {
        public int PedidoItemId { get; set; }
        public Guid CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public string ImagemProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}