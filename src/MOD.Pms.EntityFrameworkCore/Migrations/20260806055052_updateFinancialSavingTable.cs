using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateFinancialSavingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PriceBeforeNegotitation",
                table: "Nebars_FinancialSaving",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ProposalId",
                table: "Nebars_FinancialSaving",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "Nebars_FinancialSaving",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_FinancialSaving_SupplierId",
                table: "Nebars_FinancialSaving",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_FinancialSaving_Pms_Agents_SupplierId",
                table: "Nebars_FinancialSaving",
                column: "SupplierId",
                principalTable: "Pms_Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_FinancialSaving_Pms_Agents_SupplierId",
                table: "Nebars_FinancialSaving");

            migrationBuilder.DropIndex(
                name: "IX_Nebars_FinancialSaving_SupplierId",
                table: "Nebars_FinancialSaving");

            migrationBuilder.DropColumn(
                name: "PriceBeforeNegotitation",
                table: "Nebars_FinancialSaving");

            migrationBuilder.DropColumn(
                name: "ProposalId",
                table: "Nebars_FinancialSaving");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Nebars_FinancialSaving");
        }
    }
}
