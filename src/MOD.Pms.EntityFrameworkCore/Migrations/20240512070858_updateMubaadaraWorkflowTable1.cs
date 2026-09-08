using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateMubaadaraWorkflowTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendDateTime",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Mub_MubaadarasWorkflow",
                newName: "ApprovalStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApprovalStatus",
                table: "Mub_MubaadarasWorkflow",
                newName: "IsApproved");

            migrationBuilder.AddColumn<DateTime>(
                name: "SendDateTime",
                table: "Mub_MubaadarasWorkflow",
                type: "datetime2",
                nullable: true);
        }
    }
}
