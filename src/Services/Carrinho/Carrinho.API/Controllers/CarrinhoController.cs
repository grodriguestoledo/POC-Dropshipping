namespace Carrinho.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Carrinho.API.Presentation.DTOs;
    using ServiceStack.Redis;

    [Route("api/carrinho")]
    public class CarrinhoController : Controller
    {
        [HttpGet("{codigoCliente}")]
        public CarrinhoDeCompraDTO Get(string codigoCliente)
        {
            var redisKey = "cart_" + codigoCliente;
            var mgr = new RedisManagerPool("192.168.2.122:6379");
            using (var client = mgr.GetClient())
            {
                return client.Get<CarrinhoDeCompraDTO>(redisKey);
            }
        }

        [HttpPost("{codigoCliente}")]
        public void Post(string codigoCliente, [FromBody]CarrinhoDeCompraDTO carrinho)
        {
            var redisKey = "cart_" + codigoCliente;

            var mgr = new RedisManagerPool("192.168.2.122:6379");
            using (var client = mgr.GetClient())
            {
                client.Set(redisKey, carrinho, DateTime.Now.AddHours(1));
            }
        }

        [HttpDelete("{codigoCliente}")]
        public void Delete(string codigoCliente)
        {
            var redisKey = "cart_" + codigoCliente;

            var mgr = new RedisManagerPool("192.168.2.122:6379");
            using (var client = mgr.GetClient())
            {
                client.Remove(redisKey);
            }
        }
    }
}
