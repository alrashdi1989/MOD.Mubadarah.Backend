using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class AddRfqSuppliers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqSelectedSupplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqSelectedSupplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqSelectedSupplier_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqSelectedSupplier_Pms_Agents_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NebrasRFQ_RfqSuppliersPurchasingDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_NebrasRFQ_RfqSuppliersPurchasingDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqSuppliersPurchasingDocument_NebrasRFQ_Rfq_RfqId",
                        column: x => x.RfqId,
                        principalTable: "NebrasRFQ_Rfq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NebrasRFQ_RfqSuppliersPurchasingDocument_Pms_Agents_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Pms_Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqSelectedSupplier_RfqId",
                table: "NebrasRFQ_RfqSelectedSupplier",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqSelectedSupplier_SupplierId",
                table: "NebrasRFQ_RfqSelectedSupplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqSuppliersPurchasingDocument_RfqId",
                table: "NebrasRFQ_RfqSuppliersPurchasingDocument",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_NebrasRFQ_RfqSuppliersPurchasingDocument_SupplierId",
                table: "NebrasRFQ_RfqSuppliersPurchasingDocument",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqSelectedSupplier");

            migrationBuilder.DropTable(
                name: "NebrasRFQ_RfqSuppliersPurchasingDocument");
        }
    }
}
