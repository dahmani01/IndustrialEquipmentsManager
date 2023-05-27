using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPG_Platform.Migrations
{
    public partial class testDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Machines_MachineId",
                table: "Documents");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "Documents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Machines_MachineId",
                table: "Documents",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Machines_MachineId",
                table: "Documents");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Machines_MachineId",
                table: "Documents",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
