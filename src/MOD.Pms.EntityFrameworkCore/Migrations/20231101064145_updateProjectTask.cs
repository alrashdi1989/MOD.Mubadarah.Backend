using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateProjectTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Progress",
                table: "Pms_ProjectTasks",
                newName: "PlannedProgress");

            migrationBuilder.AddColumn<int>(
                name: "ActualProgress",
                table: "Pms_ProjectTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualProgress",
                table: "Pms_ProjectTasks");

            migrationBuilder.RenameColumn(
                name: "PlannedProgress",
                table: "Pms_ProjectTasks",
                newName: "Progress");
        }
    }
}
