using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domus_Projeto.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToFinanca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacidade",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Moradores");

            migrationBuilder.DropColumn(
                name: "DataVencimento",
                table: "Contas");

            migrationBuilder.RenameColumn(
                name: "DataVisita",
                table: "Visitantes",
                newName: "DataHora");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Reservas",
                newName: "DataHora");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Moradores",
                newName: "Bloco");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Contas",
                newName: "Vencimento");

            migrationBuilder.AddColumn<int>(
                name: "MoradorId",
                table: "Visitantes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoradorId",
                table: "Reservas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoradorId",
                table: "Contas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Paga",
                table: "Contas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Financas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    MoradorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Remetente = table.Column<string>(type: "TEXT", nullable: false),
                    Conteudo = table.Column<string>(type: "TEXT", nullable: false),
                    EnviadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Lida = table.Column<bool>(type: "INTEGER", nullable: false),
                    MoradorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagens_Moradores_MoradorId",
                        column: x => x.MoradorId,
                        principalTable: "Moradores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_MoradorId",
                table: "Reservas",
                column: "MoradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_MoradorId",
                table: "Contas",
                column: "MoradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_MoradorId",
                table: "Mensagens",
                column: "MoradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Moradores_MoradorId",
                table: "Contas",
                column: "MoradorId",
                principalTable: "Moradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Moradores_MoradorId",
                table: "Reservas",
                column: "MoradorId",
                principalTable: "Moradores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Moradores_MoradorId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Moradores_MoradorId",
                table: "Reservas");

            migrationBuilder.DropTable(
                name: "Financas");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_MoradorId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_MoradorId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "MoradorId",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "MoradorId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "MoradorId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Paga",
                table: "Contas");

            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Visitantes",
                newName: "DataVisita");

            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Reservas",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "Bloco",
                table: "Moradores",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "Vencimento",
                table: "Contas",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "Capacidade",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Moradores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVencimento",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
