using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateNebrasTenderAttachmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_ProjectAttachmentTypeId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.DropIndex(
                name: "IX_Nebars_NebrasTenderAttachment_ProjectAttachmentTypeId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.DropColumn(
                name: "ProjectAttachmentTypeId",
                table: "Nebars_NebrasTenderAttachment");

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
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectAttachmentTypeId",
                table: "Nebars_NebrasTenderAttachment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderAttachment_ProjectAttachmentTypeId",
                table: "Nebars_NebrasTenderAttachment",
                column: "ProjectAttachmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_ProjectAttachmentTypeId",
                table: "Nebars_NebrasTenderAttachment",
                column: "ProjectAttachmentTypeId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderAttachment_Pms_Lookups_TenderAttachmentsTypeId",
                table: "Nebars_NebrasTenderAttachment",
                column: "TenderAttachmentsTypeId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");
        }
    }
}
