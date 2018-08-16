using System;
using System.Collections.Generic;
using System.Linq;

namespace Pedidos.API.Domain.Entities
{
    public class Pedido
    {
        public Pedido()
        {
            FornecedoresDoPedido = new List<PedidoFornecedor>();
        }
        public int PedidoId { get; set; }
        public Guid CodigoPedido { get; set; }
        public Guid CodigoCliente { get; set; }
        public DateTime DataDoPedido { get; set; }
        public DateTime DataAtualizacaoStatus { get; set; }
        public Guid? CodigoPagamento { get; set; }
        public EnumStatusPedido StatusPedido {get;set;}
        public Endereco EnderecoParaEntrega { get; set; }

        public IList<PedidoFornecedor> FornecedoresDoPedido {get;set;}

        public static Pedido CriarNovoPedido(string codigoCliente)
        {
            return new Pedido
            {
                CodigoPedido = Guid.NewGuid(),
                CodigoCliente = Guid.Parse(codigoCliente),
                DataDoPedido = DateTime.UtcNow,
                DataAtualizacaoStatus = DateTime.UtcNow,
                StatusPedido = EnumStatusPedido.AguardandoPagamento
            };
        }

        public void AdicionarEnderecoDeEntrega(Endereco endereco)
        {
            this.EnderecoParaEntrega= endereco;
        }

        public void AdicionarPedidosDoFornecedor(PedidoFornecedor pedidoFornecedor)
        {
            this.FornecedoresDoPedido.Add(pedidoFornecedor);
        }

        public decimal ObterValorTotalDoPedido()
        {
            return this.FornecedoresDoPedido.Sum(x=>x.ItensDoPedido.Sum(y=>y.PrecoUnitario * y.Quantidade) + x.DadosDaEntrega.ValorDoFrete);
        }
    }
}