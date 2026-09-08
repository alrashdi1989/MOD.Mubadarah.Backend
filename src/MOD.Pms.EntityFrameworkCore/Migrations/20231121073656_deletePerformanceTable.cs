using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class deletePerformanceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_ProjectTasks_Pms_Performances_PerformanceId",
                table: "Pms_ProjectTasks");

            migrationBuilder.DropTable(
                name: "Pms_Performances");

            migrationBuilder.DropIndex(
                name: "IX_Pms_ProjectTasks_PerformanceId",
                table: "Pms_ProjectTasks");

            migrationBuilder.DropColumn(
                name: "PerformanceId",
                table: "Pms_ProjectTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PerformanceId",
                table: "Pms_ProjectTasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pms_Performances",
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
                    TaskDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actualProgress = table.Column<double>(type: "float", nullable: true),
                    scheduleProgress = table.Column<double>(type: "float", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectTasks_PerformanceId",
                table: "Pms_ProjectTasks",
                column: "PerformanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Performances_ProjectId",
                table: "Pms_Performances",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_ProjectTasks_Pms_Performances_PerformanceId",
                table: "Pms_ProjectTasks",
                column: "PerformanceId",
                principalTable: "Pms_Performances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
