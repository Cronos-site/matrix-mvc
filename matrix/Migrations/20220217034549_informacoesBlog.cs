using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace matrix.Migrations
{
    public partial class informacoesBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkImagemPostagem",
                table: "Postages",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Resumo",
                table: "Postages",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkImagemPostagem",
                table: "Postages");

            migrationBuilder.DropColumn(
                name: "Resumo",
                table: "Postages");
        }
    }
}
