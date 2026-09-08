using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class changeDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mub_MubaadaraDetails_Mub_Mubaadaras_MubaadaraId",
                table: "Mub_MubaadaraDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Mub_MubaadarasWorkflow_Mub_Mubaadaras_MubaadaraId",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.AddForeignKey(
                name: "FK_Mub_MubaadaraDetails_Mub_Mubaadaras_MubaadaraId",
                table: "Mub_MubaadaraDetails",
                column: "MubaadaraId",
                principalTable: "Mub_Mubaadaras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mub_MubaadarasWorkflow_Mub_Mubaadaras_MubaadaraId",
                table: "Mub_MubaadarasWorkflow",
                column: "MubaadaraId",
                principalTable: "Mub_Mubaadaras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mub_MubaadaraDetails_Mub_Mubaadaras_MubaadaraId",
                table: "Mub_MubaadaraDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Mub_MubaadarasWorkflow_Mub_Mubaadaras_MubaadaraId",
                table: "Mub_MubaadarasWorkflow");

            migrationBuilder.AddForeignKey(
                name: "FK_Mub_MubaadaraDetails_Mub_Mubaadaras_MubaadaraId",
                table: "Mub_MubaadaraDetails",
                column: "MubaadaraId",
                principalTable: "Mub_Mubaadaras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mub_MubaadarasWorkflow_Mub_Mubaadaras_MubaadaraId",
                table: "Mub_MubaadarasWorkflow",
                column: "MubaadaraId",
                principalTable: "Mub_Mubaadaras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
