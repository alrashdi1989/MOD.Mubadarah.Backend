using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class createProjectHistoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Pms_Projects",
                newName: "Updates");

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId1",
                table: "Pms_UserReports",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pms_ProjectHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeType = table.Column<byte>(type: "tinyint", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_ProjectHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectHistories_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Pms_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pms_UserStandardsSectionPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StandardsSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserStandardsSectionPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_UserStandardsSectionPermissions_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_UserStandardsSectionPermissions_Pms_Lookups_StandardsSectionId",
                        column: x => x.StandardsSectionId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserReports_ReportId1",
                table: "Pms_UserReports",
                column: "ReportId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectHistories_ProjectId",
                table: "Pms_ProjectHistories",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserStandardsSectionPermissions_StandardsSectionId",
                table: "Pms_UserStandardsSectionPermissions",
                column: "StandardsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserStandardsSectionPermissions_UserId_StandardsSectionId",
                table: "Pms_UserStandardsSectionPermissions",
                columns: new[] { "UserId", "StandardsSectionId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_UserReports_Pms_Reports_ReportId1",
                table: "Pms_UserReports",
                column: "ReportId1",
                principalTable: "Pms_Reports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_UserReports_Pms_Reports_ReportId1",
                table: "Pms_UserReports");

            migrationBuilder.DropTable(
                name: "Pms_ProjectHistories");

            migrationBuilder.DropTable(
                name: "Pms_Reports");

            migrationBuilder.DropTable(
                name: "Pms_UserStandardsSectionPermissions");

            migrationBuilder.DropIndex(
                name: "IX_Pms_UserReports_ReportId1",
                table: "Pms_UserReports");

            migrationBuilder.DropColumn(
                name: "ReportId1",
                table: "Pms_UserReports");

            migrationBuilder.RenameColumn(
                name: "Updates",
                table: "Pms_Projects",
                newName: "Notes");
        }
    }
}
