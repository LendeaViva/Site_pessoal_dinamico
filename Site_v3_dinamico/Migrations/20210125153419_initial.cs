using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_v3_dinamico.Migrations
{
    public partial class initial : Migration
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
                name: "Exp_Profissional",
                columns: table => new
                {
                    Exp_ProfissionalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeEmpresa = table.Column<string>(nullable: true),
                    dataInicio = table.Column<int>(nullable: false),
                    dataFim = table.Column<int>(nullable: false),
                    funcao = table.Column<int>(nullable: false),
                    descricaoFuncao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exp_Profissional", x => x.Exp_ProfissionalId);
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
                name: "Competencias");

            migrationBuilder.DropTable(
                name: "Exp_Profissional");

            migrationBuilder.DropTable(
                name: "Formacao");

            migrationBuilder.DropTable(
                name: "FormacaoComp");
        }
    }
}
