using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_v3_dinamico.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competencias",
                columns: table => new
                {
                    CompetenciasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeComp = table.Column<string>(nullable: true),
                    descricaoComp = table.Column<string>(nullable: true),
                    nomeLinguagem = table.Column<string>(nullable: true),
                    nivelComp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencias", x => x.CompetenciasId);
                });

            migrationBuilder.CreateTable(
                name: "Exp_profissional",
                columns: table => new
                {
                    Exp_profissionalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeEmpresa = table.Column<string>(nullable: true),
                    dataInicio = table.Column<int>(nullable: false),
                    dataFim = table.Column<int>(nullable: false),
                    funcao = table.Column<int>(nullable: false),
                    descricaoFuncao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exp_profissional", x => x.Exp_profissionalId);
                });

            migrationBuilder.CreateTable(
                name: "Formacao",
                columns: table => new
                {
                    FormacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeInstituicao = table.Column<string>(nullable: true),
                    dataIniciodataFim = table.Column<string>(nullable: true),
                    nomeCurso = table.Column<string>(nullable: true),
                    conteudos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacao", x => x.FormacaoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competencias");

            migrationBuilder.DropTable(
                name: "Exp_profissional");

            migrationBuilder.DropTable(
                name: "Formacao");
        }
    }
}
