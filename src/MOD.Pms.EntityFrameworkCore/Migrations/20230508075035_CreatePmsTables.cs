using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class CreatePmsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pms_Approvals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TabName = table.Column<int>(type: "int", nullable: false),
                    ReffrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Pms_Approvals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Approvals_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Lookups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    LookupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Pms_Lookups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Lookups_Pms_Lookups_LookupId",
                        column: x => x.LookupId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabicPositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnglishPositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabicRankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnglishRankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Pms_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pms_UserDashBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DashBoardName = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Pms_UserDashBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Agents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DegreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBloked = table.Column<bool>(type: "bit", maxLength: 5, nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OmanizationRaito = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NibrasId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
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
                name: "Pms_Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    IsSecret = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    TabName = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Pms_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Forms_Pms_Lookups_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LetterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MotoilizationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoteCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProjectNumber = table.Column<int>(type: "int", nullable: false),
                    ApproximateAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsuranceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CameraIPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuldingArea = table.Column<double>(type: "float", nullable: false),
                    ProjectStatueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
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
                name: "Pms_UserReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Pms_FormStandards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StandardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Pms_AgentProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CumulativePercentage = table.Column<int>(type: "int", nullable: false),
                    Desecription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeReasons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentOffers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinanceChange = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DependencyProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    IsApproval = table.Column<bool>(type: "bit", nullable: false),
                    DrawingMapId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Pms_Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Fines = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Pms_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Invoices_Pms_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_Invoices_Pms_Projects_ProjectId",
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
                    MeetingTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingTerms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MeetingStatus = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Pms_Performances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scheduleProgress = table.Column<double>(type: "float", nullable: false),
                    actualProgress = table.Column<double>(type: "float", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Pms_Performances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Performances_Pms_Projects_ProjectId",
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
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectAttachmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarrantyStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarrantyPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceNumber = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Pms_SubAgents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractorTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
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
                    table.PrimaryKey("PK_Pms_SubAgents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_SubAgents_Pms_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_SubAgents_Pms_Lookups_ContractorTypeId",
                        column: x => x.ContractorTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_SubAgents_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_Tenders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvitationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnnouncementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastDateOfPurchaseDocument = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiptOffersDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenderType = table.Column<int>(type: "int", nullable: false),
                    NumberOfAgentsPurchesedDocument = table.Column<int>(type: "int", nullable: false),
                    NumberOfAgentsSubmitedBid = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsApprved = table.Column<bool>(type: "bit", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcceptedAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                name: "Pms_UserProjectsFavorites ",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserProjectsFavorites ", x => x.Id);
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
                    Type = table.Column<int>(type: "int", nullable: false),
                    WarningNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserNameFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIdTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserNameTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlertDays = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<int>(type: "int", nullable: false),
                    WorkflowStatus = table.Column<int>(type: "int", nullable: false),
                    ApprovalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LookupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Pms_Workflows_Pms_Lookups_LookupId",
                        column: x => x.LookupId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pms_Workflows_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pms_EvaluationResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReffrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormStandardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    Reasons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Constructerdays = table.Column<int>(type: "int", nullable: false),
                    Engineerdays = table.Column<int>(type: "int", nullable: false),
                    ExtensionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    ReffrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InviteesType = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                name: "Pms_ProjectTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerformanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Pms_ProjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectTasks_Pms_Performances_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "Pms_Performances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Pms_TenderForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenderFormDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Describtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    TenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PeriodOfValidateOffer = table.Column<int>(type: "int", nullable: false),
                    PeriodOfValidateBankInssurance = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApplicalbleContacrtCondition = table.Column<bool>(type: "bit", nullable: false),
                    TechnicalAnalysisFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialAnalysisFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IfAcceptedoffer = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Pms_Dependency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    predecessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    successorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Duration = table.Column<int>(type: "int", nullable: false),
                    IsApproval = table.Column<bool>(type: "bit", nullable: false),
                    ExtenstionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Pms_AnalysisResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReffrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormStandardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnalysisesResultType = table.Column<int>(type: "int", nullable: true),
                    TenderOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Pms_Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReffrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DrawingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectAttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenderFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenderOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarningId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
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
                    table.PrimaryKey("PK_Pms_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Documents_Pms_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Documents_Pms_Drawing_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Pms_Drawing",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Documents_Pms_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Pms_Forms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Documents_Pms_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Pms_Invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Documents_Pms_Lookups_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Documents_Pms_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Pms_Meetings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Documents_Pms_ProjectAttachment_ProjectAttachmentId",
                        column: x => x.ProjectAttachmentId,
                        principalTable: "Pms_ProjectAttachment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Documents_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Documents_Pms_TenderForms_TenderFormId",
                        column: x => x.TenderFormId,
                        principalTable: "Pms_TenderForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pms_Documents_Pms_TenderOffers_TenderOfferId",
                        column: x => x.TenderOfferId,
                        principalTable: "Pms_TenderOffers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Documents_Pms_Warnings_WarningId",
                        column: x => x.WarningId,
                        principalTable: "Pms_Warnings",
                        principalColumn: "Id");
                });

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
                name: "IX_Pms_Documents_AgentId",
                table: "Pms_Documents",
                column: "AgentId");

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
                name: "IX_Pms_Documents_TenderFormId",
                table: "Pms_Documents",
                column: "TenderFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_TenderOfferId",
                table: "Pms_Documents",
                column: "TenderOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_WarningId",
                table: "Pms_Documents",
                column: "WarningId");

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
                name: "IX_Pms_Invoices_AgentId",
                table: "Pms_Invoices",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Invoices_ProjectId",
                table: "Pms_Invoices",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Lookups_LookupId",
                table: "Pms_Lookups",
                column: "LookupId");

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
                name: "IX_Pms_Performances_ProjectId",
                table: "Pms_Performances",
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
                name: "IX_Pms_ProjectExtenstionTasks_ExtenstionId",
                table: "Pms_ProjectExtenstionTasks",
                column: "ExtenstionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectExtenstionTasks_ProjectTaskId",
                table: "Pms_ProjectExtenstionTasks",
                column: "ProjectTaskId");

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
                name: "IX_Pms_ProjectTasks_PerformanceId",
                table: "Pms_ProjectTasks",
                column: "PerformanceId");

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
                name: "IX_Pms_SubAgents_AgentId",
                table: "Pms_SubAgents",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_SubAgents_ContractorTypeId",
                table: "Pms_SubAgents",
                column: "ContractorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_SubAgents_ProjectId",
                table: "Pms_SubAgents",
                column: "ProjectId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserProjectsFavorites _ProjectId_UserId",
                table: "Pms_UserProjectsFavorites ",
                columns: new[] { "ProjectId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserReports_ReportId",
                table: "Pms_UserReports",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserReports_UserId",
                table: "Pms_UserReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Warnings_AgentId",
                table: "Pms_Warnings",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Warnings_ProjectId",
                table: "Pms_Warnings",
                column: "ProjectId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pms_AnalysisResults");

            migrationBuilder.DropTable(
                name: "Pms_Approvals");

            migrationBuilder.DropTable(
                name: "Pms_ChangeRequests");

            migrationBuilder.DropTable(
                name: "Pms_Dependency");

            migrationBuilder.DropTable(
                name: "Pms_DependencyProjects");

            migrationBuilder.DropTable(
                name: "Pms_Documents");

            migrationBuilder.DropTable(
                name: "Pms_EvaluationResults");

            migrationBuilder.DropTable(
                name: "Pms_ExtensionReasons");

            migrationBuilder.DropTable(
                name: "Pms_MeetingInvitations");

            migrationBuilder.DropTable(
                name: "Pms_Members");

            migrationBuilder.DropTable(
                name: "Pms_MemberTasks");

            migrationBuilder.DropTable(
                name: "Pms_Positions");

            migrationBuilder.DropTable(
                name: "Pms_ProjectExtenstionTasks");

            migrationBuilder.DropTable(
                name: "Pms_ProjectTypePhases");

            migrationBuilder.DropTable(
                name: "Pms_SubAgents");

            migrationBuilder.DropTable(
                name: "Pms_UserDashBoards");

            migrationBuilder.DropTable(
                name: "Pms_UserProjectsFavorites ");

            migrationBuilder.DropTable(
                name: "Pms_UserReports");

            migrationBuilder.DropTable(
                name: "Pms_Workflows");

            migrationBuilder.DropTable(
                name: "Pms_Drawing");

            migrationBuilder.DropTable(
                name: "Pms_Invoices");

            migrationBuilder.DropTable(
                name: "Pms_ProjectAttachment");

            migrationBuilder.DropTable(
                name: "Pms_TenderForms");

            migrationBuilder.DropTable(
                name: "Pms_TenderOffers");

            migrationBuilder.DropTable(
                name: "Pms_Warnings");

            migrationBuilder.DropTable(
                name: "Pms_AgentProjects");

            migrationBuilder.DropTable(
                name: "Pms_FormStandards");

            migrationBuilder.DropTable(
                name: "Pms_Meetings");

            migrationBuilder.DropTable(
                name: "Pms_DurationExtensions");

            migrationBuilder.DropTable(
                name: "Pms_ProjectTasks");

            migrationBuilder.DropTable(
                name: "Pms_Tenders");

            migrationBuilder.DropTable(
                name: "Pms_Forms");

            migrationBuilder.DropTable(
                name: "Pms_Performances");

            migrationBuilder.DropTable(
                name: "Pms_Agents");

            migrationBuilder.DropTable(
                name: "Pms_Projects");

            migrationBuilder.DropTable(
                name: "Pms_Lookups");
        }
    }
}
