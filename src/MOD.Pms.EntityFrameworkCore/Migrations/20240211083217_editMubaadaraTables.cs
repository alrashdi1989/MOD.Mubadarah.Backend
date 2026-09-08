using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class editMubaadaraTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Mubaadaras_Pms_Lookups_InputStatusId",
                table: "Pms_Mubaadaras");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Mubaadaras_Pms_Lookups_InputTypeId",
                table: "Pms_Mubaadaras");

            migrationBuilder.DropTable(
                name: "Pms_MubaadaraChallenges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pms_Mubaadaras",
                table: "Pms_Mubaadaras");

            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Pms_Mubaadaras");

            migrationBuilder.DropColumn(
                name: "DepartmentArabicName",
                table: "Pms_Mubaadaras");

            migrationBuilder.DropColumn(
                name: "DepartmentEnglishName",
                table: "Pms_Mubaadaras");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Pms_Mubaadaras");

            migrationBuilder.DropColumn(
                name: "MainUnitArabicName",
                table: "Pms_Mubaadaras");

            migrationBuilder.DropColumn(
                name: "MainUnitEnglishName",
                table: "Pms_Mubaadaras");

            migrationBuilder.DropColumn(
                name: "UnitArabicName",
                table: "Pms_Mubaadaras");

            migrationBuilder.DropColumn(
                name: "UnitEnglishName",
                table: "Pms_Mubaadaras");

            migrationBuilder.RenameTable(
                name: "Pms_Mubaadaras",
                newName: "Mub_Mubaadaras");

            migrationBuilder.RenameColumn(
                name: "Months",
                table: "Mub_Mubaadaras",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "MainUnitId",
                table: "Mub_Mubaadaras",
                newName: "ManagerId");

            migrationBuilder.RenameColumn(
                name: "InputYear",
                table: "Mub_Mubaadaras",
                newName: "Month");

            migrationBuilder.RenameColumn(
                name: "InputTypeId",
                table: "Mub_Mubaadaras",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "InputStatusId",
                table: "Mub_Mubaadaras",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "ApproximateAmount",
                table: "Mub_Mubaadaras",
                newName: "Amount");

            migrationBuilder.RenameIndex(
                name: "IX_Pms_Mubaadaras_InputTypeId",
                table: "Mub_Mubaadaras",
                newName: "IX_Mub_Mubaadaras_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Pms_Mubaadaras_InputStatusId",
                table: "Mub_Mubaadaras",
                newName: "IX_Mub_Mubaadaras_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mub_Mubaadaras",
                table: "Mub_Mubaadaras",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Mub_MubaadaraDetails",
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
                    table.PrimaryKey("PK_Mub_MubaadaraDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mub_MubaadaraDetails_Mub_Mubaadaras_MubaadaraId",
                        column: x => x.MubaadaraId,
                        principalTable: "Mub_Mubaadaras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mub_MubaadaraDetails_MubaadaraId",
                table: "Mub_MubaadaraDetails",
                column: "MubaadaraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mub_Mubaadaras_Pms_Lookups_StatusId",
                table: "Mub_Mubaadaras",
                column: "StatusId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mub_Mubaadaras_Pms_Lookups_TypeId",
                table: "Mub_Mubaadaras",
                column: "TypeId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mub_Mubaadaras_Pms_Lookups_StatusId",
                table: "Mub_Mubaadaras");

            migrationBuilder.DropForeignKey(
                name: "FK_Mub_Mubaadaras_Pms_Lookups_TypeId",
                table: "Mub_Mubaadaras");

            migrationBuilder.DropTable(
                name: "Mub_MubaadaraDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mub_Mubaadaras",
                table: "Mub_Mubaadaras");

            migrationBuilder.RenameTable(
                name: "Mub_Mubaadaras",
                newName: "Pms_Mubaadaras");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Pms_Mubaadaras",
                newName: "Months");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Pms_Mubaadaras",
                newName: "InputTypeId");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Pms_Mubaadaras",
                newName: "InputStatusId");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "Pms_Mubaadaras",
                newName: "InputYear");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Pms_Mubaadaras",
                newName: "MainUnitId");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Pms_Mubaadaras",
                newName: "ApproximateAmount");

            migrationBuilder.RenameIndex(
                name: "IX_Mub_Mubaadaras_TypeId",
                table: "Pms_Mubaadaras",
                newName: "IX_Pms_Mubaadaras_InputTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Mub_Mubaadaras_StatusId",
                table: "Pms_Mubaadaras",
                newName: "IX_Pms_Mubaadaras_InputStatusId");

            migrationBuilder.AddColumn<string>(
                name: "Admin",
                table: "Pms_Mubaadaras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentArabicName",
                table: "Pms_Mubaadaras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentEnglishName",
                table: "Pms_Mubaadaras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "Pms_Mubaadaras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainUnitArabicName",
                table: "Pms_Mubaadaras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainUnitEnglishName",
                table: "Pms_Mubaadaras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitArabicName",
                table: "Pms_Mubaadaras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitEnglishName",
                table: "Pms_Mubaadaras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pms_Mubaadaras",
                table: "Pms_Mubaadaras",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pms_MubaadaraChallenges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Challenge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MubaadaraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Mubaadaras_Pms_Lookups_InputStatusId",
                table: "Pms_Mubaadaras",
                column: "InputStatusId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Mubaadaras_Pms_Lookups_InputTypeId",
                table: "Pms_Mubaadaras",
                column: "InputTypeId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");
        }
    }
}
