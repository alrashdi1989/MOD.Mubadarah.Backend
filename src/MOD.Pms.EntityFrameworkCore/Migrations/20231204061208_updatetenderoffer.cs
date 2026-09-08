using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updatetenderoffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodOfValidateBankInssurance",
                table: "Pms_TenderOffers");

            migrationBuilder.DropColumn(
                name: "PeriodOfValidateOffer",
                table: "Pms_TenderOffers");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Pms_TenderOffers",
                newName: "TechnicalNote");

            migrationBuilder.AlterColumn<int>(
                name: "IsApplicalbleContacrtCondition",
                table: "Pms_TenderOffers",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<decimal>(
                name: "CalculationMistakes",
                table: "Pms_TenderOffers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractNote",
                table: "Pms_TenderOffers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialNote",
                table: "Pms_TenderOffers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLabor",
                table: "Pms_TenderOffers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechnicalResult",
                table: "Pms_TenderOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculationMistakes",
                table: "Pms_TenderOffers");

            migrationBuilder.DropColumn(
                name: "ContractNote",
                table: "Pms_TenderOffers");

            migrationBuilder.DropColumn(
                name: "FinancialNote",
                table: "Pms_TenderOffers");

            migrationBuilder.DropColumn(
                name: "NumberOfLabor",
                table: "Pms_TenderOffers");

            migrationBuilder.DropColumn(
                name: "TechnicalResult",
                table: "Pms_TenderOffers");

            migrationBuilder.RenameColumn(
                name: "TechnicalNote",
                table: "Pms_TenderOffers",
                newName: "Note");

            migrationBuilder.AlterColumn<bool>(
                name: "IsApplicalbleContacrtCondition",
                table: "Pms_TenderOffers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
