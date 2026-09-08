using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateMubaadaraHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusIdPV",
                table: "Mub_MubaadaraHistory",
                newName: "StatusIdOV");

            migrationBuilder.RenameColumn(
                name: "EndDatePV",
                table: "Mub_MubaadaraHistory",
                newName: "EndDateOV");

            migrationBuilder.RenameColumn(
                name: "CompletionPercentagePV",
                table: "Mub_MubaadaraHistory",
                newName: "CompletionPercentageOV");

            migrationBuilder.AlterColumn<int>(
                name: "ColumnName",
                table: "Mub_MubaadaraHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusIdOV",
                table: "Mub_MubaadaraHistory",
                newName: "StatusIdPV");

            migrationBuilder.RenameColumn(
                name: "EndDateOV",
                table: "Mub_MubaadaraHistory",
                newName: "EndDatePV");

            migrationBuilder.RenameColumn(
                name: "CompletionPercentageOV",
                table: "Mub_MubaadaraHistory",
                newName: "CompletionPercentagePV");

            migrationBuilder.AlterColumn<string>(
                name: "ColumnName",
                table: "Mub_MubaadaraHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
