namespace Carrinho.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Carrinho.API.Presentation.DTOs;
    using ServiceStack.Redis;
    using Carrinho.API.Infrastructure.Data;
    using Carrinho.API.Common;

    [Route("api/carrinho")]
    public class CarrinhoController : Controller
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        public CarrinhoController(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }
        [HttpGet("{codigoCliente}")]
        public async Task<IActionResult> Get(string codigoCliente)
        {
            var carrinhoKey = "cart_" + codigoCliente;

            var carrinho = await _carrinhoRepository.ObterCarrinho(carrinhoKey);

            if (carrinho == null) return StatusCode(204);

            var carrinhoDTO = Mapper.Map(carrinho);
            return StatusCode(200, carrinhoDTO);
        }

        [HttpPost("{codigoCliente}")]
        public async Task<IActionResult> Post(string codigoCliente, [FromBody]CarrinhoDeCompraDTO carrinhoDTO)
        {
            var carrinhoKey = "cart_" + codigoCliente;
            if (carrinhoDTO == null) return StatusCode(400);

            var carrinho = Mapper.Map(carrinhoDTO);
            await _carrinhoRepository.PersistirCarrinho(carrinhoKey, carrinho);

            return StatusCode(201);
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete()
        {
            var codigoClienteClaim = this.User.Claims.FirstOrDefault(x => x.Type == "sub");
            if (codigoClienteClaim == null) return StatusCode(401);

            var codigoCliente = codigoClienteClaim.Value;
            var carrinhoKey = "cart_" + codigoCliente;
            await _carrinhoRepository.RemoverCarrinho(carrinhoKey);

            return StatusCode(200);
        }
    }
}
