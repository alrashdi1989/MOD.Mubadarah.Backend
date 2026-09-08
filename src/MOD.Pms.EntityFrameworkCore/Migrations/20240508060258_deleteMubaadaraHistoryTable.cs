using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class deleteMubaadaraHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mub_MubaadaraHistory");

            migrationBuilder.AddColumn<DateTime>(
                name: "NewEndDate",
                table: "Mub_MubaadarasWorkflow",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewEndDate",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.CreateTable(
                name: "Mub_MubaadaraHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColumnName = table.Column<int>(type: "int", nullable: true),
                    CompletionPercentageNV = table.Column<int>(type: "int", nullable: true),
                    CompletionPercentageOV = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateNV = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateOV = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusIdNV = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusIdOV = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkflowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mub_MubaadaraHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mub_MubaadaraHistory_Mub_MubaadarasWorkflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Mub_MubaadarasWorkflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mub_MubaadaraHistory_WorkflowId",
                table: "Mub_MubaadaraHistory",
                column: "WorkflowId");
        }
    }
}
