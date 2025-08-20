using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Locadora.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Entregador",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    CNPJ = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NumeroCNH = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    TipoCNH = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ImagemCNH = table.Column<string>(type: "text", nullable: true),
                    CaminhoImagemCNH = table.Column<string>(type: "text", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Entregador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Evento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Payload = table.Column<string>(type: "text", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Evento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Moto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ano = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Modelo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Placa = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Moto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Plano",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dias = table.Column<int>(type: "integer", nullable: false),
                    ValorDia = table.Column<decimal>(type: "numeric", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Plano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Locacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataPrevisaoTermino = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    EntregadorId = table.Column<long>(type: "bigint", nullable: false),
                    PlanoId = table.Column<long>(type: "bigint", nullable: false),
                    MotoId = table.Column<long>(type: "bigint", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Locacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Locacao_Tb_Entregador_EntregadorId",
                        column: x => x.EntregadorId,
                        principalTable: "Tb_Entregador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Locacao_Tb_Moto_MotoId",
                        column: x => x.MotoId,
                        principalTable: "Tb_Moto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Locacao_Tb_Plano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Tb_Plano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tb_Plano",
                columns: new[] { "Id", "Dias", "Nome", "ValorDia" },
                values: new object[,]
                {
                    { 1L, 7, "Plano 7", 30.00m },
                    { 2L, 15, "Plano 15", 28.00m },
                    { 3L, 30, "Plano 30", 22.00m },
                    { 4L, 45, "Plano 45", 20.00m },
                    { 5L, 50, "Plano 50", 18.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Entregador_CNPJ",
                table: "Tb_Entregador",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Locacao_EntregadorId",
                table: "Tb_Locacao",
                column: "EntregadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Locacao_MotoId",
                table: "Tb_Locacao",
                column: "MotoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Locacao_PlanoId",
                table: "Tb_Locacao",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Moto_Placa",
                table: "Tb_Moto",
                column: "Placa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Evento");

            migrationBuilder.DropTable(
                name: "Tb_Locacao");

            migrationBuilder.DropTable(
                name: "Tb_Entregador");

            migrationBuilder.DropTable(
                name: "Tb_Moto");

            migrationBuilder.DropTable(
                name: "Tb_Plano");
        }
    }
}
