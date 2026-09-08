using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateSubAgentClass2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_SubAgents_Pms_Lookups_ContractorTypeId",
                table: "Pms_SubAgents");

            migrationBuilder.DropIndex(
                name: "IX_Pms_SubAgents_ContractorTypeId",
                table: "Pms_SubAgents");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContractorTypeId",
                table: "Pms_SubAgents",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ContractorTypeId",
                table: "Pms_SubAgents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_SubAgents_ContractorTypeId",
                table: "Pms_SubAgents",
                column: "ContractorTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_SubAgents_Pms_Lookups_ContractorTypeId",
                table: "Pms_SubAgents",
                column: "ContractorTypeId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
