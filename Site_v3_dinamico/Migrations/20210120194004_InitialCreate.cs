using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_v3_dinamico.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeInstituicao = table.Column<string>(nullable: true),
                    dataIniciodataFim = table.Column<string>(nullable: true),
                    nomeCurso = table.Column<string>(nullable: true),
                    conteudos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formacao");
        }
    }
}
