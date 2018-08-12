using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.API.Domain.Entities;

namespace Pedidos.API.Infrastructure.Data.Configuration
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("Pedido_Itens");
            builder.HasKey(x => x.PedidoItemId);
            builder.Property(x => x.PedidoItemId).HasColumnName("PEDIDO_ITEM_ID").UseSqlServerIdentityColumn().IsRequired();

            builder.Property(x => x.CodigoProduto).HasColumnName("PRODUTO_UID").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.NomeProduto).HasColumnName("NOME_PRODUTO").IsRequired();
            builder.Property(x => x.ImagemProduto).HasColumnName("IMAGEM_PRODUTO").IsRequired();
            builder.Property(x => x.PrecoUnitario).HasColumnName("PRECO_UNITARIO").IsRequired();
            builder.Property(x => x.Quantidade).HasColumnName("QUANTIDADE").IsRequired();
        }
    }
}