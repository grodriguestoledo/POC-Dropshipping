using System.Collections.Generic;

namespace Pedidos.API.Presentation.DTOs
{
    public class PedidoCadastroDTO
    {
        public PedidoCadastroDTO()
        {
            
        }

        public EnderecoEntregaDTO EnderecoParaEntrega {get;set;}
        public IEnumerable<PedidoFornecedorDTO> Itens {get;set;}
    }
}