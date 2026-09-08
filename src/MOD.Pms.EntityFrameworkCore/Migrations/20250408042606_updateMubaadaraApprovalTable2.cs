using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateMubaadaraApprovalTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Mub_MubaadaraApproval",
                newName: "SenderNotes");

            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Mub_MubaadaraApproval",
                newName: "IsActionDone");

            migrationBuilder.RenameColumn(
                name: "ApprovedBy",
                table: "Mub_MubaadaraApproval",
                newName: "ReceiverNotes");

            migrationBuilder.RenameColumn(
                name: "ApprovalDate",
                table: "Mub_MubaadaraApproval",
                newName: "ActionlDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderNotes",
                table: "Mub_MubaadaraApproval",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "ReceiverNotes",
                table: "Mub_MubaadaraApproval",
                newName: "ApprovedBy");

            migrationBuilder.RenameColumn(
                name: "IsActionDone",
                table: "Mub_MubaadaraApproval",
                newName: "IsApproved");

            migrationBuilder.RenameColumn(
                name: "ActionlDate",
                table: "Mub_MubaadaraApproval",
                newName: "ApprovalDate");
        }
    }
}
