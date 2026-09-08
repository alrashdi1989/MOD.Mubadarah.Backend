using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateTenderCommitteeMemberAwardTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_TenderCommitteeMemberAward_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                table: "Nebars_TenderCommitteeMemberAward");

            migrationBuilder.DropIndex(
                name: "IX_Nebars_TenderCommitteeMemberAward_NebrasTenderOfferId",
                table: "Nebars_TenderCommitteeMemberAward");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeMemberAward_NebrasTenderOfferId",
                table: "Nebars_TenderCommitteeMemberAward",
                column: "NebrasTenderOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_TenderCommitteeMemberAward_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                table: "Nebars_TenderCommitteeMemberAward",
                column: "NebrasTenderOfferId",
                principalTable: "Nebars_NebrasTenderOffer",
                principalColumn: "Id");
        }
    }
}
