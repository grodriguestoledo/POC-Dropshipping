using System;

namespace Pedidos.API.Domain.Entities
{
    public class HistoricoEntrega
    {
        public int HistoricoEntregaId { get; set; }
        public EnumStatusEntrega StatusDaEntrega { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Descricao { get; set; }
    }
}