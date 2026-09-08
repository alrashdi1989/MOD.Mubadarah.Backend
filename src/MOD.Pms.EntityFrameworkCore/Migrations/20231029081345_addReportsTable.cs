using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addReportsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pms_UserReports");

            migrationBuilder.CreateTable(
                name: "Pms_UserReportPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserReportPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_UserReportPermissions_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_UserReportPermissions_Pms_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Pms_Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserReportPermissions_ReportId",
                table: "Pms_UserReportPermissions",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserReportPermissions_UserId_ReportId",
                table: "Pms_UserReportPermissions",
                columns: new[] { "UserId", "ReportId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pms_UserReportPermissions");

            migrationBuilder.CreateTable(
                name: "Pms_UserReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_UserReports_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_UserReports_Pms_Lookups_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_UserReports_Pms_Reports_ReportId1",
                        column: x => x.ReportId1,
                        principalTable: "Pms_Reports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserReports_ReportId",
                table: "Pms_UserReports",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserReports_ReportId1",
                table: "Pms_UserReports",
                column: "ReportId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserReports_UserId",
                table: "Pms_UserReports",
                column: "UserId");
        }
    }
}
