using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.API.Domain.Entities;

namespace Pedidos.API.Infrastructure.Data.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(x => x.PedidoId);
            builder.Property(x => x.PedidoId).HasColumnName("PEDIDO_ID").UseSqlServerIdentityColumn().IsRequired();

            builder.Property(x => x.CodigoCliente).HasColumnName("CLIENTE_UID").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.CodigoPedido).HasColumnName("UID").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.DataDoPedido).HasColumnName("DATA_CADASTRO").IsRequired();
            builder.Property(x => x.DataAtualizacaoStatus).HasColumnName("DATA_ATUALIZACAO_STATUS").IsRequired();

            builder.Property(x => x.StatusPedido).HasColumnName("STATUS").IsRequired();

            builder.Property(x => x.CodigoPagamento).HasColumnName("PAGAMENTO_UID").HasColumnType("uniqueidentifier");

            builder.OwnsOne(x => x.EnderecoParaEntrega).ToTable("Pedidos_Enderecos");
            builder.OwnsOne(x => x.EnderecoParaEntrega).HasForeignKey("PEDIDO_ID");
          //  builder.OwnsOne(x => x.EnderecoParaEntrega).Property(x => x.EnderecoId).HasColumnName("ENDERECO_ID").UseSqlServerIdentityColumn().IsRequired();
            builder.OwnsOne(x => x.EnderecoParaEntrega).Property(x => x.Logradouro).HasColumnName("LOGRADOURO").IsRequired();
            builder.OwnsOne(x => x.EnderecoParaEntrega).Property(x => x.Bairro).HasColumnName("BAIRRO").IsRequired();
            builder.OwnsOne(x => x.EnderecoParaEntrega).Property(x => x.CEP).HasColumnName("CEP").IsRequired();
            builder.OwnsOne(x => x.EnderecoParaEntrega).Property(x => x.Cidade).HasColumnName("CIDADE").IsRequired();
            builder.OwnsOne(x => x.EnderecoParaEntrega).Property(x => x.Complemento).HasColumnName("COMPLEMENTO");
            builder.OwnsOne(x => x.EnderecoParaEntrega).Property(x => x.Numero).HasColumnName("NUMERO").IsRequired();
            builder.OwnsOne(x => x.EnderecoParaEntrega).Property(x => x.UF).HasColumnName("UF").IsRequired();


            builder.HasMany(x => x.FornecedoresDoPedido).WithOne().IsRequired().HasForeignKey("PEDIDO_ID");
        }
    }
}