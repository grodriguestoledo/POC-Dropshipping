using Fornecedores.API.Domain;
using Fornecedores.API.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores.API.Infrastructure.Data
{
    public interface IFornecedoresDbContext
    {
        DbSet<Fornecedor> Fornecedores {get;set;}
    }

    public class FornecedoresDbContext : DbContext,IFornecedoresDbContext
    {
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public FornecedoresDbContext(DbContextOptions<FornecedoresDbContext> options) :
         base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Fornecedor>(new FornecedorConfiguration());

        }
    }
}