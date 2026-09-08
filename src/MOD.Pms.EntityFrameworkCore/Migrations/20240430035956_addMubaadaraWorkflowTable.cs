using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addMubaadaraWorkflowTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "Mub_MubaadarasWorkflow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MubaadaraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserNameFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserNameTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classification = table.Column<int>(type: "int", nullable: true),
                    WorkflowStatus = table.Column<int>(type: "int", nullable: true),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    MubaadaraRequests = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Mub_MubaadarasWorkflow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mub_MubaadarasWorkflow_AbpUsers_UserIdFrom",
                        column: x => x.UserIdFrom,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mub_MubaadarasWorkflow_AbpUsers_UserIdTo",
                        column: x => x.UserIdTo,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mub_MubaadarasWorkflow_Mub_Mubaadaras_MubaadaraId",
                        column: x => x.MubaadaraId,
                        principalTable: "Mub_Mubaadaras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mub_MubaadarasWorkflow_MubaadaraId",
                table: "Mub_MubaadarasWorkflow",
                column: "MubaadaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Mub_MubaadarasWorkflow_UserIdFrom",
                table: "Mub_MubaadarasWorkflow",
                column: "UserIdFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Mub_MubaadarasWorkflow_UserIdTo",
                table: "Mub_MubaadarasWorkflow",
                column: "UserIdTo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Mub_Mubaadaras");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "Mub_Mubaadaras");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Mub_Mubaadaras");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Mub_Mubaadaras");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Mub_Mubaadaras");
        }
    }
}
