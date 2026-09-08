using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class addIsActionDoneToMubaadaraWorkflowTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.RenameColumn(
                name: "ApprovalId",
                table: "Mub_MubaadarasWorkflow",
                newName: "MubaadaraApprovalId");

            migrationBuilder.RenameColumn(
                name: "ApprovalDate",
                table: "Mub_MubaadarasWorkflow",
                newName: "ActionDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsActionDone",
                table: "Mub_MubaadarasWorkflow",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mub_MubaadarasWorkflow_MubaadaraApprovalId",
                table: "Mub_MubaadarasWorkflow",
                column: "MubaadaraApprovalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mub_MubaadarasWorkflow_Mub_MubaadaraApproval_MubaadaraApprovalId",
                table: "Mub_MubaadarasWorkflow",
                column: "MubaadaraApprovalId",
                principalTable: "Mub_MubaadaraApproval",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mub_MubaadarasWorkflow_Mub_MubaadaraApproval_MubaadaraApprovalId",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropIndex(
                name: "IX_Mub_MubaadarasWorkflow_MubaadaraApprovalId",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.DropColumn(
                name: "IsActionDone",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.RenameColumn(
                name: "MubaadaraApprovalId",
                table: "Mub_MubaadarasWorkflow",
                newName: "ApprovalId");

            migrationBuilder.RenameColumn(
                name: "ActionDate",
                table: "Mub_MubaadarasWorkflow",
                newName: "ApprovalDate");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Mub_MubaadarasWorkflow",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
