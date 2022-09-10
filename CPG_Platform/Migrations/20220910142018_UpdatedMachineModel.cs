﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPG_Platform.Migrations
{
    public partial class UpdatedMachineModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Services_ServiceId",
                table: "Machines");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Machines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Services_ServiceId",
                table: "Machines",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Services_ServiceId",
                table: "Machines");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Machines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Services_ServiceId",
                table: "Machines",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
