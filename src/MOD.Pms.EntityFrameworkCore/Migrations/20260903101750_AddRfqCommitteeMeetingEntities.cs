using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class AddRfqCommitteeMeetingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RfqOfferAttachmentId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqMeetingAwardResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserActionFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserActionTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqMeetingAwardResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqMeetingAwardResult_AbpUsers_UserActionFrom",
                        column: x => x.UserActionFrom,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqMeetingAwardResult_AbpUsers_UserActionTo",
                        column: x => x.UserActionTo,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqMeetingAwardResult_NebrasRFQ_RfqOffers_RfqOfferId",
                        column: x => x.RfqOfferId,
                        principalTable: "NebrasRFQ_RfqOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqMeetingAwardResult_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqMeetingMemberAward",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqMeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemeberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAcceptedRecommendations = table.Column<int>(type: "int", nullable: false),
                    MemberPermission = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqMeetingMemberAward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqMeetingMemberAward_AbpUsers_MemeberId",
                        column: x => x.MemeberId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqMeetingMemberAward_NebrasRFQ_RfqMeeting_RfqMeetingId",
                        column: x => x.RfqMeetingId,
                        principalTable: "NebrasRFQ_RfqMeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqMeetingMemberAward_NebrasRFQ_RfqOffers_RfqOfferId",
                        column: x => x.RfqOfferId,
                        principalTable: "NebrasRFQ_RfqOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqMeetingMemberAward_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqMeetingRfq",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqMeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqStatus = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqMeetingRfq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqMeetingRfq_NebrasRFQ_RfqMeeting_RfqMeetingId",
                        column: x => x.RfqMeetingId,
                        principalTable: "NebrasRFQ_RfqMeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqMeetingRfq_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqOfferAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqOfferAttachmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqOfferAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqOfferAttachment_NebrasRFQ_RfqOffers_RfqOfferId",
                        column: x => x.RfqOfferId,
                        principalTable: "NebrasRFQ_RfqOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqPurchaseRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PurchaseRequestNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseRequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedPriceInWords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedPriceInNumber = table.Column<double>(type: "float", nullable: true),
                    VoteCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeliveryMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqPurchaseRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqPurchaseRequest_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_RfqOfferAttachmentId",
                table: "Pms_Documents",
                column: "RfqOfferAttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqMeetingAwardResult_RfqId",
                table: "NebrasRFQ_RfqMeetingAwardResult",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqMeetingAwardResult_RfqOfferId",
                table: "NebrasRFQ_RfqMeetingAwardResult",
                column: "RfqOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqMeetingAwardResult_UserActionFrom",
                table: "NebrasRFQ_RfqMeetingAwardResult",
                column: "UserActionFrom");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqMeetingAwardResult_UserActionTo",
                table: "NebrasRFQ_RfqMeetingAwardResult",
                column: "UserActionTo");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqMeetingMemberAward_MemeberId",
                table: "NebrasRFQ_RfqMeetingMemberAward",
                column: "MemeberId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqMeetingMemberAward_RfqId",
                table: "NebrasRFQ_RfqMeetingMemberAward",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqMeetingMemberAward_RfqMeetingId",
                table: "NebrasRFQ_RfqMeetingMemberAward",
                column: "RfqMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqMeetingMemberAward_RfqOfferId",
                table: "NebrasRFQ_RfqMeetingMemberAward",
                column: "RfqOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqMeetingRfq_RfqId",
                table: "NebrasRFQ_RfqMeetingRfq",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqMeetingRfq_RfqMeetingId",
                table: "NebrasRFQ_RfqMeetingRfq",
                column: "RfqMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqOfferAttachment_RfqOfferId",
                table: "NebrasRFQ_RfqOfferAttachment",
                column: "RfqOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqPurchaseRequest_RfqId",
                table: "NebrasRFQ_RfqPurchaseRequest",
                column: "RfqId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_NebrasRFQ_RfqOfferAttachment_RfqOfferAttachmentId",
                table: "Pms_Documents",
                column: "RfqOfferAttachmentId",
                principalTable: "NebrasRFQ_RfqOfferAttachment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_NebrasRFQ_RfqOfferAttachment_RfqOfferAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqMeetingAwardResult");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqMeetingMemberAward");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqMeetingRfq");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqOfferAttachment");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqPurchaseRequest");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_RfqOfferAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "RfqOfferAttachmentId",
                table: "Pms_Documents");
        }
    }
}
