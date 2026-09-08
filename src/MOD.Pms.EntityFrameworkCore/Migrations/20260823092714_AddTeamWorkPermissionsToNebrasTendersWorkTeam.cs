using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamWorkPermissionsToNebrasTendersWorkTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamWorkEditPermission",
                table: "Nebars_NebrasTendersWorkTeam",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamWorkMemberPermission",
                table: "Nebars_NebrasTendersWorkTeam",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamWorkEditPermission",
                table: "Nebars_NebrasTendersWorkTeam");

            migrationBuilder.DropColumn(
                name: "TeamWorkMemberPermission",
                table: "Nebars_NebrasTendersWorkTeam");
        }
    }
}
