using Microsoft.EntityFrameworkCore;
using Pedidos.API.Infrastructure.Data.Configuration;

namespace Pedidos.API.Infrastructure.Data
{
    public class PedidosDbContext : DbContext
    {
        public DbSet<Pedidos.API.Domain.Entities.Pedido> Pedidos { get; set; }
        public PedidosDbContext(DbContextOptions<PedidosDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Pedidos.API.Domain.Entities.Pedido>(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration<Pedidos.API.Domain.Entities.PedidoItem>(new PedidoItemConfiguration());
            modelBuilder.ApplyConfiguration<Pedidos.API.Domain.Entities.PedidoFornecedor>(new PedidoFornecedorConfiguration());

        }
    }
}