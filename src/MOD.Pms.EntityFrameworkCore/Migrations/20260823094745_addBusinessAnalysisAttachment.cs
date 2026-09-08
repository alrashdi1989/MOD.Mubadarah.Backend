using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addBusinessAnalysisAttachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderTechnicalAnalysis_NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.RenameColumn(
                name: "NebrasTenderOfferTechnicalAnalysisId",
                table: "Pms_Documents",
                newName: "NebrasTenderBusinessAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_NebrasTenderBusinessAnalysisId",
                table: "Pms_Documents",
                column: "NebrasTenderBusinessAnalysisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderBusinessAnalysis_NebrasTenderBusinessAnalysisId",
                table: "Pms_Documents",
                column: "NebrasTenderBusinessAnalysisId",
                principalTable: "Nebars_NebrasTenderBusinessAnalysis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderTechnicalAnalysis_NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents",
                column: "NebrasTenderTechnicalAnalysisId",
                principalTable: "Nebars_NebrasTenderTechnicalAnalysis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderBusinessAnalysis_NebrasTenderBusinessAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderTechnicalAnalysis_NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_NebrasTenderBusinessAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.RenameColumn(
                name: "NebrasTenderBusinessAnalysisId",
                table: "Pms_Documents",
                newName: "NebrasTenderOfferTechnicalAnalysisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderTechnicalAnalysis_NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents",
                column: "NebrasTenderTechnicalAnalysisId",
                principalTable: "Nebars_NebrasTenderTechnicalAnalysis",
                principalColumn: "Id");
        }
    }
}
