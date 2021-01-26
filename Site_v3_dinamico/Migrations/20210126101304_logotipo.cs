using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_v3_dinamico.Migrations
{
    public partial class logotipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "logotipo",
                table: "Formacao",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logotipo",
                table: "Formacao");
        }
    }
}
