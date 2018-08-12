using System.Collections.Generic;

namespace Pedidos.API.Presentation.DTOs
{
    public class PedidoFornecedorDTO
    {
        public PedidoFornecedorDTO()
        {

        }

        public string Fornecedor { get; set; }
        public string FornecedorUID { get; set; }
        public int PrazoMinimoEntrega { get; set; }
        public int PrazoMaximoEntrega { get; set; }
        public decimal ValorFrete { get; set; }
        public IEnumerable<PedidoFornecedorItemDTO> Subitens { get; set; }

    }
}