using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationToWorkFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ApprovalId",
                table: "Pms_Workflows",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Workflows_ApprovalId",
                table: "Pms_Workflows",
                column: "ApprovalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Workflows_Pms_Approvals_ApprovalId",
                table: "Pms_Workflows",
                column: "ApprovalId",
                principalTable: "Pms_Approvals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Workflows_Pms_Approvals_ApprovalId",
                table: "Pms_Workflows");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Workflows_ApprovalId",
                table: "Pms_Workflows");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApprovalId",
                table: "Pms_Workflows",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
