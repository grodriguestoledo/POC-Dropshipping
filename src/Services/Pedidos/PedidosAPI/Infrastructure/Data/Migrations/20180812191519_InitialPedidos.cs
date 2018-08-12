using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pedidos.API.Infrastructure.Data.Migrations
{
    public partial class InitialPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PEDIDO_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CLIENTE_UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PAGAMENTO_UID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATA_ATUALIZACAO_STATUS = table.Column<DateTime>(nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(nullable: false),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PEDIDO_ID);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos_Enderecos",
                columns: table => new
                {
                    PEDIDO_ID = table.Column<int>(nullable: false),
                    BAIRRO = table.Column<string>(nullable: false),
                    CEP = table.Column<string>(nullable: false),
                    CIDADE = table.Column<string>(nullable: false),
                    COMPLEMENTO = table.Column<string>(nullable: true),
                    LOGRADOURO = table.Column<string>(nullable: false),
                    NUMERO = table.Column<string>(nullable: false),
                    UF = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos_Enderecos", x => x.PEDIDO_ID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Enderecos_Pedidos_PEDIDO_ID",
                        column: x => x.PEDIDO_ID,
                        principalTable: "Pedidos",
                        principalColumn: "PEDIDO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos_Fornecedores",
                columns: table => new
                {
                    PEDIDO_FORNECEDOR_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FORNECEDOR_UID = table.Column<string>(type: "uniqueidentifier", nullable: false),
                    PEDIDO_ID = table.Column<int>(nullable: false),
                    PRAZO_MAXIMO = table.Column<int>(nullable: false),
                    PRAZO_MINIMO = table.Column<int>(nullable: false),
                    VALOR_FRETE = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos_Fornecedores", x => x.PEDIDO_FORNECEDOR_ID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Fornecedores_Pedidos_PEDIDO_ID",
                        column: x => x.PEDIDO_ID,
                        principalTable: "Pedidos",
                        principalColumn: "PEDIDO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido_Itens",
                columns: table => new
                {
                    PEDIDO_ITEM_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PRODUTO_UID = table.Column<string>(type: "uniqueidentifier", nullable: false),
                    IMAGEM_PRODUTO = table.Column<string>(nullable: false),
                    NOME_PRODUTO = table.Column<string>(nullable: false),
                    PEDIDO_FORNECEDOR_ID = table.Column<int>(nullable: false),
                    PRECO_UNITARIO = table.Column<decimal>(nullable: false),
                    QUANTIDADE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido_Itens", x => x.PEDIDO_ITEM_ID);
                    table.ForeignKey(
                        name: "FK_Pedido_Itens_Pedidos_Fornecedores_PEDIDO_FORNECEDOR_ID",
                        column: x => x.PEDIDO_FORNECEDOR_ID,
                        principalTable: "Pedidos_Fornecedores",
                        principalColumn: "PEDIDO_FORNECEDOR_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Itens_PEDIDO_FORNECEDOR_ID",
                table: "Pedido_Itens",
                column: "PEDIDO_FORNECEDOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Fornecedores_PEDIDO_ID",
                table: "Pedidos_Fornecedores",
                column: "PEDIDO_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido_Itens");

            migrationBuilder.DropTable(
                name: "Pedidos_Enderecos");

            migrationBuilder.DropTable(
                name: "Pedidos_Fornecedores");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
