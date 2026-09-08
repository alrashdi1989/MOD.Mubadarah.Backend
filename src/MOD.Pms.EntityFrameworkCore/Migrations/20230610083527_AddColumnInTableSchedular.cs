using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnInTableSchedular : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "Pms_Schedulars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pms_Schedulars_userId",
                table: "Pms_Schedulars",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Schedulars_AbpUsers_userId",
                table: "Pms_Schedulars",
                column: "userId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Schedulars_AbpUsers_userId",
                table: "Pms_Schedulars");

            migrationBuilder.DropIndex(
                name: "IX_Pms_Schedulars_userId",
                table: "Pms_Schedulars");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Pms_Schedulars");
        }
    }
}
