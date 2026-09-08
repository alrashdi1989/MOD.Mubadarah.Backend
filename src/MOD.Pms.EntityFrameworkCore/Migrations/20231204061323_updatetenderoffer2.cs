using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updatetenderoffer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeriodOfValidateBankInssurance",
                table: "Pms_TenderOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodOfValidateOffer",
                table: "Pms_TenderOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodOfValidateBankInssurance",
                table: "Pms_TenderOffers");

            migrationBuilder.DropColumn(
                name: "PeriodOfValidateOffer",
                table: "Pms_TenderOffers");
        }
    }
}
