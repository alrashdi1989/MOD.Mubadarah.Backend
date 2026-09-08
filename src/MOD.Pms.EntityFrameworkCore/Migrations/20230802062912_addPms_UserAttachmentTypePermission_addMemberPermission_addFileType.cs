using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addPms_UserAttachmentTypePermission_addMemberPermission_addFileType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberPermission",
                table: "Pms_Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "Pms_Lookups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Pms_Approvals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pms_UserAttachmentTypePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectAttachmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pms_UserAttachmentTypePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_UserAttachmentTypePermission_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_UserAttachmentTypePermission_Pms_Lookups_ProjectAttachmentTypeId",
                        column: x => x.ProjectAttachmentTypeId,
                        principalTable: "Pms_Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserAttachmentTypePermission_ProjectAttachmentTypeId",
                table: "Pms_UserAttachmentTypePermission",
                column: "ProjectAttachmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserAttachmentTypePermission_UserId_ProjectAttachmentTypeId",
                table: "Pms_UserAttachmentTypePermission",
                columns: new[] { "UserId", "ProjectAttachmentTypeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pms_UserAttachmentTypePermission");

            migrationBuilder.DropColumn(
                name: "MemberPermission",
                table: "Pms_Members");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Pms_Lookups");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Pms_Approvals");
        }
    }
}
