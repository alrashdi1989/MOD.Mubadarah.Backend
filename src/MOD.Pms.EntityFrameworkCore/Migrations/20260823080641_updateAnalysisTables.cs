using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateAnalysisTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderBusinessAnalysis_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderBusinessAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderTechnicalAnalysis_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderTechnicalAnalysis");

            migrationBuilder.DropIndex(
                name: "IX_Nebars_NebrasTenderTechnicalAnalysis_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderTechnicalAnalysis");

            migrationBuilder.DropIndex(
                name: "IX_Nebars_NebrasTenderBusinessAnalysis_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderBusinessAnalysis");

            migrationBuilder.DropColumn(
                name: "NebrasTenderOfferId",
                table: "Nebars_NebrasTenderTechnicalAnalysis");

            migrationBuilder.DropColumn(
                name: "Scores",
                table: "Nebars_NebrasTenderTechnicalAnalysis");

            migrationBuilder.DropColumn(
                name: "NebrasTenderOfferId",
                table: "Nebars_NebrasTenderBusinessAnalysis");

            migrationBuilder.DropColumn(
                name: "Scores",
                table: "Nebars_NebrasTenderBusinessAnalysis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NebrasTenderOfferId",
                table: "Nebars_NebrasTenderTechnicalAnalysis",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Scores",
                table: "Nebars_NebrasTenderTechnicalAnalysis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NebrasTenderOfferId",
                table: "Nebars_NebrasTenderBusinessAnalysis",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Scores",
                table: "Nebars_NebrasTenderBusinessAnalysis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderTechnicalAnalysis_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderTechnicalAnalysis",
                column: "NebrasTenderOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderBusinessAnalysis_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderBusinessAnalysis",
                column: "NebrasTenderOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderBusinessAnalysis_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderBusinessAnalysis",
                column: "NebrasTenderOfferId",
                principalTable: "Nebars_NebrasTenderOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderTechnicalAnalysis_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderTechnicalAnalysis",
                column: "NebrasTenderOfferId",
                principalTable: "Nebars_NebrasTenderOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
