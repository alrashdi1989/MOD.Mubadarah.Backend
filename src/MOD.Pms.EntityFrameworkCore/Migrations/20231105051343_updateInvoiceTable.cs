using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Invoices_Pms_Agents_AgentId",
                table: "Pms_Invoices");

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "Pms_Invoices",
                newName: "TenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Pms_Invoices_AgentId",
                table: "Pms_Invoices",
                newName: "IX_Pms_Invoices_TenderId");

            migrationBuilder.AddColumn<Guid>(
                name: "SubAgentId",
                table: "Pms_Invoices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Invoices_SubAgentId",
                table: "Pms_Invoices",
                column: "SubAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Invoices_Pms_SubAgents_SubAgentId",
                table: "Pms_Invoices",
                column: "SubAgentId",
                principalTable: "Pms_SubAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Invoices_Pms_Tenders_TenderId",
                table: "Pms_Invoices",
                column: "TenderId",
                principalTable: "Pms_Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Invoices_Pms_SubAgents_SubAgentId",
                table: "Pms_Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Invoices_Pms_Tenders_TenderId",
                table: "Pms_Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Invoices_SubAgentId",
                table: "Pms_Invoices");

            migrationBuilder.DropColumn(
                name: "SubAgentId",
                table: "Pms_Invoices");

            migrationBuilder.RenameColumn(
                name: "TenderId",
                table: "Pms_Invoices",
                newName: "AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Pms_Invoices_TenderId",
                table: "Pms_Invoices",
                newName: "IX_Pms_Invoices_AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Invoices_Pms_Agents_AgentId",
                table: "Pms_Invoices",
                column: "AgentId",
                principalTable: "Pms_Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
