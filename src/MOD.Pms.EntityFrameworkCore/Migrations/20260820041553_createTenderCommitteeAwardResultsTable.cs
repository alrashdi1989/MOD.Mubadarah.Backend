using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class createTenderCommitteeAwardResultsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nebars_TenderCommitteeAwardResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserActionFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserActionTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nebars_TenderCommitteeAwardResults");
        }
    }
}
