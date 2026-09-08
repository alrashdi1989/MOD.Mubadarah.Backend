using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateNebrasTenderSelectedSupplierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NebrasId",
                table: "Nebars_NebrasTenderSelectedSupplier");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "Nebars_NebrasTenderSelectedSupplier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "Nebars_NebrasTenderSelectedSupplier",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_NebrasTenderSelectedSupplier_SupplierId",
                table: "Nebars_NebrasTenderSelectedSupplier",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nebars_NebrasTenderSelectedSupplier_Pms_Agents_SupplierId",
                table: "Nebars_NebrasTenderSelectedSupplier",
                column: "SupplierId",
                principalTable: "Pms_Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nebars_NebrasTenderSelectedSupplier_Pms_Agents_SupplierId",
                table: "Nebars_NebrasTenderSelectedSupplier");

            migrationBuilder.DropIndex(
                name: "IX_Nebars_NebrasTenderSelectedSupplier_SupplierId",
                table: "Nebars_NebrasTenderSelectedSupplier");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierId",
                table: "Nebars_NebrasTenderSelectedSupplier",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "NebrasId",
                table: "Nebars_NebrasTenderSelectedSupplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "Nebars_NebrasTenderSelectedSupplier",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
