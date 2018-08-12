﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Pedidos.API.Domain.Entities;
using Pedidos.API.Infrastructure.Data;
using System;

namespace Pedidos.API.Infrastructure.Data.Migrations
{
    [DbContext(typeof(PedidosDbContext))]
    partial class PedidosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pedidos.API.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PEDIDO_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CodigoCliente")
                        .HasColumnName("CLIENTE_UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CodigoPagamento")
                        .HasColumnName("PAGAMENTO_UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CodigoPedido")
                        .HasColumnName("UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAtualizacaoStatus")
                        .HasColumnName("DATA_ATUALIZACAO_STATUS");

                    b.Property<DateTime>("DataDoPedido")
                        .HasColumnName("DATA_CADASTRO");

                    b.Property<int>("StatusPedido")
                        .HasColumnName("STATUS");

                    b.HasKey("PedidoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Pedidos.API.Domain.Entities.PedidoFornecedor", b =>
                {
                    b.Property<int>("PedidoFornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PEDIDO_FORNECEDOR_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoFornecedor")
                        .IsRequired()
                        .HasColumnName("FORNECEDOR_UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PEDIDO_ID");

                    b.HasKey("PedidoFornecedorId");

                    b.HasIndex("PEDIDO_ID");

                    b.ToTable("Pedidos_Fornecedores");
                });

            modelBuilder.Entity("Pedidos.API.Domain.Entities.PedidoItem", b =>
                {
                    b.Property<int>("PedidoItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PEDIDO_ITEM_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoProduto")
                        .IsRequired()
                        .HasColumnName("PRODUTO_UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagemProduto")
                        .IsRequired()
                        .HasColumnName("IMAGEM_PRODUTO");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnName("NOME_PRODUTO");

                    b.Property<int>("PEDIDO_FORNECEDOR_ID");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnName("PRECO_UNITARIO");

                    b.Property<int>("Quantidade")
                        .HasColumnName("QUANTIDADE");

                    b.HasKey("PedidoItemId");

                    b.HasIndex("PEDIDO_FORNECEDOR_ID");

                    b.ToTable("Pedido_Itens");
                });

            modelBuilder.Entity("Pedidos.API.Domain.Entities.Pedido", b =>
                {
                    b.OwnsOne("Pedidos.API.Domain.Entities.Endereco", "EnderecoParaEntrega", b1 =>
                        {
                            b1.Property<int>("PEDIDO_ID");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnName("BAIRRO");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasColumnName("CEP");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnName("CIDADE");

                            b1.Property<string>("Complemento")
                                .HasColumnName("COMPLEMENTO");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnName("LOGRADOURO");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("NUMERO");

                            b1.Property<string>("UF")
                                .IsRequired()
                                .HasColumnName("UF");

                            b1.ToTable("Pedidos_Enderecos");

                            b1.HasOne("Pedidos.API.Domain.Entities.Pedido")
                                .WithOne("EnderecoParaEntrega")
                                .HasForeignKey("Pedidos.API.Domain.Entities.Endereco", "PEDIDO_ID")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Pedidos.API.Domain.Entities.PedidoFornecedor", b =>
                {
                    b.HasOne("Pedidos.API.Domain.Entities.Pedido")
                        .WithMany("FornecedoresDoPedido")
                        .HasForeignKey("PEDIDO_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Pedidos.API.Domain.Entities.DadosEntrega", "DadosDaEntrega", b1 =>
                        {
                            b1.Property<int>("PedidoFornecedorId");

                            b1.Property<int>("PrazoMaximoDeEntrega")
                                .HasColumnName("PRAZO_MAXIMO");

                            b1.Property<int>("PrazoMinimoDeEntrega")
                                .HasColumnName("PRAZO_MINIMO");

                            b1.Property<decimal>("ValorDoFrete")
                                .HasColumnName("VALOR_FRETE");

                            b1.ToTable("Pedidos_Fornecedores");

                            b1.HasOne("Pedidos.API.Domain.Entities.PedidoFornecedor")
                                .WithOne("DadosDaEntrega")
                                .HasForeignKey("Pedidos.API.Domain.Entities.DadosEntrega", "PedidoFornecedorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Pedidos.API.Domain.Entities.PedidoItem", b =>
                {
                    b.HasOne("Pedidos.API.Domain.Entities.PedidoFornecedor")
                        .WithMany("ItensDoPedido")
                        .HasForeignKey("PEDIDO_FORNECEDOR_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
