using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class solve3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChangeRequestId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_ChangeRequestId",
                table: "Pms_Documents",
                column: "ChangeRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_ChangeRequests_ChangeRequestId",
                table: "Pms_Documents",
                column: "ChangeRequestId",
                principalTable: "Pms_ChangeRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_ChangeRequests_ChangeRequestId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_ChangeRequestId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "ChangeRequestId",
                table: "Pms_Documents");
        }
    }
}
