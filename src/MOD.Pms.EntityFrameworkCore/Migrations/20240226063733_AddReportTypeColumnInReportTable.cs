using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class AddReportTypeColumnInReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isMubaadaraReport",
                table: "Pms_Reports");

            migrationBuilder.AddColumn<int>(
                name: "ReportType",
                table: "Pms_Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportType",
                table: "Pms_Reports");

            migrationBuilder.AddColumn<bool>(
                name: "isMubaadaraReport",
                table: "Pms_Reports",
                type: "bit",
                nullable: true);
        }
    }
}
