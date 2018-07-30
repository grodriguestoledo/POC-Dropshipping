namespace Autenticacao.API.Infrastructure.Data.Configurations
{
    using Autenticacao.API.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContaConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(x=>x.ContaId);
            builder.Property(x=>x.ContaId).HasColumnName("CONTA_ID").UseSqlServerIdentityColumn().IsRequired();

            builder.Property(x=>x.Login).HasColumnName("LOGIN").IsRequired();
            builder.Property(x=>x.Nome).HasColumnName("NOME").IsRequired();
            builder.Property(x=>x.Sobrenome).HasColumnName("SOBRENOME").IsRequired();
            builder.Property(x=>x.Senha).HasColumnName("SENHA").IsRequired();
            builder.Property(x=>x.TipoConta).HasColumnName("TIPO").IsRequired();

            builder.Property(x=>x.ContaUID).HasColumnName("UID").HasColumnType("uniqueidentifier").IsRequired();
            builder.HasIndex(x=>x.ContaUID);
            builder.ToTable("Conta");
        }
    }
}