using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addTenderOfferTechnicalAnalysisIdToTableDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NebrasTenderOfferTechnicalAnalysisId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents",
                column: "NebrasTenderTechnicalAnalysisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderTechnicalAnalysis_NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents",
                column: "NebrasTenderTechnicalAnalysisId",
                principalTable: "Nebars_NebrasTenderTechnicalAnalysis",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderTechnicalAnalysis_NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "NebrasTenderOfferTechnicalAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents");
        }
    }
}
