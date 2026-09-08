using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addMubaadaraTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pms_Mubaadaras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InputTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputYear = table.Column<int>(type: "int", nullable: false),
                    Months = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MainUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MainUnitArabicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainUnitEnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitArabicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitEnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentArabicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentEnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Admin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InputStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompletionPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApproximateAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Pms_Mubaadaras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_Mubaadaras_Pms_Lookups_InputStatusId",
                        column: x => x.InputStatusId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pms_Mubaadaras_Pms_Lookups_InputTypeId",
                        column: x => x.InputTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pms_MubaadaraChallenges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MubaadaraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Challenge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Pms_MubaadaraChallenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_MubaadaraChallenges_Pms_Mubaadaras_MubaadaraId",
                        column: x => x.MubaadaraId,
                        principalTable: "Pms_Mubaadaras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_MubaadaraChallenges_MubaadaraId",
                table: "Pms_MubaadaraChallenges",
                column: "MubaadaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Mubaadaras_InputStatusId",
                table: "Pms_Mubaadaras",
                column: "InputStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Mubaadaras_InputTypeId",
                table: "Pms_Mubaadaras",
                column: "InputTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pms_MubaadaraChallenges");

            migrationBuilder.DropTable(
                name: "Pms_Mubaadaras");
        }
    }
}
