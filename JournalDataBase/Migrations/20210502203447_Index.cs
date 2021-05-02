using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalDataBase.Migrations
{
    public partial class Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_NameRole",
                table: "Roles",
                column: "NameRole",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_NameGroup",
                table: "Groups",
                column: "NameGroup",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_NameDiscipline",
                table: "Disciplines",
                column: "NameDiscipline",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_NameRole",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Groups_NameGroup",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_NameDiscipline",
                table: "Disciplines");
        }
    }
}
