using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addBudgetInProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pms_UserTenantPermissions_UserId",
                table: "Pms_UserTenantPermissions");

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Pms_Projects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserTenantPermissions_UserId_TenantId",
                table: "Pms_UserTenantPermissions",
                columns: new[] { "UserId", "TenantId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pms_UserTenantPermissions_UserId_TenantId",
                table: "Pms_UserTenantPermissions");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Pms_Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserTenantPermissions_UserId",
                table: "Pms_UserTenantPermissions",
                column: "UserId");
        }
    }
}
