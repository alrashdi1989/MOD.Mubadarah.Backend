using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class UpdataNebrasTenderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Tenders_TenderId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.RenameColumn(
                name: "TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                newName: "TenderAttachmentsTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Nebars_NebrasTenderAttachment_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                newName: "IX_Nebars_NebrasTenderAttachment_TenderAttachmentsTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Nebars_NebrasTender_TenderId",
                table: "Nebars_NebrasTenderAttachment",
                column: "TenderId",
                principalTable: "Nebars_NebrasTender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                column: "TenderAttachmentsTypeId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Nebars_NebrasTender_TenderId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.RenameColumn(
                name: "TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                newName: "TenderAttachmentsTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Nebars_NebrasTenderAttachment_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                newName: "IX_Nebars_NebrasTenderAttachment_TenderAttachmentsTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                column: "TenderAttachmentsTypeId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Tenders_TenderId",
                table: "Nebars_NebrasTenderAttachment",
                column: "TenderId",
                principalTable: "Pms_Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
