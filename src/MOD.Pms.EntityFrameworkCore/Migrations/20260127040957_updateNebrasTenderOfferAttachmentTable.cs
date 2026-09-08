using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateNebrasTenderOfferAttachmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderOfferAttachment_Nebars_NebrasTenderOffer_NebrasTenderId",
                table: "Nebars_NebrasTenderOfferAttachment");

            migrationBuilder.DropIndex(
                name: "IX_Nebars_NebrasTenderOfferAttachment_NebrasTenderId",
                table: "Nebars_NebrasTenderOfferAttachment");

            migrationBuilder.DropColumn(
                name: "NebrasTenderId",
                table: "Nebars_NebrasTenderOfferAttachment");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderOfferAttachment_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderOfferAttachment",
                column: "NebrasTenderOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderOfferAttachment_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderOfferAttachment",
                column: "NebrasTenderOfferId",
                principalTable: "Nebars_NebrasTenderOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderOfferAttachment_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderOfferAttachment");

            migrationBuilder.DropIndex(
                name: "IX_Nebars_NebrasTenderOfferAttachment_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderOfferAttachment");

            migrationBuilder.AddColumn<Guid>(
                name: "NebrasTenderId",
                table: "Nebars_NebrasTenderOfferAttachment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderOfferAttachment_NebrasTenderId",
                table: "Nebars_NebrasTenderOfferAttachment",
                column: "NebrasTenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderOfferAttachment_Nebars_NebrasTenderOffer_NebrasTenderId",
                table: "Nebars_NebrasTenderOfferAttachment",
                column: "NebrasTenderId",
                principalTable: "Nebars_NebrasTenderOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
