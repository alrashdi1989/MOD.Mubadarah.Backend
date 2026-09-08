using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addPeriodOfValidateOfferAndPeriodOfValidateBankInssuranceInTenderOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodOfValidateBankInssurance",
                table: "Pms_TenderOffers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodOfValidateOffer",
                table: "Pms_TenderOffers",
                type: "datetime2",
                nullable: true);
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
