using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class creatUserOrganizationUnitPermissionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pms_UserOrganizationUnitPermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserOrganizationUnitPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_UserOrganizationUnitPermission_AbpOrganizationUnits_OrganizationUnitId",
                        column: x => x.OrganizationUnitId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_UserOrganizationUnitPermission_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserOrganizationUnitPermission_OrganizationUnitId",
                table: "Pms_UserOrganizationUnitPermission",
                column: "OrganizationUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserOrganizationUnitPermission_UserId_OrganizationUnitId",
                table: "Pms_UserOrganizationUnitPermission",
                columns: new[] { "UserId", "OrganizationUnitId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pms_UserOrganizationUnitPermission");
        }
    }
}
