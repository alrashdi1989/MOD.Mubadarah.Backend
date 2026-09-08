using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class TendersCommitteeMeetingTender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nebars_TendersCommitteeMeetingTender",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderCommitteeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderStatus = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TendersCommitteeMeetingTender_NebrasTenderId",
                table: "Nebars_TendersCommitteeMeetingTender",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TendersCommitteeMeetingTender_TenderCommitteeId",
                table: "Nebars_TendersCommitteeMeetingTender",
                column: "TenderCommitteeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nebars_TendersCommitteeMeetingTender");
        }
    }
}
