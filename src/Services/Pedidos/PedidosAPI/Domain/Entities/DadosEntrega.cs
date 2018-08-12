using System;

namespace Pedidos.API.Domain.Entities
{
    public class DadosEntrega
    {
        public decimal ValorDoFrete { get; set; }
        public int PrazoMinimoDeEntrega { get; set; }
        public int PrazoMaximoDeEntrega { get; set; }
    }
}