using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Presentation.DTO;
using Produtos.API.Infrastructure.Data;

namespace Produtos.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : Controller
    {
        private readonly ProdutoRepository _produtoRepository;
        private readonly IConfiguration _configuration;
        public readonly string _produtoImagemUrl;
        public ProdutosController(ProdutoRepository produtoRepository, IConfiguration configuration)
        {
            _produtoRepository = produtoRepository;
            _configuration = configuration;
            _produtoImagemUrl = _configuration.GetSection("ProdutoImagemUrl")["URL"];

        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get(string f = "")
        {
            var produtos = await _produtoRepository.ObterProdutos(f);

            var listaProdutos = produtos.Select(x => new ProdutoListagemDTO
            {
                CodigoProduto = x.CodigoProduto,
                Categoria = x.Categoria,
                NomeProduto = x.NomeProduto,
                Preco = x.Preco,
                Fornecedor = x.Fornecedor,
                //ImagemProduto = x.ImagemUrl,
                ImagemProduto = string.Format(_produtoImagemUrl, x.CodigoProduto.ToLower()),
                FornecedorUID = x.FornecedorUID
            });

            if (!listaProdutos.Any()) return this.StatusCode(404, null);

            return this.StatusCode(200, listaProdutos);
        }

        [HttpGet("{codigoProduto}")]
        public async Task<IActionResult> GetDetalhe(string codigoProduto)
        {
            var produtoDetalhe = await _produtoRepository.ObterProdutoDetalhe(codigoProduto);
            if (produtoDetalhe == null) return this.StatusCode(404, null);

            return this.StatusCode(200, new ProdutoDetalheDTO
            {
                Descricao = produtoDetalhe.Descricao,
                Detalhes = produtoDetalhe.Detalhes,
                CodigoProduto = produtoDetalhe.CodigoProduto,
                Categoria = produtoDetalhe.Categoria,
                NomeProduto = produtoDetalhe.NomeProduto,
                Preco = produtoDetalhe.Preco,
                Fornecedor = produtoDetalhe.Fornecedor,
                // ImagemProduto = produtoDetalhe.ImagemUrl,
                ImagemProduto = string.Format(_produtoImagemUrl, produtoDetalhe.CodigoProduto.ToLower()),

                FornecedorUID = produtoDetalhe.FornecedorUID
            });
        }
    }
}
