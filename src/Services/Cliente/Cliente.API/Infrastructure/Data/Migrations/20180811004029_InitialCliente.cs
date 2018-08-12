using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cliente.API.Infrastructure.Data.Migrations
{
    public partial class InitialCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CLIENTE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CONTA_UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMAIL = table.Column<string>(nullable: false),
                    NOME = table.Column<string>(nullable: false),
                    SOBRENOME = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CLIENTE_ID);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    ENDERECO_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BAIRRO = table.Column<string>(nullable: false),
                    CEP = table.Column<string>(nullable: false),
                    CLIENTE_ID = table.Column<int>(nullable: false),
                    CIDADE = table.Column<string>(nullable: false),
                    COMPLEMENTO = table.Column<string>(nullable: true),
                    DESCRICAO = table.Column<string>(nullable: false),
                    ENDERECO_PRINCIPAL = table.Column<bool>(nullable: false),
                    LOGRADOURO = table.Column<string>(nullable: false),
                    NUMERO = table.Column<string>(nullable: false),
                    UF = table.Column<string>(nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.ENDERECO_ID);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_CLIENTE_ID",
                        column: x => x.CLIENTE_ID,
                        principalTable: "Clientes",
                        principalColumn: "CLIENTE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CONTA_UID",
                table: "Clientes",
                column: "CONTA_UID");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_CLIENTE_ID",
                table: "Enderecos",
                column: "CLIENTE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
