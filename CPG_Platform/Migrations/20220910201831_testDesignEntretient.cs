using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPG_Platform.Migrations
{
    public partial class testDesignEntretient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entretients_Users_UserId",
                table: "Entretients");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Entretients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Entretients_Users_UserId",
                table: "Entretients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entretients_Users_UserId",
                table: "Entretients");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Entretients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entretients_Users_UserId",
                table: "Entretients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
