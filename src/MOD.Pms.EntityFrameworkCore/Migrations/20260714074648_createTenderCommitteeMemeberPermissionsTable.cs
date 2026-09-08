using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class createTenderCommitteeMemeberPermissionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nebars_TenderCommitteeMemberPermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderCommitteeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemeberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Nebars_TenderCommitteeMemberPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_TenderCommitteeMemberPermission_AbpUsers_MemeberId",
                        column: x => x.MemeberId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nebars_TenderCommitteeMemberPermission_Nebars_TenderCommittee_TenderCommitteeId",
                        column: x => x.TenderCommitteeId,
                        principalTable: "Nebars_TenderCommittee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeMemberPermission_MemeberId",
                table: "Nebars_TenderCommitteeMemberPermission",
                column: "MemeberId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_TenderCommitteeMemberPermission_TenderCommitteeId",
                table: "Nebars_TenderCommitteeMemberPermission",
                column: "TenderCommitteeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nebars_TenderCommitteeMemberPermission");
        }
    }
}
