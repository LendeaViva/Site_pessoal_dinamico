using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_v3_dinamico.Migrations
{
    public partial class competencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competencias");

            migrationBuilder.AlterColumn<byte[]>(
                name: "imagem",
                table: "SobreMimImg",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.CreateTable(
                name: "CompetenciasD",
                columns: table => new
                {
                    CompetenciasDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeComp = table.Column<string>(nullable: true),
                    nivelComp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciasD", x => x.CompetenciasDId);
                });

            migrationBuilder.CreateTable(
                name: "CompetenciasF",
                columns: table => new
                {
                    CompetenciasFId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeComp = table.Column<string>(nullable: true),
                    nivelComp = table.Column<int>(nullable: false),
                    logo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciasF", x => x.CompetenciasFId);
                });

            migrationBuilder.CreateTable(
                name: "CompetenciasP",
                columns: table => new
                {
                    CompetenciasPId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeComp = table.Column<string>(nullable: true),
                    descricaoComp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciasP", x => x.CompetenciasPId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenciasD");

            migrationBuilder.DropTable(
                name: "CompetenciasF");

            migrationBuilder.DropTable(
                name: "CompetenciasP");

            migrationBuilder.AlterColumn<byte[]>(
                name: "imagem",
                table: "SobreMimImg",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Competencias",
                columns: table => new
                {
                    CompetenciasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricaoComp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nivelComp = table.Column<int>(type: "int", nullable: false),
                    nomeComp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomeLinguagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencias", x => x.CompetenciasId);
                });
        }
    }
}
