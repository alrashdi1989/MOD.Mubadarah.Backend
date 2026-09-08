using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addUserprojectTypeAndTenantPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pms_UserProjectTypePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "Pms_UserTenantPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "IX_Pms_UserTenantPermissions_TenantId",
                table: "Pms_UserTenantPermissions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserTenantPermissions_UserId_TenantId",
                table: "Pms_UserTenantPermissions",
                columns: new[] { "UserId", "TenantId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pms_UserProjectTypePermissions");

            migrationBuilder.DropTable(
                name: "Pms_UserTenantPermissions");
        }
    }
}
