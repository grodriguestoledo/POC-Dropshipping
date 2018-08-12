using System;
using System.Collections.Generic;

namespace Pedidos.API.Domain.Entities
{
    public class PedidoFornecedor
    {
        public PedidoFornecedor()
        {
            ItensDoPedido = new List<PedidoItem>();
        }
        public int PedidoFornecedorId { get; set; }
        public Guid CodigoFornecedor { get; set; }
        public IList<PedidoItem> ItensDoPedido { get; set; }
        public DadosEntrega DadosDaEntrega { get; set; }

        public void AdicionarProdutoASerEntregue(PedidoItem item)
        {
            ItensDoPedido.Add(item);
        }
        // public IEnumerable<HistoricoEntrega> EventosDaEntrega {get;set;}
    }
}