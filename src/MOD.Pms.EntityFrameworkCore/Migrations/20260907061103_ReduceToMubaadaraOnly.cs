using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class ReduceToMubaadaraOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_Agents_AgentId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_ChangeRequests_ChangeRequestId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_Drawing_DrawingId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_Forms_FormId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_Invoices_InvoiceId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_Meetings_MeetingId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_OtherProjectForm_OtherProjectFormId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_ProjectAttachment_ProjectAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_Projects_ProjectId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_Reports_ReportId",
                table: "Pms_Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_Warnings_WarningId",
                table: "Pms_Documents");

            migrationBuilder.DropTable(
                name: "Pms_ChangeRequests");

            migrationBuilder.DropTable(
                name: "Pms_Dependency");

            migrationBuilder.DropTable(
                name: "Pms_DependencyProjects");

            migrationBuilder.DropTable(
                name: "Pms_Drawing");

            migrationBuilder.DropTable(
                name: "Pms_EvaluationResults");

            migrationBuilder.DropTable(
                name: "Pms_ExtensionReasons");

            migrationBuilder.DropTable(
                name: "Pms_Invoices");

            migrationBuilder.DropTable(
                name: "Pms_MeetingInvitations");

            migrationBuilder.DropTable(
                name: "Pms_Members");

            migrationBuilder.DropTable(
                name: "Pms_MemberTasks");

            migrationBuilder.DropTable(
                name: "Pms_OmanStates");

            migrationBuilder.DropTable(
                name: "Pms_OtherProjectForm");

            migrationBuilder.DropTable(
                name: "Pms_ProjectAttachment");

            migrationBuilder.DropTable(
                name: "Pms_ProjectCameras");

            migrationBuilder.DropTable(
                name: "Pms_ProjectExtenstionTasks");

            migrationBuilder.DropTable(
                name: "Pms_ProjectHistories");

            migrationBuilder.DropTable(
                name: "Pms_ProjectTypePhases");

            migrationBuilder.DropTable(
                name: "Pms_Schedulars");

            migrationBuilder.DropTable(
                name: "Pms_UserAttachmentTypePermission");

            migrationBuilder.DropTable(
                name: "Pms_UserDashBoards");

            migrationBuilder.DropTable(
                name: "Pms_UserDrawingTypePermission");

            migrationBuilder.DropTable(
                name: "Pms_UserPolicy");

            migrationBuilder.DropTable(
                name: "Pms_UserProjectsFavorites ");

            migrationBuilder.DropTable(
                name: "Pms_UserProjectTypePermissions");

            migrationBuilder.DropTable(
                name: "Pms_UserReportPermissions");

            migrationBuilder.DropTable(
                name: "Pms_UserStandardsSectionPermissions");

            migrationBuilder.DropTable(
                name: "Pms_UserTenantPermissions");

            migrationBuilder.DropTable(
                name: "Pms_Warnings");

            migrationBuilder.DropTable(
                name: "Pms_Workflows");

            migrationBuilder.DropTable(
                name: "Pms_AgentProjects");

            migrationBuilder.DropTable(
                name: "Pms_FormStandards");

            migrationBuilder.DropTable(
                name: "Pms_SubAgents");

            migrationBuilder.DropTable(
                name: "Pms_Meetings");

            migrationBuilder.DropTable(
                name: "Pms_DurationExtensions");

            migrationBuilder.DropTable(
                name: "Pms_ProjectTasks");

            migrationBuilder.DropTable(
                name: "Pms_Reports");

            migrationBuilder.DropTable(
                name: "Pms_Approvals");

            migrationBuilder.DropTable(
                name: "Pms_Forms");

            migrationBuilder.DropTable(
                name: "Pms_Agents");

            migrationBuilder.DropTable(
                name: "Pms_Projects");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_AgentId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_ChangeRequestId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_DrawingId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_FormId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_InvoiceId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_MeetingId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_OtherProjectFormId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_ProjectAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_ProjectId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_ReportId",
                table: "Pms_Documents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_WarningId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "ChangeRequestId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "DrawingId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "OtherProjectFormId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "ProjectAttachmentId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "WarningId",
                table: "Pms_Documents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AgentId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChangeRequestId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DrawingId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MeetingId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OtherProjectFormId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectAttachmentId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WarningId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pms_Agents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DegreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsBloked = table.Column<bool>(type: "bit", maxLength: 5, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NibrasId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    OmanizationRaito = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Agents_Pms_Lookups_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Agents_Pms_Lookups_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pms_Approvals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ReffrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TabName = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Approvals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Approvals_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsSecret = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TabName = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Forms_Pms_Lookups_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_OmanStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sector = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_OmanStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectStatueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApproximateAmount = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    BuldingArea = table.Column<double>(type: "float", nullable: true),
                    CampId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Expense = table.Column<decimal>(type: "decimal(18,3)", nullable: false, defaultValue: 0m),
                    InsuranceAmount = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    InsuranceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LetterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MotoilizationStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Solutions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TechnicalAndFinancialChallenges = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Updates = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    UpdatesDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VoteCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Projects_AbpOrganizationUnits_OrganizationUnitId",
                        column: x => x.OrganizationUnitId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Projects_Pms_Lookups_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Projects_Pms_Lookups_ProjectStatueId",
                        column: x => x.ProjectStatueId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Projects_Pms_Lookups_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_ProjectTypePhases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_ProjectTypePhases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectTypePhases_Pms_Lookups_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectTypePhases_Pms_Lookups_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReportType = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Schedulars",
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
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    roomId = table.Column<int>(type: "int", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Schedulars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Schedulars_AbpUsers_userId",
                        column: x => x.userId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pms_UserAttachmentTypePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectAttachmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserAttachmentTypePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_UserAttachmentTypePermission_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_UserAttachmentTypePermission_Pms_Lookups_ProjectAttachmentTypeId",
                        column: x => x.ProjectAttachmentTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_UserDashBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DashBoardName = table.Column<int>(type: "int", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserDashBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pms_UserPolicy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAcceptPolicy = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserPolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_UserPolicy_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_UserProjectTypePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserProjectTypePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_UserProjectTypePermissions_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_UserProjectTypePermissions_Pms_Lookups_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_UserStandardsSectionPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StandardsSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Pms_UserTenantPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserTenantPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_UserTenantPermissions_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_UserTenantPermissions_SaasTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "SaasTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_FormStandards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StandardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StandardsSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_FormStandards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_FormStandards_Pms_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Pms_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pms_FormStandards_Pms_Lookups_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pms_FormStandards_Pms_Lookups_StandardsSectionId",
                        column: x => x.StandardsSectionId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pms_UserDrawingTypePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserDrawingTypePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_UserDrawingTypePermission_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_UserDrawingTypePermission_Pms_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Pms_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_AgentProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluationFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_AgentProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_AgentProjects_Pms_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_AgentProjects_Pms_Forms_EvaluationFormId",
                        column: x => x.EvaluationFormId,
                        principalTable: "Pms_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_AgentProjects_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_ChangeRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentOffers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChangeReasons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CumulativePercentage = table.Column<int>(type: "int", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Desecription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinanceChange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsApproval = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteCodeType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_ChangeRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_ChangeRequests_Pms_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_ChangeRequests_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_DependencyProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DependencyProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Pms_DependencyProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_DependencyProjects_Pms_Projects_DependencyProjectId",
                        column: x => x.DependencyProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_DependencyProjects_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Drawing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrawingMapId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuldingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproval = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MapNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Drawing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Drawing_Pms_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Pms_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Drawing_Pms_Lookups_DrawingMapId",
                        column: x => x.DrawingMapId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Drawing_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_DurationExtensions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_DurationExtensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_DurationExtensions_Pms_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_DurationExtensions_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Meetings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingStatus = table.Column<int>(type: "int", nullable: false),
                    MeetingTerms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MeetingTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Meetings_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MemberPermission = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Members_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Members_Pms_Lookups_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Members_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_OtherProjectForm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Describtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproval = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OtherProjectFormDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_OtherProjectForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_OtherProjectForm_Pms_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Pms_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_OtherProjectForm_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_ProjectAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectAttachmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarrantyPeriod = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WarrantyStart = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_ProjectAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectAttachment_Pms_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectAttachment_Pms_Lookups_ProjectAttachmentTypeId",
                        column: x => x.ProjectAttachmentTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectAttachment_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_ProjectCameras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CameraIPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CameraName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FullCameraIPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_ProjectCameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectCameras_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_ProjectHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChangeType = table.Column<byte>(type: "tinyint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
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
                name: "Pms_ProjectTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActualProgress = table.Column<double>(type: "float", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlannedProgress = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_ProjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectTasks_Pms_ProjectTasks_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Pms_ProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectTasks_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_SubAgents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractorTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_SubAgents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_SubAgents_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_UserProjectsFavorites ",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserProjectsFavorites ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_UserProjectsFavorites _AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_UserProjectsFavorites _Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Warnings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproval = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    WarningNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Warnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Warnings_Pms_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Warnings_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Workflows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LookupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlertDays = table.Column<int>(type: "int", nullable: false),
                    ApprovalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Classification = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SendDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TabName = table.Column<int>(type: "int", nullable: true),
                    UserIdFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserNameFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkflowStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Workflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Workflows_AbpUsers_UserIdFrom",
                        column: x => x.UserIdFrom,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Workflows_AbpUsers_UserIdTo",
                        column: x => x.UserIdTo,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Workflows_Pms_Approvals_ApprovalId",
                        column: x => x.ApprovalId,
                        principalTable: "Pms_Approvals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Workflows_Pms_Lookups_LookupId",
                        column: x => x.LookupId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Workflows_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Pms_EvaluationResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormStandardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReffrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    AgentProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_EvaluationResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_EvaluationResults_Pms_AgentProjects_AgentProjectId",
                        column: x => x.AgentProjectId,
                        principalTable: "Pms_AgentProjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_EvaluationResults_Pms_FormStandards_FormStandardId",
                        column: x => x.FormStandardId,
                        principalTable: "Pms_FormStandards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_EvaluationResults_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pms_ExtensionReasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Constructerdays = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Engineerdays = table.Column<int>(type: "int", nullable: false),
                    ExtensionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Reasons = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_ExtensionReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_ExtensionReasons_Pms_DurationExtensions_ExtensionId",
                        column: x => x.ExtensionId,
                        principalTable: "Pms_DurationExtensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_MeetingInvitations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    InviteesType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReffrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_MeetingInvitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_MeetingInvitations_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_MeetingInvitations_Pms_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_MeetingInvitations_Pms_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Pms_Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Dependency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    predecessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    successorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Dependency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Dependency_Pms_ProjectTasks_predecessorId",
                        column: x => x.predecessorId,
                        principalTable: "Pms_ProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Dependency_Pms_ProjectTasks_successorId",
                        column: x => x.successorId,
                        principalTable: "Pms_ProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_MemberTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_MemberTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_MemberTasks_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_MemberTasks_Pms_ProjectTasks_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalTable: "Pms_ProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_ProjectExtenstionTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ExtenstionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsApproval = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_ProjectExtenstionTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectExtenstionTasks_Pms_DurationExtensions_ExtenstionId",
                        column: x => x.ExtenstionId,
                        principalTable: "Pms_DurationExtensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectExtenstionTasks_Pms_ProjectTasks_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalTable: "Pms_ProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fines = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Invoices_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Invoices_Pms_SubAgents_SubAgentId",
                        column: x => x.SubAgentId,
                        principalTable: "Pms_SubAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_AgentId",
                table: "Pms_Documents",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_ChangeRequestId",
                table: "Pms_Documents",
                column: "ChangeRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_DrawingId",
                table: "Pms_Documents",
                column: "DrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_FormId",
                table: "Pms_Documents",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_InvoiceId",
                table: "Pms_Documents",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_MeetingId",
                table: "Pms_Documents",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_OtherProjectFormId",
                table: "Pms_Documents",
                column: "OtherProjectFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_ProjectAttachmentId",
                table: "Pms_Documents",
                column: "ProjectAttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_ProjectId",
                table: "Pms_Documents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_ReportId",
                table: "Pms_Documents",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_WarningId",
                table: "Pms_Documents",
                column: "WarningId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_AgentProjects_AgentId",
                table: "Pms_AgentProjects",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_AgentProjects_EvaluationFormId",
                table: "Pms_AgentProjects",
                column: "EvaluationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_AgentProjects_ProjectId",
                table: "Pms_AgentProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Agents_CategoryId",
                table: "Pms_Agents",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Agents_DegreeId",
                table: "Pms_Agents",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Approvals_UserId",
                table: "Pms_Approvals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ChangeRequests_AgentId",
                table: "Pms_ChangeRequests",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ChangeRequests_ProjectId",
                table: "Pms_ChangeRequests",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Dependency_predecessorId",
                table: "Pms_Dependency",
                column: "predecessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Dependency_successorId",
                table: "Pms_Dependency",
                column: "successorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_DependencyProjects_DependencyProjectId",
                table: "Pms_DependencyProjects",
                column: "DependencyProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_DependencyProjects_ProjectId",
                table: "Pms_DependencyProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Drawing_DrawingMapId",
                table: "Pms_Drawing",
                column: "DrawingMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Drawing_FormId",
                table: "Pms_Drawing",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Drawing_ProjectId",
                table: "Pms_Drawing",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_DurationExtensions_AgentId",
                table: "Pms_DurationExtensions",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_DurationExtensions_ProjectId",
                table: "Pms_DurationExtensions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_EvaluationResults_AgentProjectId",
                table: "Pms_EvaluationResults",
                column: "AgentProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_EvaluationResults_FormStandardId",
                table: "Pms_EvaluationResults",
                column: "FormStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_EvaluationResults_ProjectId",
                table: "Pms_EvaluationResults",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ExtensionReasons_ExtensionId",
                table: "Pms_ExtensionReasons",
                column: "ExtensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Forms_ProjectTypeId",
                table: "Pms_Forms",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_FormStandards_FormId",
                table: "Pms_FormStandards",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_FormStandards_StandardId",
                table: "Pms_FormStandards",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_FormStandards_StandardsSectionId",
                table: "Pms_FormStandards",
                column: "StandardsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Invoices_ProjectId",
                table: "Pms_Invoices",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Invoices_SubAgentId",
                table: "Pms_Invoices",
                column: "SubAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_MeetingInvitations_AgentId",
                table: "Pms_MeetingInvitations",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_MeetingInvitations_MeetingId",
                table: "Pms_MeetingInvitations",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_MeetingInvitations_UserId",
                table: "Pms_MeetingInvitations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Meetings_ProjectId",
                table: "Pms_Meetings",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Members_ProjectId",
                table: "Pms_Members",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Members_TypeId",
                table: "Pms_Members",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Members_UserId",
                table: "Pms_Members",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_MemberTasks_ProjectTaskId",
                table: "Pms_MemberTasks",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_MemberTasks_UserId",
                table: "Pms_MemberTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_OtherProjectForm_FormId",
                table: "Pms_OtherProjectForm",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_OtherProjectForm_ProjectId",
                table: "Pms_OtherProjectForm",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectAttachment_AgentId",
                table: "Pms_ProjectAttachment",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectAttachment_ProjectAttachmentTypeId",
                table: "Pms_ProjectAttachment",
                column: "ProjectAttachmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectAttachment_ProjectId",
                table: "Pms_ProjectAttachment",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectCameras_ProjectId",
                table: "Pms_ProjectCameras",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectExtenstionTasks_ExtenstionId",
                table: "Pms_ProjectExtenstionTasks",
                column: "ExtenstionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectExtenstionTasks_ProjectTaskId",
                table: "Pms_ProjectExtenstionTasks",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectHistories_ProjectId",
                table: "Pms_ProjectHistories",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Projects_OrganizationUnitId",
                table: "Pms_Projects",
                column: "OrganizationUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Projects_PhaseId",
                table: "Pms_Projects",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Projects_ProjectStatueId",
                table: "Pms_Projects",
                column: "ProjectStatueId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Projects_ProjectTypeId",
                table: "Pms_Projects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectTasks_ParentId",
                table: "Pms_ProjectTasks",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectTasks_ProjectId",
                table: "Pms_ProjectTasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectTypePhases_PhaseId",
                table: "Pms_ProjectTypePhases",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectTypePhases_ProjectTypeId",
                table: "Pms_ProjectTypePhases",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Schedulars_userId",
                table: "Pms_Schedulars",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_SubAgents_ProjectId",
                table: "Pms_SubAgents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserAttachmentTypePermission_ProjectAttachmentTypeId",
                table: "Pms_UserAttachmentTypePermission",
                column: "ProjectAttachmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserAttachmentTypePermission_UserId_ProjectAttachmentTypeId",
                table: "Pms_UserAttachmentTypePermission",
                columns: new[] { "UserId", "ProjectAttachmentTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserDrawingTypePermission_FormId",
                table: "Pms_UserDrawingTypePermission",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserDrawingTypePermission_UserId_FormId",
                table: "Pms_UserDrawingTypePermission",
                columns: new[] { "UserId", "FormId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserPolicy_UserId",
                table: "Pms_UserPolicy",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserProjectsFavorites _ProjectId_UserId",
                table: "Pms_UserProjectsFavorites ",
                columns: new[] { "ProjectId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserProjectsFavorites _UserId",
                table: "Pms_UserProjectsFavorites ",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserProjectTypePermissions_ProjectTypeId",
                table: "Pms_UserProjectTypePermissions",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserProjectTypePermissions_UserId_ProjectTypeId",
                table: "Pms_UserProjectTypePermissions",
                columns: new[] { "UserId", "ProjectTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserReportPermissions_ReportId",
                table: "Pms_UserReportPermissions",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserReportPermissions_UserId_ReportId",
                table: "Pms_UserReportPermissions",
                columns: new[] { "UserId", "ReportId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserStandardsSectionPermissions_StandardsSectionId",
                table: "Pms_UserStandardsSectionPermissions",
                column: "StandardsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserStandardsSectionPermissions_UserId_StandardsSectionId",
                table: "Pms_UserStandardsSectionPermissions",
                columns: new[] { "UserId", "StandardsSectionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserTenantPermissions_TenantId",
                table: "Pms_UserTenantPermissions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserTenantPermissions_UserId_TenantId",
                table: "Pms_UserTenantPermissions",
                columns: new[] { "UserId", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Warnings_AgentId",
                table: "Pms_Warnings",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Warnings_ProjectId",
                table: "Pms_Warnings",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Workflows_ApprovalId",
                table: "Pms_Workflows",
                column: "ApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Workflows_LookupId",
                table: "Pms_Workflows",
                column: "LookupId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Workflows_ProjectId",
                table: "Pms_Workflows",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Workflows_UserIdFrom",
                table: "Pms_Workflows",
                column: "UserIdFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Workflows_UserIdTo",
                table: "Pms_Workflows",
                column: "UserIdTo");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_Agents_AgentId",
                table: "Pms_Documents",
                column: "AgentId",
                principalTable: "Pms_Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_ChangeRequests_ChangeRequestId",
                table: "Pms_Documents",
                column: "ChangeRequestId",
                principalTable: "Pms_ChangeRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_Drawing_DrawingId",
                table: "Pms_Documents",
                column: "DrawingId",
                principalTable: "Pms_Drawing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_Forms_FormId",
                table: "Pms_Documents",
                column: "FormId",
                principalTable: "Pms_Forms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_Invoices_InvoiceId",
                table: "Pms_Documents",
                column: "InvoiceId",
                principalTable: "Pms_Invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_Meetings_MeetingId",
                table: "Pms_Documents",
                column: "MeetingId",
                principalTable: "Pms_Meetings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_OtherProjectForm_OtherProjectFormId",
                table: "Pms_Documents",
                column: "OtherProjectFormId",
                principalTable: "Pms_OtherProjectForm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_ProjectAttachment_ProjectAttachmentId",
                table: "Pms_Documents",
                column: "ProjectAttachmentId",
                principalTable: "Pms_ProjectAttachment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_Projects_ProjectId",
                table: "Pms_Documents",
                column: "ProjectId",
                principalTable: "Pms_Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_Reports_ReportId",
                table: "Pms_Documents",
                column: "ReportId",
                principalTable: "Pms_Reports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_Warnings_WarningId",
                table: "Pms_Documents",
                column: "WarningId",
                principalTable: "Pms_Warnings",
                principalColumn: "Id");
        }
    }
}
