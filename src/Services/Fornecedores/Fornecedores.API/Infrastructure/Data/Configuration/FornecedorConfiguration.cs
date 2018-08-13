using Fornecedores.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores.API.Infrastructure.Data.Configuration
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedores");
            builder.HasKey(x => x.FornecedorId);
            builder.Property(x => x.FornecedorId).HasColumnName("FORNECEDOR_ID").UseSqlServerIdentityColumn().IsRequired();

            builder.Property(x => x.CodigoFornecedor).HasColumnName("FORNECEDOR_UID").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x=>x.Nome).HasColumnName("NOME").IsRequired();

        }
    }
}