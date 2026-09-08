using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class fixRelationProjectWithUserProjectsFavorite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ActualAmount",
                table: "Pms_Projects",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pms_UserProjectsFavorites _UserId",
                table: "Pms_UserProjectsFavorites ",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pms_UserProjectsFavorites _AbpUsers_UserId",
                table: "Pms_UserProjectsFavorites ",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pms_UserProjectsFavorites _AbpUsers_UserId",
                table: "Pms_UserProjectsFavorites ");

            migrationBuilder.DropIndex(
                name: "IX_Pms_UserProjectsFavorites _UserId",
                table: "Pms_UserProjectsFavorites ");

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualAmount",
                table: "Pms_Projects",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);
        }
    }
}
