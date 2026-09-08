using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class lastUpdateNebrasAttachmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderOfferAttachment_Pms_Lookups_NebrasTenderOfferAttachmentTypeId",
                table: "Nebars_NebrasTenderOfferAttachment");

            migrationBuilder.DropIndex(
                name: "IX_Nebars_NebrasTenderOfferAttachment_NebrasTenderOfferAttachmentTypeId",
                table: "Nebars_NebrasTenderOfferAttachment");

            migrationBuilder.DropIndex(
                name: "IX_Nebars_NebrasTenderAttachment_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.DropColumn(
                name: "ReferenceNumber",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.AlterColumn<Guid>(
                name: "NebrasTenderOfferAttachmentTypeId",
                table: "Nebars_NebrasTenderOfferAttachment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "NebrasTenderOfferAttachmentTypeId",
                table: "Nebars_NebrasTenderOfferAttachment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNumber",
                table: "Nebars_NebrasTenderAttachment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderOfferAttachment_NebrasTenderOfferAttachmentTypeId",
                table: "Nebars_NebrasTenderOfferAttachment",
                column: "NebrasTenderOfferAttachmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderAttachment_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                column: "TenderAttachmentsTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                column: "TenderAttachmentsTypeId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderOfferAttachment_Pms_Lookups_NebrasTenderOfferAttachmentTypeId",
                table: "Nebars_NebrasTenderOfferAttachment",
                column: "NebrasTenderOfferAttachmentTypeId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");
        }
    }
}
