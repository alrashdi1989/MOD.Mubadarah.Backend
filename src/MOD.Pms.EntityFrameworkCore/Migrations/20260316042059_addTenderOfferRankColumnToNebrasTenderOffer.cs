using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addTenderOfferRankColumnToNebrasTenderOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenderOfferRank",
                table: "Nebars_NebrasTenderOffer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenderOfferType",
                table: "Nebars_NebrasTenderOffer",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenderOfferRank",
                table: "Nebars_NebrasTenderOffer");

            migrationBuilder.DropColumn(
                name: "TenderOfferType",
                table: "Nebars_NebrasTenderOffer");
        }
    }
}
