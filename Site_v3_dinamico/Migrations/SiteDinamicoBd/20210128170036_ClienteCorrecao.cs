using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_v3_dinamico.Migrations.SiteDinamicoBd
{
    public partial class ClienteCorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encomenda_Cliente_1_ClienteId",
                table: "Encomenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente_1",
                table: "Cliente_1");

            migrationBuilder.RenameTable(
                name: "Cliente_1",
                newName: "Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Encomenda_Cliente_ClienteId",
                table: "Encomenda",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encomenda_Cliente_ClienteId",
                table: "Encomenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Cliente_1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente_1",
                table: "Cliente_1",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Encomenda_Cliente_1_ClienteId",
                table: "Encomenda",
                column: "ClienteId",
                principalTable: "Cliente_1",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
