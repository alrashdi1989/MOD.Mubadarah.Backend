using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addedNewPropertiesinTenderOfferTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Pms_TenderOffers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recommendation",
                table: "Pms_TenderOffers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecommendedBy",
                table: "Pms_TenderOffers",
                type: "uniqueidentifier",
                maxLength: 250,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Pms_TenderOffers");

            migrationBuilder.DropColumn(
                name: "Recommendation",
                table: "Pms_TenderOffers");

            migrationBuilder.DropColumn(
                name: "RecommendedBy",
                table: "Pms_TenderOffers");
        }
    }
}
