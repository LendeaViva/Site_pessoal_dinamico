using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_v3_dinamico.Migrations
{
    public partial class FormacaoComo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormacaoComp",
                columns: table => new
                {
                    FormacaoCompId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeInstituicaoComp = table.Column<string>(nullable: true),
                    dataIniciodataFimComp = table.Column<string>(nullable: true),
                    nomeCursoComp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormacaoComp", x => x.FormacaoCompId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormacaoComp");
        }
    }
}
