using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class projectCameras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CameraIPAddress",
                table: "Pms_Projects");

            migrationBuilder.CreateTable(
                name: "Pms_ProjectCameras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CameraIPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Pms_ProjectCameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_ProjectCameras_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_ProjectCameras_ProjectId",
                table: "Pms_ProjectCameras",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pms_ProjectCameras");

            migrationBuilder.AddColumn<string>(
                name: "CameraIPAddress",
                table: "Pms_Projects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
