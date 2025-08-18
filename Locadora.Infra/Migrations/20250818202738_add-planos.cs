using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addplanos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Locacao_Tb_Entregador_EntregadorId",
                table: "Tb_Locacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Locacao_Tb_Moto_MotoId",
                table: "Tb_Locacao");

            migrationBuilder.AddColumn<long>(
                name: "PlanoId",
                table: "Tb_Locacao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Locacao_PlanoId",
                table: "Tb_Locacao",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Locacao_Tb_Entregador_EntregadorId",
                table: "Tb_Locacao",
                column: "EntregadorId",
                principalTable: "Tb_Entregador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Locacao_Tb_Moto_MotoId",
                table: "Tb_Locacao",
                column: "MotoId",
                principalTable: "Tb_Moto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Locacao_Tb_Plano_PlanoId",
                table: "Tb_Locacao",
                column: "PlanoId",
                principalTable: "Tb_Plano",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Locacao_Tb_Entregador_EntregadorId",
                table: "Tb_Locacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Locacao_Tb_Moto_MotoId",
                table: "Tb_Locacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Locacao_Tb_Plano_PlanoId",
                table: "Tb_Locacao");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Locacao_PlanoId",
                table: "Tb_Locacao");

            migrationBuilder.DropColumn(
                name: "PlanoId",
                table: "Tb_Locacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Locacao_Tb_Entregador_EntregadorId",
                table: "Tb_Locacao",
                column: "EntregadorId",
                principalTable: "Tb_Entregador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Locacao_Tb_Moto_MotoId",
                table: "Tb_Locacao",
                column: "MotoId",
                principalTable: "Tb_Moto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
