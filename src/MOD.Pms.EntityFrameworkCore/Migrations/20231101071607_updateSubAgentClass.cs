using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateSubAgentClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_SubAgents_Pms_Agents_AgentId",
                table: "Pms_SubAgents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_SubAgents_AgentId",
                table: "Pms_SubAgents");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Pms_SubAgents");

            migrationBuilder.AddColumn<string>(
                name: "ArabicName",
                table: "Pms_SubAgents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Pms_SubAgents",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArabicName",
                table: "Pms_SubAgents");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Pms_SubAgents");

            migrationBuilder.AddColumn<Guid>(
                name: "AgentId",
                table: "Pms_SubAgents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pms_SubAgents_AgentId",
                table: "Pms_SubAgents",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_SubAgents_Pms_Agents_AgentId",
                table: "Pms_SubAgents",
                column: "AgentId",
                principalTable: "Pms_Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
