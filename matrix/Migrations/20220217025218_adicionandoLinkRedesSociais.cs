using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace matrix.Migrations
{
    public partial class adicionandoLinkRedesSociais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "linkGitHub",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "linkLinkedin",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "linkGitHub",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "linkLinkedin",
                table: "AspNetUsers");
        }
    }
}
