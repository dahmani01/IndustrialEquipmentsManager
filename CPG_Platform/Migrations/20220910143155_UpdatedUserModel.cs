using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPG_Platform.Migrations
{
    public partial class UpdatedUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Matricule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Matricule",
                table: "Users",
                newName: "Email");
        }
    }
}
