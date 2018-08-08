using System;
using System.Threading.Tasks;
using Carrinho.API.Domain.Entities;
using ServiceStack.Redis;
using Microsoft.Extensions.Configuration;

namespace Carrinho.API.Infrastructure.Data
{
    public interface ICarrinhoRepository
    {
        Task<CarrinhoDeCompra> ObterCarrinho(string carrinhoId);

        Task PersistirCarrinho(string carrinhoId, CarrinhoDeCompra carrinho);

        Task RemoverCarrinho(string carrinhoId);
    }

    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly RedisManagerPool _manager;
        public CarrinhoRepository(IConfigurationRoot configuration)
        {
            var connStr = configuration.GetSection("Redis")["server"];
            this._manager = new RedisManagerPool(connStr);
        }

        public Task<CarrinhoDeCompra> ObterCarrinho(string carrinhoId)
        {
           return Task.Factory.StartNew(() =>
           {
               using (var redisClient = _manager.GetClient())
               {
                   return redisClient.Get<CarrinhoDeCompra>(carrinhoId);
               }
           });
        }

        public Task PersistirCarrinho(string carrinhoId, CarrinhoDeCompra carrinho)
        {
            return Task.Factory.StartNew(() =>
            {
                using (var client = _manager.GetClient())
                {
                    client.Set(carrinhoId, carrinho, DateTime.Now.AddHours(1));
                }
            });
        }

        public Task RemoverCarrinho(string carrinhoId)
        {
            return Task.Factory.StartNew(() =>
            {
                using (var client = _manager.GetClient())
                {
                    client.Remove(carrinhoId);
                }
            });
        }
    }
}