using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Autenticacao.API.Infrastructure.Data.Migrations.AutenticacaoDb
{
    public partial class AutenticacaoInicialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    CONTA_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LOGIN = table.Column<string>(nullable: false),
                    NOME = table.Column<string>(nullable: false),
                    SENHA = table.Column<string>(nullable: false),
                    SOBRENOME = table.Column<string>(nullable: false),
                    TIPO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.CONTA_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_UID",
                table: "Conta",
                column: "UID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");
        }
    }
}
