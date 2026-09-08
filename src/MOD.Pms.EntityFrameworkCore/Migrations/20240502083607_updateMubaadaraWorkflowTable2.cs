using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateMubaadaraWorkflowTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "Mub_MubaadarasWorkflow",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NewValue",
                table: "Mub_MubaadarasWorkflow",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Mub_MubaadarasWorkflow",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousValue",
                table: "Mub_MubaadarasWorkflow",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropColumn(
                name: "NewValue",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropColumn(
                name: "PreviousValue",
                table: "Mub_MubaadarasWorkflow");
        }
    }
}
