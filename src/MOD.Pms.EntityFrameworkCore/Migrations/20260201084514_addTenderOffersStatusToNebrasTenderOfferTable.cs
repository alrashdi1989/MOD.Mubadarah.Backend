using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addTenderOffersStatusToNebrasTenderOfferTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RejectionReasons",
                table: "Nebars_NebrasTenderOffer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenderOfferStatus",
                table: "Nebars_NebrasTenderOffer",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectionReasons",
                table: "Nebars_NebrasTenderOffer");

            migrationBuilder.DropColumn(
                name: "TenderOfferStatus",
                table: "Nebars_NebrasTenderOffer");
        }
    }
}
