using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class Added_RfqWorkflow_RfqWorkTeam_RfqAttachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenderType",
                table: "NebrasRFQ_Rfq",
                newName: "RfqType");

            migrationBuilder.RenameColumn(
                name: "TenderOfferStatus",
                table: "NebrasRFQ_Rfq",
                newName: "RfqOfferStatus");

            migrationBuilder.AddColumn<Guid>(
                name: "RfqAttachmentsTypeId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqAttachmentsTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqAttachment_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqWorkflow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqMeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqWorkflow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqWorkTeam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    TeamWorkEditPermission = table.Column<int>(type: "int", nullable: true),
                    TeamWorkMemberPermission = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqWorkTeam", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_RfqAttachmentsTypeId",
                table: "Pms_Documents",
                column: "RfqAttachmentsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqAttachment_RfqId",
                table: "NebrasRFQ_RfqAttachment",
                column: "RfqId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_NebrasRFQ_RfqAttachment_RfqAttachmentsTypeId",
                table: "Pms_Documents",
                column: "RfqAttachmentsTypeId",
                principalTable: "NebrasRFQ_RfqAttachment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_NebrasRFQ_RfqAttachment_RfqAttachmentsTypeId",
                table: "Pms_Documents");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqAttachment");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqWorkflow");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqWorkTeam");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_RfqAttachmentsTypeId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "RfqAttachmentsTypeId",
                table: "Pms_Documents");

            migrationBuilder.RenameColumn(
                name: "RfqType",
                table: "NebrasRFQ_Rfq",
                newName: "TenderType");

            migrationBuilder.RenameColumn(
                name: "RfqOfferStatus",
                table: "NebrasRFQ_Rfq",
                newName: "TenderOfferStatus");
        }
    }
}
