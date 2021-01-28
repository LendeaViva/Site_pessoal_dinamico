using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_v3_dinamico.Migrations.SiteDinamicoBd
{
    public partial class dataAtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataEncomenda",
                table: "Encomenda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dataEncomenda",
                table: "Encomenda",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
