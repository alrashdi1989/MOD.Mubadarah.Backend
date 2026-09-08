using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateUserReportsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_Lookups_ReportId",
                table: "Pms_Documents");

            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "Pms_Documents",
                newName: "UserReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Pms_Documents_ReportId",
                table: "Pms_Documents",
                newName: "IX_Pms_Documents_UserReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_UserReports_UserReportId",
                table: "Pms_Documents",
                column: "UserReportId",
                principalTable: "Pms_UserReports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_Documents_Pms_UserReports_UserReportId",
                table: "Pms_Documents");

            migrationBuilder.RenameColumn(
                name: "UserReportId",
                table: "Pms_Documents",
                newName: "ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Pms_Documents_UserReportId",
                table: "Pms_Documents",
                newName: "IX_Pms_Documents_ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_Documents_Pms_Lookups_ReportId",
                table: "Pms_Documents",
                column: "ReportId",
                principalTable: "Pms_Lookups",
                principalColumn: "Id");
        }
    }
}
