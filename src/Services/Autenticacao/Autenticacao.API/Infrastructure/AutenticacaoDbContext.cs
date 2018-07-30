using Autenticacao.API.Domain.Entities;
using Autenticacao.API.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao.API.Infrastructure
{
    public class AutenticacaoDbContext : DbContext
    {
        public DbSet<Conta> Contas {get;set;}
        public AutenticacaoDbContext(DbContextOptions<AutenticacaoDbContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Conta>(new ContaConfiguration());
        }
    }
}