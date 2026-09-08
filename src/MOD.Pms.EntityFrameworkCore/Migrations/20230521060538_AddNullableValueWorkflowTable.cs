using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class AddNullableValueWorkflowTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Workflows_Pms_Lookups_LookupId",
                table: "Pms_Workflows");

            migrationBuilder.AlterColumn<Guid>(
                name: "LookupId",
                table: "Pms_Workflows",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Classification",
                table: "Pms_Workflows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Workflows_Pms_Lookups_LookupId",
                table: "Pms_Workflows",
                column: "LookupId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Workflows_Pms_Lookups_LookupId",
                table: "Pms_Workflows");

            migrationBuilder.AlterColumn<Guid>(
                name: "LookupId",
                table: "Pms_Workflows",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Classification",
                table: "Pms_Workflows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Workflows_Pms_Lookups_LookupId",
                table: "Pms_Workflows",
                column: "LookupId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
