using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace matrix.Migrations
{
    public partial class fechandoEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postages_AspNetUsers_PessoaId",
                table: "Postages");

            migrationBuilder.DropColumn(
                name: "IdPessoa",
                table: "Postages");

            migrationBuilder.UpdateData(
                table: "Postages",
                keyColumn: "PessoaId",
                keyValue: null,
                column: "PessoaId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PessoaId",
                table: "Postages",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    IdEquipe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeEquipe = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.IdEquipe);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Postages_AspNetUsers_PessoaId",
                table: "Postages",
                column: "PessoaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postages_AspNetUsers_PessoaId",
                table: "Postages");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.AlterColumn<string>(
                name: "PessoaId",
                table: "Postages",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "IdPessoa",
                table: "Postages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Postages_AspNetUsers_PessoaId",
                table: "Postages",
                column: "PessoaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
