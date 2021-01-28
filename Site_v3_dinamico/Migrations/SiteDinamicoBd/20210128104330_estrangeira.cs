using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_v3_dinamico.Migrations.SiteDinamicoBd
{
    public partial class estrangeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encomenda_Cliente_1_ClienteId",
                table: "Encomenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Encomenda_Servicos_ServicosId",
                table: "Encomenda");

            migrationBuilder.AddForeignKey(
                name: "FK_Encomenda_Cliente_1_ClienteId",
                table: "Encomenda",
                column: "ClienteId",
                principalTable: "Cliente_1",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Encomenda_Servicos_ServicosId",
                table: "Encomenda",
                column: "ServicosId",
                principalTable: "Servicos",
                principalColumn: "ServicosId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encomenda_Cliente_1_ClienteId",
                table: "Encomenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Encomenda_Servicos_ServicosId",
                table: "Encomenda");

            migrationBuilder.AddForeignKey(
                name: "FK_Encomenda_Cliente_1_ClienteId",
                table: "Encomenda",
                column: "ClienteId",
                principalTable: "Cliente_1",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encomenda_Servicos_ServicosId",
                table: "Encomenda",
                column: "ServicosId",
                principalTable: "Servicos",
                principalColumn: "ServicosId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
