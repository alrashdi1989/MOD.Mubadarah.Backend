using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateLookupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlertPeriod",
                table: "Pms_Lookups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarningPeriod",
                table: "Pms_Lookups",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlertPeriod",
                table: "Pms_Lookups");

            migrationBuilder.DropColumn(
                name: "WarningPeriod",
                table: "Pms_Lookups");
        }
    }
}
