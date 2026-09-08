using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addOtherProjectFormsTableanddocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OtherProjectFormId",
                table: "Pms_Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pms_OtherProjectForm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsApproval = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherProjectFormDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Describtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Pms_OtherProjectForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pms_OtherProjectForm_Pms_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Pms_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pms_OtherProjectForm_Pms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Pms_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Documents_OtherProjectFormId",
                table: "Pms_Documents",
                column: "OtherProjectFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_OtherProjectForm_FormId",
                table: "Pms_OtherProjectForm",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_OtherProjectForm_ProjectId",
                table: "Pms_OtherProjectForm",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_OtherProjectForm_OtherProjectFormId",
                table: "Pms_Documents",
                column: "OtherProjectFormId",
                principalTable: "Pms_OtherProjectForm",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_OtherProjectForm_OtherProjectFormId",
                table: "Pms_Documents");

            migrationBuilder.DropTable(
                name: "Pms_OtherProjectForm");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Documents_OtherProjectFormId",
                table: "Pms_Documents");

            migrationBuilder.DropColumn(
                name: "OtherProjectFormId",
                table: "Pms_Documents");
        }
    }
}
