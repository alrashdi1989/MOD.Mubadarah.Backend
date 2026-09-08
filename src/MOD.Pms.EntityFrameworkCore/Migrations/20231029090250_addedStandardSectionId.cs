using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addedStandardSectionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StandardsSectionId",
                table: "Pms_FormStandards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_FormStandards_StandardsSectionId",
                table: "Pms_FormStandards",
                column: "StandardsSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_FormStandards_Pms_Lookups_StandardsSectionId",
                table: "Pms_FormStandards",
                column: "StandardsSectionId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_FormStandards_Pms_Lookups_StandardsSectionId",
                table: "Pms_FormStandards");

            migrationBuilder.DropIndex(
                name: "IX_Pms_FormStandards_StandardsSectionId",
                table: "Pms_FormStandards");

            migrationBuilder.DropColumn(
                name: "StandardsSectionId",
                table: "Pms_FormStandards");
        }
    }
}
