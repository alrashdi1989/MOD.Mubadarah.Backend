using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class setDocumentReportId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_Lookups_ReportId",
                table: "Pms_Documents");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_Reports_ReportId",
                table: "Pms_Documents",
                column: "ReportId",
                principalTable: "Pms_Reports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_Reports_ReportId",
                table: "Pms_Documents");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_Lookups_ReportId",
                table: "Pms_Documents",
                column: "ReportId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");
        }
    }
}
