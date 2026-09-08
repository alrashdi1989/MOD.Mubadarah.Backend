using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRfqAndTenderSystems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderAttachment_TenderAttachmentsTypeId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderBusinessAnalysis_NebrasTenderBusinessAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderOfferAttachment_NebrasTenderOfferAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderTechnicalAnalysis_NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_NebrasRFQ_RfqAttachment_RfqAttachmentsTypeId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_NebrasRFQ_RfqOfferAttachment_RfqOfferAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_TenderForms_TenderFormId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_TenderOffers_TenderOfferId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Invoices_Pms_Tenders_TenderId",
                table: "Pms_Invoices");

            migrationBuilder.DropTable(
                name: "Nebars_FinancialSaving");

            migrationBuilder.DropTable(
                name: "Nebars_FinancialSavingNote");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasSuppliersPurchasingTenderDocument");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTenderAttachment");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTenderBusinessAnalysis");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTenderOfferAttachment");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTenderPurchaseRequest");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTenderSelectedSupplier");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTendersRequester");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTendersWorkTeam");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTenderTechnicalAnalysis");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasYellowCard");

            migrationBuilder.DropTable(
                name: "Nebars_OverviewOfRequirement");

            migrationBuilder.DropTable(
                name: "Nebars_PurchasingProcedure");

            migrationBuilder.DropTable(
                name: "Nebars_TenderCommitteeAwardResults");

            migrationBuilder.DropTable(
                name: "Nebars_TenderCommitteeMemberAward");

            migrationBuilder.DropTable(
                name: "Nebars_TenderCommitteeMemberPermission");

            migrationBuilder.DropTable(
                name: "Nebars_TendersCommitteeMeetingTender");

            migrationBuilder.DropTable(
                name: "Nebars_TenderWorkflow");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_MeetingMemberPermission");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqAttachment");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqFinancialSaving");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqFinancialSavingNote");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqMeetingAwardResult");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqMeetingMemberAward");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqMeetingRfq");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqOfferAttachment");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqOfferBusinessAnalysis");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqOfferTechnicalAnalysis");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqOverview");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqPurchaseRequest");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqPurchasingProcedure");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqRequester");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqSelectedSupplier");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqSuppliersPurchasingDocument");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqWorkflow");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqWorkTeam");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqYellowCard");

            migrationBuilder.DropTable(
                name: "Pms_AnalysisResults");

            migrationBuilder.DropTable(
                name: "Pms_TenderForms");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTenderOffer");

            migrationBuilder.DropTable(
                name: "Nebars_TenderCommittee");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqMeeting");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqOffers");

            migrationBuilder.DropTable(
                name: "Pms_TenderOffers");

            migrationBuilder.DropTable(
                name: "Nebars_NebrasTender");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_Rfq");

            migrationBuilder.DropTable(
                name: "Pms_Tenders");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Invoices_TenderId",
                table: "Pms_Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_NebrasTenderBusinessAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_NebrasTenderOfferAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_RfqAttachmentsTypeId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_RfqOfferAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_TenderAttachmentsTypeId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_TenderFormId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_TenderOfferId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "TenderId",
                table: "Pms_Invoices");

            migrationBuilder.DropColumn(
                name: "NebrasTenderBusinessAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "NebrasTenderOfferAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "RfqAttachmentsTypeId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "RfqOfferAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "TenderAttachmentsTypeId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "TenderFormId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "TenderOfferId",
                table: "Pms_Documents");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Pms_Documents",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(34)",
                oldMaxLength: 34);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenderId",
                table: "Pms_Invoices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Pms_Documents",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);

            migrationBuilder.AddColumn<Guid>(
                name: "NebrasTenderBusinessAnalysisId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NebrasTenderOfferAttachmentId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RfqAttachmentsTypeId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RfqOfferAttachmentId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenderAttachmentsTypeId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenderFormId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenderOfferId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTender",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Department = table.Column<int>(type: "int", nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAmountOpenDone = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NebrasCreaterTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    TenderActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenderOfferStatus = table.Column<int>(type: "int", nullable: true),
                    TenderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TenderProgress = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TenderType = table.Column<int>(type: "int", nullable: true),
                    TenderValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_NebrasTender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTender_AbpUsers_NebrasCreaterTenderId",
                        column: x => x.NebrasCreaterTenderId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nebars_TenderCommittee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsMeetingStarted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenderCommitteeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenderCommitteeNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_TenderCommittee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nebars_TenderCommitteeMemberPermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MemberPermission = table.Column<int>(type: "int", nullable: false),
                    MemeberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderCommitteeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_TenderCommitteeMemberPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_TenderCommitteeMemberPermission_AbpUsers_MemeberId",
                        column: x => x.MemeberId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_MeetingMemberPermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MemberPermission = table.Column<int>(type: "int", nullable: false),
                    MemeberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqMeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_MeetingMemberPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_Rfq",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAmountOpenDone = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReplayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReplyMethodLookupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqOfferStatus = table.Column<int>(type: "int", nullable: true),
                    RfqProgress = table.Column<int>(type: "int", nullable: false),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_Rfq", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqMeeting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsMeetingStarted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfqMeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RfqMeetingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqMeeting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqWorkflow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfqMeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserIdFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TeamWorkEditPermission = table.Column<int>(type: "int", nullable: true),
                    TeamWorkMemberPermission = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqWorkTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Tenders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcceptedAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnnouncementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    InvitationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApprved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastDateOfPurchaseDocument = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NumberOfAgentsPurchesedDocument = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NumberOfAgentsSubmitedBid = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ReceiptOffersDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenderType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Tenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Tenders_Pms_Agents_AcceptedAgentId",
                        column: x => x.AcceptedAgentId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Tenders_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nebars_FinancialSavingNote",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_FinancialSavingNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_FinancialSavingNote_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasSuppliersPurchasingTenderDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_NebrasSuppliersPurchasingTenderDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasSuppliersPurchasingTenderDocument_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasSuppliersPurchasingTenderDocument_Pms_Agents_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTenderAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenderAttachmentsTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_NebrasTenderAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderAttachment_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTenderBusinessAnalysis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalysisText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsMeetWarrantyRequirements = table.Column<int>(type: "int", nullable: true),
                    IsRecommended = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_NebrasTenderBusinessAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderBusinessAnalysis_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTenderOffer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EncryptedTotalAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LogisticsTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagingInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProposalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProposalValidityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectionReasons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenderOfferRank = table.Column<int>(type: "int", nullable: true),
                    TenderOfferStatus = table.Column<int>(type: "int", nullable: true),
                    TenderOfferType = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Warranty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_NebrasTenderOffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderOffer_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTenderPurchaseRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedPriceInNumber = table.Column<double>(type: "float", nullable: true),
                    EstimatedPriceInWords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseRequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchaseRequestNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VoteCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_NebrasTenderPurchaseRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderPurchaseRequest_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderPurchaseRequest_SaasTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "SaasTenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTenderSelectedSupplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderSelectedSupplier_Pms_Agents_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTendersRequester",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestNunmber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenderShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VoteCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_NebrasTendersRequester", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTendersRequester_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTendersRequester_SaasTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "SaasTenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTendersWorkTeam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamWorkEditPermission = table.Column<int>(type: "int", nullable: true),
                    TeamWorkMemberPermission = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_NebrasTendersWorkTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTendersWorkTeam_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTendersWorkTeam_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTenderTechnicalAnalysis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalysisText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsRecommended = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_NebrasTenderTechnicalAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderTechnicalAnalysis_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasYellowCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeetingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YellowCardFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YellowCardTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_NebrasYellowCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasYellowCard_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nebars_OverviewOfRequirement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_OverviewOfRequirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_OverviewOfRequirement_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nebars_PurchasingProcedure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Procedure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_PurchasingProcedure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_PurchasingProcedure_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nebars_TenderCommitteeMemberAward",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAcceptedRecommendations = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MemberPermission = table.Column<int>(type: "int", nullable: false),
                    MemeberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderCommitteeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_TenderCommitteeMemberAward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_TenderCommitteeMemberAward_AbpUsers_MemeberId",
                        column: x => x.MemeberId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_TenderCommitteeMemberAward_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_TenderCommitteeMemberAward_Nebars_TenderCommittee_TenderCommitteeId",
                        column: x => x.TenderCommitteeId,
                        principalTable: "Nebars_TenderCommittee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nebars_TendersCommitteeMeetingTender",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderCommitteeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenderStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_TendersCommitteeMeetingTender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_TendersCommitteeMeetingTender_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_TendersCommitteeMeetingTender_Nebars_TenderCommittee_TenderCommitteeId",
                        column: x => x.TenderCommitteeId,
                        principalTable: "Nebars_TenderCommittee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nebars_TenderWorkflow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenderCommitteeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserIdFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_TenderWorkflow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_TenderWorkflow_AbpUsers_UserIdFrom",
                        column: x => x.UserIdFrom,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_TenderWorkflow_AbpUsers_UserIdTo",
                        column: x => x.UserIdTo,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_TenderWorkflow_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_TenderWorkflow_Nebars_TenderCommittee_TenderCommitteeId",
                        column: x => x.TenderCommitteeId,
                        principalTable: "Nebars_TenderCommittee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfqAttachmentsTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "NebrasRFQ_RfqFinancialSavingNote",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqFinancialSavingNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqFinancialSavingNote_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqOfferBusinessAnalysis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalysisText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsMeetWarrantyRequirements = table.Column<int>(type: "int", nullable: true),
                    IsRecommended = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqOfferBusinessAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqOfferBusinessAnalysis_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rfqid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EncryptedTotalAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LogisticsTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagingInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProposalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProposalValidityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectionReasons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqOfferRank = table.Column<int>(type: "int", nullable: true),
                    RfqOfferStatus = table.Column<int>(type: "int", nullable: true),
                    RfqOfferType = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Warranty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqOffers_NebrasRFQ_Rfq_Rfqid",
                        column: x => x.Rfqid,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqOfferTechnicalAnalysis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalysisText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsRecommended = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqOfferTechnicalAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqOfferTechnicalAnalysis_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqOverview",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqOverview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqOverview_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqPurchaseRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContractTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedPriceInNumber = table.Column<double>(type: "float", nullable: true),
                    EstimatedPriceInWords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PurchaseRequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchaseRequestNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqPurchasingProcedure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Procedure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqPurchasingProcedure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqPurchasingProcedure_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqRequester",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RequestNunmber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VoteCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqRequester", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqRequester_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqSelectedSupplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqSelectedSupplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqSelectedSupplier_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqSelectedSupplier_Pms_Agents_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqSuppliersPurchasingDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqSuppliersPurchasingDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqSuppliersPurchasingDocument_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqSuppliersPurchasingDocument_Pms_Agents_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqYellowCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RfqMeetingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YellowCardFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YellowCardTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqYellowCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqYellowCard_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqMeetingRfq",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqMeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfqStatus = table.Column<int>(type: "int", nullable: true)
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
                name: "Pms_TenderForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Describtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenderFormDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_TenderForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_TenderForms_Pms_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Pms_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pms_TenderForms_Pms_Tenders_tenderId",
                        column: x => x.tenderId,
                        principalTable: "Pms_Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pms_TenderOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CalculationMistakes = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ContractNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialAnalysisFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IfAcceptedoffer = table.Column<bool>(type: "bit", nullable: false),
                    IsApplicalbleContacrtCondition = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NumberOfLabor = table.Column<int>(type: "int", nullable: true),
                    PeriodOfValidateBankInssurance = table.Column<int>(type: "int", nullable: false),
                    PeriodOfValidateOffer = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecommendedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 250, nullable: true),
                    TechnicalAnalysisFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnicalNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicalResult = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_TenderOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_TenderOffers_Pms_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_TenderOffers_Pms_Forms_FinancialAnalysisFormId",
                        column: x => x.FinancialAnalysisFormId,
                        principalTable: "Pms_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_TenderOffers_Pms_Forms_TechnicalAnalysisFormId",
                        column: x => x.TechnicalAnalysisFormId,
                        principalTable: "Pms_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_TenderOffers_Pms_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Pms_Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nebars_FinancialSaving",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PriceBeforeNegotitation = table.Column<double>(type: "float", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ProposalId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_FinancialSaving", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_FinancialSaving_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                        column: x => x.NebrasTenderOfferId,
                        principalTable: "Nebars_NebrasTenderOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nebars_FinancialSaving_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_FinancialSaving_Pms_Agents_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nebars_NebrasTenderOfferAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NebrasTenderOfferAttachmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_NebrasTenderOfferAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_NebrasTenderOfferAttachment_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                        column: x => x.NebrasTenderOfferId,
                        principalTable: "Nebars_NebrasTenderOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nebars_TenderCommitteeAwardResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserActionFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserActionTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nebars_TenderCommitteeAwardResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_TenderCommitteeAwardResults_AbpUsers_UserActionFrom",
                        column: x => x.UserActionFrom,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_TenderCommitteeAwardResults_AbpUsers_UserActionTo",
                        column: x => x.UserActionTo,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_TenderCommitteeAwardResults_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                        column: x => x.NebrasTenderOfferId,
                        principalTable: "Nebars_NebrasTenderOffer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_TenderCommitteeAwardResults_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqFinancialSaving",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PriceBeforeNegotitation = table.Column<double>(type: "float", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ProposalId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NebrasRFQ_RfqFinancialSaving", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqFinancialSaving_NebrasRFQ_RfqOffers_RfqOfferId",
                        column: x => x.RfqOfferId,
                        principalTable: "NebrasRFQ_RfqOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqFinancialSaving_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqFinancialSaving_Pms_Agents_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAcceptedRecommendations = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MemberPermission = table.Column<int>(type: "int", nullable: false),
                    MemeberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqMeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "NebrasRFQ_RfqOfferAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfqOfferAttachmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "Pms_AnalysisResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    FormStandardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReffrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenderOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnalysisesResultType = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_AnalysisResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_AnalysisResults_Pms_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_AnalysisResults_Pms_FormStandards_FormStandardId",
                        column: x => x.FormStandardId,
                        principalTable: "Pms_FormStandards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_AnalysisResults_Pms_TenderOffers_TenderOfferId",
                        column: x => x.TenderOfferId,
                        principalTable: "Pms_TenderOffers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Invoices_TenderId",
                table: "Pms_Invoices",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_NebrasTenderBusinessAnalysisId",
                table: "Pms_Documents",
                column: "NebrasTenderBusinessAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_NebrasTenderOfferAttachmentId",
                table: "Pms_Documents",
                column: "NebrasTenderOfferAttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents",
                column: "NebrasTenderTechnicalAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_RfqAttachmentsTypeId",
                table: "Pms_Documents",
                column: "RfqAttachmentsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_RfqOfferAttachmentId",
                table: "Pms_Documents",
                column: "RfqOfferAttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_TenderAttachmentsTypeId",
                table: "Pms_Documents",
                column: "TenderAttachmentsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_TenderFormId",
                table: "Pms_Documents",
                column: "TenderFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_TenderOfferId",
                table: "Pms_Documents",
                column: "TenderOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_FinancialSaving_NebrasTenderId",
                table: "Nebars_FinancialSaving",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_FinancialSaving_NebrasTenderOfferId",
                table: "Nebars_FinancialSaving",
                column: "NebrasTenderOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_FinancialSaving_SupplierId",
                table: "Nebars_FinancialSaving",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_FinancialSavingNote_NebrasTenderId",
                table: "Nebars_FinancialSavingNote",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasSuppliersPurchasingTenderDocument_NebrasTenderId",
                table: "Nebars_NebrasSuppliersPurchasingTenderDocument",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasSuppliersPurchasingTenderDocument_SupplierId",
                table: "Nebars_NebrasSuppliersPurchasingTenderDocument",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTender_NebrasCreaterTenderId",
                table: "Nebars_NebrasTender",
                column: "NebrasCreaterTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderAttachment_NebrasTenderId",
                table: "Nebars_NebrasTenderAttachment",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderBusinessAnalysis_NebrasTenderId",
                table: "Nebars_NebrasTenderBusinessAnalysis",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderOffer_NebrasTenderId",
                table: "Nebars_NebrasTenderOffer",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderOfferAttachment_NebrasTenderOfferId",
                table: "Nebars_NebrasTenderOfferAttachment",
                column: "NebrasTenderOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderPurchaseRequest_NebrasTenderId",
                table: "Nebars_NebrasTenderPurchaseRequest",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderPurchaseRequest_TenantId",
                table: "Nebars_NebrasTenderPurchaseRequest",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderSelectedSupplier_NebrasTenderId",
                table: "Nebars_NebrasTenderSelectedSupplier",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderSelectedSupplier_SupplierId",
                table: "Nebars_NebrasTenderSelectedSupplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTendersRequester_NebrasTenderId",
                table: "Nebars_NebrasTendersRequester",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTendersRequester_TenantId",
                table: "Nebars_NebrasTendersRequester",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTendersWorkTeam_NebrasTenderId",
                table: "Nebars_NebrasTendersWorkTeam",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTendersWorkTeam_UserId",
                table: "Nebars_NebrasTendersWorkTeam",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderTechnicalAnalysis_NebrasTenderId",
                table: "Nebars_NebrasTenderTechnicalAnalysis",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasYellowCard_NebrasTenderId",
                table: "Nebars_NebrasYellowCard",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_OverviewOfRequirement_NebrasTenderId",
                table: "Nebars_OverviewOfRequirement",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_PurchasingProcedure_NebrasTenderId",
                table: "Nebars_PurchasingProcedure",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeAwardResults_NebrasTenderId",
                table: "Nebars_TenderCommitteeAwardResults",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeAwardResults_NebrasTenderOfferId",
                table: "Nebars_TenderCommitteeAwardResults",
                column: "NebrasTenderOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeAwardResults_UserActionFrom",
                table: "Nebars_TenderCommitteeAwardResults",
                column: "UserActionFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeAwardResults_UserActionTo",
                table: "Nebars_TenderCommitteeAwardResults",
                column: "UserActionTo");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeMemberAward_MemeberId",
                table: "Nebars_TenderCommitteeMemberAward",
                column: "MemeberId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeMemberAward_NebrasTenderId",
                table: "Nebars_TenderCommitteeMemberAward",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeMemberAward_TenderCommitteeId",
                table: "Nebars_TenderCommitteeMemberAward",
                column: "TenderCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeMemberPermission_MemeberId",
                table: "Nebars_TenderCommitteeMemberPermission",
                column: "MemeberId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TendersCommitteeMeetingTender_NebrasTenderId",
                table: "Nebars_TendersCommitteeMeetingTender",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TendersCommitteeMeetingTender_TenderCommitteeId",
                table: "Nebars_TendersCommitteeMeetingTender",
                column: "TenderCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderWorkflow_NebrasTenderId",
                table: "Nebars_TenderWorkflow",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderWorkflow_TenderCommitteeId",
                table: "Nebars_TenderWorkflow",
                column: "TenderCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderWorkflow_UserIdFrom",
                table: "Nebars_TenderWorkflow",
                column: "UserIdFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderWorkflow_UserIdTo",
                table: "Nebars_TenderWorkflow",
                column: "UserIdTo");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqAttachment_RfqId",
                table: "NebrasRFQ_RfqAttachment",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqFinancialSaving_RfqId",
                table: "NebrasRFQ_RfqFinancialSaving",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqFinancialSaving_RfqOfferId",
                table: "NebrasRFQ_RfqFinancialSaving",
                column: "RfqOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqFinancialSaving_SupplierId",
                table: "NebrasRFQ_RfqFinancialSaving",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqFinancialSavingNote_RfqId",
                table: "NebrasRFQ_RfqFinancialSavingNote",
                column: "RfqId");

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
                name: "IX_NebrasRFQ_RfqOfferBusinessAnalysis_RfqId",
                table: "NebrasRFQ_RfqOfferBusinessAnalysis",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqOffers_Rfqid",
                table: "NebrasRFQ_RfqOffers",
                column: "Rfqid");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqOfferTechnicalAnalysis_RfqId",
                table: "NebrasRFQ_RfqOfferTechnicalAnalysis",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqOverview_RfqId",
                table: "NebrasRFQ_RfqOverview",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqPurchaseRequest_RfqId",
                table: "NebrasRFQ_RfqPurchaseRequest",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqPurchasingProcedure_RfqId",
                table: "NebrasRFQ_RfqPurchasingProcedure",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqRequester_RfqId",
                table: "NebrasRFQ_RfqRequester",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqSelectedSupplier_RfqId",
                table: "NebrasRFQ_RfqSelectedSupplier",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqSelectedSupplier_SupplierId",
                table: "NebrasRFQ_RfqSelectedSupplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqSuppliersPurchasingDocument_RfqId",
                table: "NebrasRFQ_RfqSuppliersPurchasingDocument",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqSuppliersPurchasingDocument_SupplierId",
                table: "NebrasRFQ_RfqSuppliersPurchasingDocument",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqYellowCard_RfqId",
                table: "NebrasRFQ_RfqYellowCard",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_AnalysisResults_AgentId",
                table: "Pms_AnalysisResults",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_AnalysisResults_FormStandardId",
                table: "Pms_AnalysisResults",
                column: "FormStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_AnalysisResults_TenderOfferId",
                table: "Pms_AnalysisResults",
                column: "TenderOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_TenderForms_FormId",
                table: "Pms_TenderForms",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_TenderForms_tenderId",
                table: "Pms_TenderForms",
                column: "tenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_TenderOffers_AgentId",
                table: "Pms_TenderOffers",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_TenderOffers_FinancialAnalysisFormId",
                table: "Pms_TenderOffers",
                column: "FinancialAnalysisFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_TenderOffers_TechnicalAnalysisFormId",
                table: "Pms_TenderOffers",
                column: "TechnicalAnalysisFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_TenderOffers_TenderId",
                table: "Pms_TenderOffers",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Tenders_AcceptedAgentId",
                table: "Pms_Tenders",
                column: "AcceptedAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Tenders_ProjectId",
                table: "Pms_Tenders",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderAttachment_TenderAttachmentsTypeId",
                table: "Pms_Documents",
                column: "TenderAttachmentsTypeId",
                principalTable: "Nebars_NebrasTenderAttachment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderBusinessAnalysis_NebrasTenderBusinessAnalysisId",
                table: "Pms_Documents",
                column: "NebrasTenderBusinessAnalysisId",
                principalTable: "Nebars_NebrasTenderBusinessAnalysis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderOfferAttachment_NebrasTenderOfferAttachmentId",
                table: "Pms_Documents",
                column: "NebrasTenderOfferAttachmentId",
                principalTable: "Nebars_NebrasTenderOfferAttachment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Nebars_NebrasTenderTechnicalAnalysis_NebrasTenderTechnicalAnalysisId",
                table: "Pms_Documents",
                column: "NebrasTenderTechnicalAnalysisId",
                principalTable: "Nebars_NebrasTenderTechnicalAnalysis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_NebrasRFQ_RfqAttachment_RfqAttachmentsTypeId",
                table: "Pms_Documents",
                column: "RfqAttachmentsTypeId",
                principalTable: "NebrasRFQ_RfqAttachment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_NebrasRFQ_RfqOfferAttachment_RfqOfferAttachmentId",
                table: "Pms_Documents",
                column: "RfqOfferAttachmentId",
                principalTable: "NebrasRFQ_RfqOfferAttachment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_TenderForms_TenderFormId",
                table: "Pms_Documents",
                column: "TenderFormId",
                principalTable: "Pms_TenderForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_TenderOffers_TenderOfferId",
                table: "Pms_Documents",
                column: "TenderOfferId",
                principalTable: "Pms_TenderOffers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Invoices_Pms_Tenders_TenderId",
                table: "Pms_Invoices",
                column: "TenderId",
                principalTable: "Pms_Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
