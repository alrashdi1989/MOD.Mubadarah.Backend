using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class createFinancialSaving : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nebars_FinancialSaving",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NebrasTenderOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceAfterNegotitation = table.Column<double>(type: "float", nullable: false),
                    Percentage = table.Column<float>(type: "real", nullable: false),
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
                    table.PrimaryKey("PK_Nebars_FinancialSaving", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nebars_FinancialSaving_Nebars_NebrasTenderOffer_NebrasTenderOfferId",
                        column: x => x.NebrasTenderOfferId,
                        principalTable: "Nebars_NebrasTenderOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nebars_FinancialSaving_Nebars_NebrasTender_NebrasTenderId",
                        column: x => x.NebrasTenderId,
                        principalTable: "Nebars_NebrasTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_FinancialSaving_NebrasTenderId",
                table: "Nebars_FinancialSaving",
                column: "NebrasTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nebars_FinancialSaving_NebrasTenderOfferId",
                table: "Nebars_FinancialSaving",
                column: "NebrasTenderOfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nebars_FinancialSaving");
        }
    }
}
