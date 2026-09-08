using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addVoteCodeInCahngeRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "budget",
                table: "Pms_ChangeRequests",
                newName: "VoteCodeType");

            migrationBuilder.AddColumn<string>(
                name: "VoteCode",
                table: "Pms_ChangeRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoteCode",
                table: "Pms_ChangeRequests");

            migrationBuilder.RenameColumn(
                name: "VoteCodeType",
                table: "Pms_ChangeRequests",
                newName: "budget");
        }
    }
}
