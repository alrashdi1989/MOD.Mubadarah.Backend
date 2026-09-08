using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class createNebrasAttachmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NebrasTenderAttachmentId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTenderAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderAttachmentsTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Nebars_NebrasTenderAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                        column: x => x.TenderAttachmentsTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderAttachment_Pms_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Pms_Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_NebrasTenderAttachmentId",
                table: "Pms_Documents",
                column: "NebrasTenderAttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderAttachment_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                column: "TenderAttachmentsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderAttachment_TenderId",
                table: "Nebars_NebrasTenderAttachment",
                column: "TenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderAttachment_NebrasTenderAttachmentId",
                table: "Pms_Documents",
                column: "NebrasTenderAttachmentId",
                principalTable: "Nebars_NebrasTenderAttachment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderAttachment_NebrasTenderAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTenderAttachment");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_NebrasTenderAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "NebrasTenderAttachmentId",
                table: "Pms_Documents");
        }
    }
}
