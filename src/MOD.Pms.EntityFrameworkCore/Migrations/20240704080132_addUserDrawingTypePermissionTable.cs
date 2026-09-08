using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addUserDrawingTypePermissionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pms_UserDrawingTypePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserDrawingTypePermission_FormId",
                table: "Pms_UserDrawingTypePermission",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserDrawingTypePermission_UserId_FormId",
                table: "Pms_UserDrawingTypePermission",
                columns: new[] { "UserId", "FormId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pms_UserDrawingTypePermission");
        }
    }
}
