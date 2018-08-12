using Microsoft.EntityFrameworkCore;
using Cliente.API.Domain.Entities;
namespace Cliente.API.Infrastructure.Data.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Cliente.API.Domain.Entities.Endereco>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cliente.API.Domain.Entities.Endereco> builder)
        {
            builder.ToTable("Enderecos");
            builder.HasKey(x => x.EnderecoId);
            builder.Property(x => x.EnderecoId).HasColumnName("ENDERECO_ID").UseSqlServerIdentityColumn().IsRequired();

            builder.Property(x=>x.Descricao).HasColumnName("DESCRICAO").IsRequired();
            builder.Property(x=>x.UID).HasColumnName("UID").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(x => x.Logradouro).HasColumnName("LOGRADOURO").IsRequired();
            builder.Property(x => x.Bairro).HasColumnName("BAIRRO").IsRequired();
            builder.Property(x => x.CEP).HasColumnName("CEP").IsRequired();
            builder.Property(x => x.Cidade).HasColumnName("CIDADE").IsRequired();
            builder.Property(x => x.Complemento).HasColumnName("COMPLEMENTO");
            builder.Property(x => x.EhEnderecoPrincipal).HasColumnName("ENDERECO_PRINCIPAL").IsRequired();
            builder.Property(x => x.Numero).HasColumnName("NUMERO").IsRequired();
            builder.Property(x => x.UF).HasColumnName("UF").IsRequired();

        }
    }
}