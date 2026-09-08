using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class UpdataNebrasTenderAttachmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Nebars_NebrasTender_TenderId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.RenameColumn(
                name: "TenderId",
                table: "Nebars_NebrasTenderAttachment",
                newName: "NebrasTenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Nebars_NebrasTenderAttachment_TenderId",
                table: "Nebars_NebrasTenderAttachment",
                newName: "IX_Nebars_NebrasTenderAttachment_NebrasTenderId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Nebars_NebrasTender_NebrasTenderId",
                table: "Nebars_NebrasTenderAttachment",
                column: "NebrasTenderId",
                principalTable: "Nebars_NebrasTender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                column: "TenderAttachmentsTypeId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Nebars_NebrasTender_NebrasTenderId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.RenameColumn(
                name: "NebrasTenderId",
                table: "Nebars_NebrasTenderAttachment",
                newName: "TenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Nebars_NebrasTenderAttachment_NebrasTenderId",
                table: "Nebars_NebrasTenderAttachment",
                newName: "IX_Nebars_NebrasTenderAttachment_TenderId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
    }
}
