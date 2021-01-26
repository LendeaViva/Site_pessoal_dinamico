using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_v3_dinamico.Migrations
{
    public partial class website : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "website",
                table: "Formacao",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "website",
                table: "Formacao");
        }
    }
}
