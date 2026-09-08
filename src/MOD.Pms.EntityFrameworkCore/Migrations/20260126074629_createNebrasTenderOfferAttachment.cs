using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class createNebrasTenderOfferAttachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NebrasTenderOfferAttachmentId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTenderOfferAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderOfferAttachmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_NebrasTenderOfferAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderOfferAttachment_Nebars_NebrasTenderOffer_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTenderOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderOfferAttachment_Pms_Lookups_NebrasTenderOfferAttachmentTypeId",
                        column: x => x.NebrasTenderOfferAttachmentTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_NebrasTenderOfferAttachmentId",
                table: "Pms_Documents",
                column: "NebrasTenderOfferAttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderOfferAttachment_NebrasTenderId",
                table: "Nebars_NebrasTenderOfferAttachment",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderOfferAttachment_NebrasTenderOfferAttachmentTypeId",
                table: "Nebars_NebrasTenderOfferAttachment",
                column: "NebrasTenderOfferAttachmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderOfferAttachment_NebrasTenderOfferAttachmentId",
                table: "Pms_Documents",
                column: "NebrasTenderOfferAttachmentId",
                principalTable: "Nebars_NebrasTenderOfferAttachment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderOfferAttachment_NebrasTenderOfferAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTenderOfferAttachment");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_NebrasTenderOfferAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "NebrasTenderOfferAttachmentId",
                table: "Pms_Documents");
        }
    }
}
