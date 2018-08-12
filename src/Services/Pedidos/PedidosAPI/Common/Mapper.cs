using System.Linq;
using Pedidos.API.Domain.Entities;
using Pedidos.API.Presentation.DTOs;

namespace Pedidos.API.Common
{
    public static class Mapper
    {
        public static Pedido Map(PedidoCadastroDTO dto)
        {
            return null;
            // var pedido = new Pedido();
            // pedido.EnderecoParaEntrega = new Endereco
            // {
            //     Bairro = dto.EnderecoParaEntrega.Bairro,
            //     CEP = dto.EnderecoParaEntrega.CEP,
            //     Complemento = dto.EnderecoParaEntrega.Complemento,
            //     Cidade = dto.EnderecoParaEntrega.Cidade,
            //     Logradouro = dto.EnderecoParaEntrega.Logradouro,
            //     Numero = dto.EnderecoParaEntrega.Numero,
            //     UF = dto.EnderecoParaEntrega.UF
            // };

            // dto.Itens.Select(x => new PedidoFornecedor
            // {
            //     CodigoFornecedor = x.FornecedorUID,
            //     DadosDaEntrega = new DadosEntrega()
            //     {
            //         ValorDoFrete = x.ValorFrete,
            //         PrazoMaximoDeEntrega = x.PrazoMaximoEntrega,
            //         PrazoMinimoDeEntrega = x.PrazoMinimoEntrega
            //     },
            //     ItensDoPedido = x.Subitens.Select(y=> new PedidoItem{
            //         CodigoProduto = y.CodigoProduto,
            //         ImagemProduto = y.ImagemProduto,
            //         NomeProduto = y.NomeProduto,
            //         PrecoUnitario = y.PrecoUnitario,
            //         Quantidade = y.Quantidade
            //     })
            // });

            // return pedido;
        }
    }
}