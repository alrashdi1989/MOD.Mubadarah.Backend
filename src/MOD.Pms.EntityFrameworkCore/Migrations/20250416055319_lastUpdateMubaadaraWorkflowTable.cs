using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class lastUpdateMubaadaraWorkflowTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mub_MubaadarasWorkflow_Mub_MubaadaraDetails_MubaadaraDetailId",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropIndex(
                name: "IX_Mub_MubaadarasWorkflow_MubaadaraDetailId",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropColumn(
                name: "MubaadaraRequests",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropColumn(
                name: "NewEndDate",
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

            migrationBuilder.DropColumn(
                name: "WorkflowStatus",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.RenameColumn(
                name: "MubaadaraDetailId",
                table: "Mub_MubaadarasWorkflow",
                newName: "ApprovalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApprovalId",
                table: "Mub_MubaadarasWorkflow",
                newName: "MubaadaraDetailId");

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedBy",
                table: "Mub_MubaadarasWorkflow",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MubaadaraRequests",
                table: "Mub_MubaadarasWorkflow",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "NewEndDate",
                table: "Mub_MubaadarasWorkflow",
                type: "datetime2",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "WorkflowStatus",
                table: "Mub_MubaadarasWorkflow",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mub_MubaadarasWorkflow_MubaadaraDetailId",
                table: "Mub_MubaadarasWorkflow",
                column: "MubaadaraDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mub_MubaadarasWorkflow_Mub_MubaadaraDetails_MubaadaraDetailId",
                table: "Mub_MubaadarasWorkflow",
                column: "MubaadaraDetailId",
                principalTable: "Mub_MubaadaraDetails",
                principalColumn: "Id");
        }
    }
}
