using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_v3_dinamico.Migrations.SiteDinamicoBd
{
    public partial class encomenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teste",
                table: "Servicos");

            migrationBuilder.CreateTable(
                name: "Encomenda",
                columns: table => new
                {
                    EncomendaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    ServicosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encomenda", x => x.EncomendaId);
                    table.ForeignKey(
                        name: "FK_Encomenda_Cliente_1_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente_1",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Encomenda_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "ServicosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Encomenda_ClienteId",
                table: "Encomenda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Encomenda_ServicosId",
                table: "Encomenda",
                column: "ServicosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Encomenda");

            migrationBuilder.AddColumn<string>(
                name: "teste",
                table: "Servicos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
