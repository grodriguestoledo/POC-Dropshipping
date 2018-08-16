using System;
using System.Collections.Generic;

namespace Pedidos.API.Presentation.DTOs
{
    public class ListaPedidoDTO
    {
        public string CodigoPedido { get; set; }
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public decimal ValorTotal { get; set; }
        public int Status { get; set; }
    }
}