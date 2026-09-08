using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class createMubaadaraHECommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mub_MubaadaraHEComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MubaadaraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserNameFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIdTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserNameTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActionDone = table.Column<bool>(type: "bit", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mub_MubaadaraHEComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mub_MubaadaraHEComment_Mub_Mubaadaras_MubaadaraId",
                        column: x => x.MubaadaraId,
                        principalTable: "Mub_Mubaadaras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mub_MubaadaraHEComment_MubaadaraId",
                table: "Mub_MubaadaraHEComment",
                column: "MubaadaraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mub_MubaadaraHEComment");
        }
    }
}
