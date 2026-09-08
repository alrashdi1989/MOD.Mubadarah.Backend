using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class createNebrasTenderSelectedSupplierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderAttachment_NebrasTenderAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.RenameColumn(
                name: "NebrasTenderAttachmentId",
                table: "Pms_Documents",
                newName: "TenderAttachmentsTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Pms_Documents_NebrasTenderAttachmentId",
                table: "Pms_Documents",
                newName: "IX_Pms_Documents_TenderAttachmentsTypeId");

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTenderSelectedSupplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NebrasId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Nebars_NebrasTenderSelectedSupplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderSelectedSupplier_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderSelectedSupplier_NebrasTenderId",
                table: "Nebars_NebrasTenderSelectedSupplier",
                column: "NebrasTenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderAttachment_TenderAttachmentsTypeId",
                table: "Pms_Documents",
                column: "TenderAttachmentsTypeId",
                principalTable: "Nebars_NebrasTenderAttachment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderAttachment_TenderAttachmentsTypeId",
                table: "Pms_Documents");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTenderSelectedSupplier");

            migrationBuilder.RenameColumn(
                name: "TenderAttachmentsTypeId",
                table: "Pms_Documents",
                newName: "NebrasTenderAttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Pms_Documents_TenderAttachmentsTypeId",
                table: "Pms_Documents",
                newName: "IX_Pms_Documents_NebrasTenderAttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderAttachment_NebrasTenderAttachmentId",
                table: "Pms_Documents",
                column: "NebrasTenderAttachmentId",
                principalTable: "Nebars_NebrasTenderAttachment",
                principalColumn: "Id");
        }
    }
}
