using Cliente.API.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Cliente.API.Infrastructure.Data
{
    public class ClienteDbContext : DbContext
    {
        public DbSet<Cliente.API.Domain.Entities.Cliente> Clientes { get; set; }
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Cliente.API.Domain.Entities.Cliente>(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration<Cliente.API.Domain.Entities.Endereco>(new EnderecoConfiguration());

        }
    }
}