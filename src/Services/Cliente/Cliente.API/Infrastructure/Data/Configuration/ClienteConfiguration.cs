using Microsoft.EntityFrameworkCore;
using Cliente.API.Domain.Entities;
namespace Cliente.API.Infrastructure.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente.API.Domain.Entities.Cliente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cliente.API.Domain.Entities.Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(x => x.ClienteId);
            builder.Property(x => x.ClienteId).HasColumnName("CLIENTE_ID").UseSqlServerIdentityColumn().IsRequired();
            builder.Property(x => x.ContaUID).HasColumnName("CONTA_UID").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.ClienteId).HasColumnName("UID").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x=>x.Nome).HasColumnName("NOME").IsRequired();
            builder.Property(x=>x.Sobrenome).HasColumnName("SOBRENOME").IsRequired();
            builder.Property(x=>x.Email).HasColumnName("EMAIL").IsRequired();

            builder.HasMany(x=>x.Enderecos).WithOne().IsRequired().HasForeignKey("CLIENTE_ID");

            builder.HasIndex(x=>x.ContaUID);

        }
    }
}