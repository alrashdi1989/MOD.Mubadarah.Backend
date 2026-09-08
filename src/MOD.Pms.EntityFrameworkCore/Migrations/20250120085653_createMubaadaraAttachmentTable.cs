using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class createMubaadaraAttachmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MubaadaraAttachmentId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mub_MubaadaraAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MubaadaraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectAttachmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Mub_MubaadaraAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mub_MubaadaraAttachment_Mub_Mubaadaras_MubaadaraId",
                        column: x => x.MubaadaraId,
                        principalTable: "Mub_Mubaadaras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mub_MubaadaraAttachment_Pms_Lookups_ProjectAttachmentTypeId",
                        column: x => x.ProjectAttachmentTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_MubaadaraAttachmentId",
                table: "Pms_Documents",
                column: "MubaadaraAttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Mub_MubaadaraAttachment_MubaadaraId",
                table: "Mub_MubaadaraAttachment",
                column: "MubaadaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Mub_MubaadaraAttachment_ProjectAttachmentTypeId",
                table: "Mub_MubaadaraAttachment",
                column: "ProjectAttachmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Mub_MubaadaraAttachment_MubaadaraAttachmentId",
                table: "Pms_Documents",
                column: "MubaadaraAttachmentId",
                principalTable: "Mub_MubaadaraAttachment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Mub_MubaadaraAttachment_MubaadaraAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropTable(
                name: "Mub_MubaadaraAttachment");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_MubaadaraAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "MubaadaraAttachmentId",
                table: "Pms_Documents");
        }
    }
}
