using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class createTenderCommitteeMemberAwardTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_TenderCommitteeMemberPermission_Nebars_TenderCommittee_TenderCommitteeId",
                table: "Nebars_TenderCommitteeMemberPermission");

            migrationBuilder.DropIndex(
                name: "IX_Nebars_TenderCommitteeMemberPermission_TenderCommitteeId",
                table: "Nebars_TenderCommitteeMemberPermission");

            migrationBuilder.CreateTable(
                name: "Nebars_TenderCommitteeMemberAward",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderCommitteeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemeberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Nebars_TenderCommitteeMemberAward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_TenderCommitteeMemberAward_AbpUsers_MemeberId",
                        column: x => x.MemeberId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_TenderCommitteeMemberAward_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                        column: x => x.NebrasTenderOfferId,
                        principalTable: "Nebars_NebrasTenderOffer",
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

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeMemberAward_MemeberId",
                table: "Nebars_TenderCommitteeMemberAward",
                column: "MemeberId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeMemberAward_NebrasTenderId",
                table: "Nebars_TenderCommitteeMemberAward",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeMemberAward_NebrasTenderOfferId",
                table: "Nebars_TenderCommitteeMemberAward",
                column: "NebrasTenderOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeMemberAward_TenderCommitteeId",
                table: "Nebars_TenderCommitteeMemberAward",
                column: "TenderCommitteeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nebars_TenderCommitteeMemberAward");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeMemberPermission_TenderCommitteeId",
                table: "Nebars_TenderCommitteeMemberPermission",
                column: "TenderCommitteeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_TenderCommitteeMemberPermission_Nebars_TenderCommittee_TenderCommitteeId",
                table: "Nebars_TenderCommitteeMemberPermission",
                column: "TenderCommitteeId",
                principalTable: "Nebars_TenderCommittee",
                principalColumn: "Id");
        }
    }
}
