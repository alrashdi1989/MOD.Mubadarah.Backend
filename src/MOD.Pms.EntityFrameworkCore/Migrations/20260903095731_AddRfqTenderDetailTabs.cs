using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class AddRfqTenderDetailTabs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqFinancialSaving",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProposalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceBeforeNegotitation = table.Column<double>(type: "float", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
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
                name: "NebrasRFQ_RfqFinancialSavingNote",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    IsMeetWarrantyRequirements = table.Column<int>(type: "int", nullable: true),
                    IsRecommended = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqOfferBusinessAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqOfferBusinessAnalysis_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
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
                    IsRecommended = table.Column<int>(type: "int", nullable: false),
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
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqOverview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqOverview_NebrasRFQ_Rfq_RfqId",
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
                    Procedure = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    RfqNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RequestNunmber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqRequester", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqRequester_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqYellowCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfqMeetingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YellowCardFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YellowCardTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqYellowCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqYellowCard_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_NebrasRFQ_RfqOfferBusinessAnalysis_RfqId",
                table: "NebrasRFQ_RfqOfferBusinessAnalysis",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqOfferTechnicalAnalysis_RfqId",
                table: "NebrasRFQ_RfqOfferTechnicalAnalysis",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqOverview_RfqId",
                table: "NebrasRFQ_RfqOverview",
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
                name: "IX_NebrasRFQ_RfqYellowCard_RfqId",
                table: "NebrasRFQ_RfqYellowCard",
                column: "RfqId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqFinancialSaving");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqFinancialSavingNote");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqOfferBusinessAnalysis");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqOfferTechnicalAnalysis");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqOverview");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqPurchasingProcedure");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqRequester");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqYellowCard");
        }
    }
}
