using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace matrix.Migrations
{
    public partial class relacionamentoPessoaEquipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EquipeId",
                table: "AspNetUsers",
                column: "EquipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Equipe_EquipeId",
                table: "AspNetUsers",
                column: "EquipeId",
                principalTable: "Equipe",
                principalColumn: "IdEquipe",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Equipe_EquipeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EquipeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "AspNetUsers");
        }
    }
}
