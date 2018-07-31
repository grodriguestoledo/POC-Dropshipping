using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;

namespace Produtos.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : Controller
    {
        // GET api/values
        [HttpGet]
        public ObjectResult Get()
        {
            var listaProdutos = new List<ProdutoListagemDTO>();
            listaProdutos.Add(new ProdutoListagemDTO{
                CodigoProduto = "aaaa",
                Categoria = "Ração",
                NomeProduto = "Whiskas",
                Preco = 10
            });
             listaProdutos.Add(new ProdutoListagemDTO{
                CodigoProduto = "aaaa",
                Categoria = "Ração",
                NomeProduto = "Furfles Ração Monstra",
                Preco = 9.99M
            });
             listaProdutos.Add(new ProdutoListagemDTO{
                CodigoProduto = "aaaa",
                Categoria = "Ração",
                NomeProduto = "Whiskas",
                Preco = 10
            });
             listaProdutos.Add(new ProdutoListagemDTO{
                CodigoProduto = "aaaa",
                Categoria = "Ração",
                NomeProduto = "Whiskas",
                Preco = 10
            });

            return this.StatusCode(200,listaProdutos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            return this.StatusCode(200,new ProdutoListagemDTO{
                CodigoProduto = "aaaa",
                Categoria = "Ração",
                NomeProduto = "Whiskas",
                Preco = 10
            });
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
