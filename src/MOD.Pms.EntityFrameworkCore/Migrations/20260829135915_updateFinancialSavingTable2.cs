using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateFinancialSavingTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "Nebars_FinancialSaving");

            migrationBuilder.RenameColumn(
                name: "PriceAfterNegotitation",
                table: "Nebars_FinancialSaving",
                newName: "DiscountPercentage");

            migrationBuilder.AddColumn<double>(
                name: "DiscountAmount",
                table: "Nebars_FinancialSaving",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Nebars_FinancialSaving",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Nebars_FinancialSaving");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Nebars_FinancialSaving");

            migrationBuilder.RenameColumn(
                name: "DiscountPercentage",
                table: "Nebars_FinancialSaving",
                newName: "PriceAfterNegotitation");

            migrationBuilder.AddColumn<float>(
                name: "Percentage",
                table: "Nebars_FinancialSaving",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
