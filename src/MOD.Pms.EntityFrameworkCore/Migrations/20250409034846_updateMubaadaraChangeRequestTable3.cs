using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateMubaadaraChangeRequestTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewCompletionPercentage",
                table: "Mub_MubaadaraChangeRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "NewStatusId",
                table: "Mub_MubaadaraChangeRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewCompletionPercentage",
                table: "Mub_MubaadaraChangeRequest");

            migrationBuilder.DropColumn(
                name: "NewStatusId",
                table: "Mub_MubaadaraChangeRequest");
        }
    }
}
