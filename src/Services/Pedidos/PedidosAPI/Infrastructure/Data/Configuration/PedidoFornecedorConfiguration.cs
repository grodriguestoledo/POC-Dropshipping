using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.API.Domain.Entities;

namespace Pedidos.API.Infrastructure.Data.Configuration
{
    public class PedidoFornecedorConfiguration : IEntityTypeConfiguration<PedidoFornecedor>
    {
        public void Configure(EntityTypeBuilder<PedidoFornecedor> builder)
        {
            builder.ToTable("Pedidos_Fornecedores");
            builder.HasKey(x => x.PedidoFornecedorId);
            builder.Property(x => x.PedidoFornecedorId).HasColumnName("PEDIDO_FORNECEDOR_ID").UseSqlServerIdentityColumn().IsRequired();

            builder.Property(x => x.CodigoFornecedor).HasColumnName("FORNECEDOR_UID").HasColumnType("uniqueidentifier").IsRequired();

            builder.OwnsOne(x => x.DadosDaEntrega).Property(x => x.PrazoMaximoDeEntrega).HasColumnName("PRAZO_MAXIMO").IsRequired();
            builder.OwnsOne(x => x.DadosDaEntrega).Property(x => x.PrazoMinimoDeEntrega).HasColumnName("PRAZO_MINIMO").IsRequired();
            builder.OwnsOne(x => x.DadosDaEntrega).Property(x => x.ValorDoFrete).HasColumnName("VALOR_FRETE").IsRequired();

            builder.HasMany(x=>x.ItensDoPedido).WithOne().IsRequired().HasForeignKey("PEDIDO_FORNECEDOR_ID");
        }
    }
}