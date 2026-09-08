using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class createTenderWorkflowTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nebars_TenderWorkflow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderCommitteeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nebars_TenderWorkflow");
        }
    }
}
