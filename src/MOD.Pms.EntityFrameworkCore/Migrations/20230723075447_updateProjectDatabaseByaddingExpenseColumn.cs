using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateProjectDatabaseByaddingExpenseColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Pms_Documents_Pms_Lookups_ReportId",
            //    table: "Pms_Documents");

            migrationBuilder.RenameColumn(
                name: "ActualAmount",
                table: "Pms_Projects",
                newName: "Expense");

            //migrationBuilder.RenameColumn(
            //    name: "ReportId",
            //    table: "Pms_Documents",
            //    newName: "UserReportId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Pms_Documents_ReportId",
            //    table: "Pms_Documents",
            //    newName: "IX_Pms_Documents_UserReportId");

            //migrationBuilder.AddColumn<decimal>(
            //    name: "Budget",
            //    table: "Pms_Projects",
            //    type: "decimal(18,2)",
            //    nullable: false,
            //    defaultValue: 0m);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Pms_Documents_Pms_UserReports_UserReportId",
            //    table: "Pms_Documents",
            //    column: "UserReportId",
            //    principalTable: "Pms_UserReports",
            //    principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Pms_Documents_Pms_UserReports_UserReportId",
            //    table: "Pms_Documents");

            //migrationBuilder.DropColumn(
            //    name: "Budget",
            //    table: "Pms_Projects");

            migrationBuilder.RenameColumn(
                name: "Expense",
                table: "Pms_Projects",
                newName: "ActualAmount");

            //migrationBuilder.RenameColumn(
            //    name: "UserReportId",
            //    table: "Pms_Documents",
            //    newName: "ReportId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Pms_Documents_UserReportId",
            //    table: "Pms_Documents",
            //    newName: "IX_Pms_Documents_ReportId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Pms_Documents_Pms_Lookups_ReportId",
            //    table: "Pms_Documents",
            //    column: "ReportId",
            //    principalTable: "Pms_Lookups",
            //    principalColumn: "Id");
        }
    }
}
