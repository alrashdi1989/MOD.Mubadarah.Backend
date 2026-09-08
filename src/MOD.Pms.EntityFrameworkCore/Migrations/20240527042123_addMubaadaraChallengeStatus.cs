using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addMubaadaraChallengeStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MubaadaraDetailId",
                table: "Mub_MubaadarasWorkflow",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApproveStatus",
                table: "Mub_MubaadaraDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mub_MubaadarasWorkflow_Mub_MubaadaraDetails_MubaadaraDetailId",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropIndex(
                name: "IX_Mub_MubaadarasWorkflow_MubaadaraDetailId",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropColumn(
                name: "MubaadaraDetailId",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropColumn(
                name: "ApproveStatus",
                table: "Mub_MubaadaraDetails");
        }
    }
}
