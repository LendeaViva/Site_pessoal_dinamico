using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_v3_dinamico.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Telemóvel = table.Column<string>(maxLength: 9, nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

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
                    nomeEmpresa = table.Column<string>(maxLength: 200, nullable: false),
                    dataInicio = table.Column<DateTime>(nullable: false),
                    dataFim = table.Column<DateTime>(nullable: false),
                    funcao = table.Column<string>(nullable: false),
                    descricaoFuncao = table.Column<string>(nullable: true),
                    logotipo = table.Column<byte[]>(nullable: true)
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
                    nomeInstituicao = table.Column<string>(maxLength: 200, nullable: false),
                    website = table.Column<string>(nullable: true),
                    logotipoForm = table.Column<byte[]>(nullable: true),
                    dataInicio = table.Column<DateTime>(nullable: false),
                    dataFim = table.Column<DateTime>(nullable: false),
                    nomeCurso = table.Column<string>(nullable: false),
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
                    nomeInstituicaoComp = table.Column<string>(maxLength: 200, nullable: false),
                    dataIniciodataFimComp = table.Column<DateTime>(nullable: false),
                    nomeCursoComp = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormacaoComp", x => x.FormacaoCompId);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    imagem = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicosId);
                });

            migrationBuilder.CreateTable(
                name: "SobreMim",
                columns: table => new
                {
                    SobreMimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SobreMim", x => x.SobreMimId);
                });

            migrationBuilder.CreateTable(
                name: "SobreMimImg",
                columns: table => new
                {
                    SobreMimImgId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imagem = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SobreMimImg", x => x.SobreMimImgId);
                });

            migrationBuilder.CreateTable(
                name: "Encomenda",
                columns: table => new
                {
                    EncomendaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataEncomenda = table.Column<DateTime>(nullable: false),
                    detalhes = table.Column<string>(nullable: true),
                    respondido = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    ServicosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encomenda", x => x.EncomendaId);
                    table.ForeignKey(
                        name: "FK_Encomenda_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Encomenda_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "ServicosId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Competencias");

            migrationBuilder.DropTable(
                name: "Encomenda");

            migrationBuilder.DropTable(
                name: "Exp_Profissional");

            migrationBuilder.DropTable(
                name: "Formacao");

            migrationBuilder.DropTable(
                name: "FormacaoComp");

            migrationBuilder.DropTable(
                name: "SobreMim");

            migrationBuilder.DropTable(
                name: "SobreMimImg");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Servicos");
        }
    }
}
