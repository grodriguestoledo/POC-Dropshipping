using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.API.Domain.Entities;
using Pedidos.API.Infrastructure.Data;
using Pedidos.API.Presentation.DTOs;

namespace Pedidos.API.Controllers
{
    [Route("api/pedidos")]
    public class PedidoController : Controller
    {
        private PedidosDbContext _context;
        public PedidoController(PedidosDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost("")]
        public async Task<IActionResult> CriarPedido([FromBody] PedidoCadastroDTO pedidoCadastro)
        {
            var codigoClienteClaim = this.User.Claims.FirstOrDefault(x => x.Type == "sub");
            if (codigoClienteClaim == null) return StatusCode(401);

            var codigoCliente = codigoClienteClaim.Value;

            var pedido = Pedido.CriarNovoPedido(codigoCliente);
            pedido.AdicionarEnderecoDeEntrega(new Endereco
            {
                Bairro = pedidoCadastro.EnderecoParaEntrega.Bairro,
                CEP = pedidoCadastro.EnderecoParaEntrega.CEP,
                Complemento = pedidoCadastro.EnderecoParaEntrega.Complemento,
                Cidade = pedidoCadastro.EnderecoParaEntrega.Cidade,
                Logradouro = pedidoCadastro.EnderecoParaEntrega.Logradouro,
                Numero = pedidoCadastro.EnderecoParaEntrega.Numero,
                UF = pedidoCadastro.EnderecoParaEntrega.UF
            });

            foreach (var pedidoDoFornecedor in pedidoCadastro.Itens)
            {
                var pedidoFornecedor = new PedidoFornecedor();
                pedidoFornecedor.CodigoFornecedor = Guid.Parse(pedidoDoFornecedor.FornecedorUID);
                pedidoFornecedor.DadosDaEntrega = new DadosEntrega()
                {
                    ValorDoFrete = pedidoDoFornecedor.ValorFrete,
                    PrazoMaximoDeEntrega = pedidoDoFornecedor.PrazoMaximoEntrega,
                    PrazoMinimoDeEntrega = pedidoDoFornecedor.PrazoMinimoEntrega
                };

                foreach (var itemDoPedido in pedidoDoFornecedor.Subitens)
                {
                    pedidoFornecedor.AdicionarProdutoASerEntregue(new PedidoItem
                    {
                        CodigoProduto = Guid.Parse(itemDoPedido.CodigoProduto),
                        ImagemProduto = itemDoPedido.ImagemProduto,
                        NomeProduto = itemDoPedido.NomeProduto,
                        PrecoUnitario = itemDoPedido.PrecoUnitario,
                        Quantidade = itemDoPedido.Quantidade
                    });
                }

                pedido.AdicionarPedidosDoFornecedor(pedidoFornecedor);
            }

            _context.Add(pedido);
            await _context.SaveChangesAsync();

            return StatusCode(200, pedido);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetMeusPedidos()
        {
            var codigoClienteClaim = this.User.Claims.FirstOrDefault(x => x.Type == "sub");
            if (codigoClienteClaim == null) return StatusCode(401);

            var codigoCliente = codigoClienteClaim.Value;

            var pedidos = await _context.Pedidos
             .Include(x => x.EnderecoParaEntrega)
             .Include("FornecedoresDoPedido.ItensDoPedido")
             .Include("FornecedoresDoPedido.DadosDaEntrega")
             .Where(x => x.CodigoCliente == Guid.Parse(codigoCliente)).ToListAsync();

             return StatusCode(200,pedidos);
        }
    }
}
