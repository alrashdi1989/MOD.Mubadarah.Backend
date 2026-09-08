using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Rfq_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "NebrasRFQ_Rfq");

            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "NebrasRFQ_Rfq");

            migrationBuilder.DropColumn(
                name: "RfqType",
                table: "NebrasRFQ_Rfq");

            migrationBuilder.DropColumn(
                name: "RfqValue",
                table: "NebrasRFQ_Rfq");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "NebrasRFQ_Rfq");

            migrationBuilder.RenameColumn(
                name: "RfqActivity",
                table: "NebrasRFQ_Rfq",
                newName: "Service");

            migrationBuilder.RenameColumn(
                name: "ProjectNumber",
                table: "NebrasRFQ_Rfq",
                newName: "ReplyMethodLookupCode");

            migrationBuilder.RenameColumn(
                name: "ProjectNotes",
                table: "NebrasRFQ_Rfq",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "OpenDate",
                table: "NebrasRFQ_Rfq",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "NebrasRFQ_Rfq",
                newName: "ReplayDate");

            migrationBuilder.RenameColumn(
                name: "CloseDate",
                table: "NebrasRFQ_Rfq",
                newName: "EndDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "NebrasRFQ_Rfq",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "NebrasRFQ_Rfq");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "NebrasRFQ_Rfq",
                newName: "OpenDate");

            migrationBuilder.RenameColumn(
                name: "Service",
                table: "NebrasRFQ_Rfq",
                newName: "RfqActivity");

            migrationBuilder.RenameColumn(
                name: "ReplyMethodLookupCode",
                table: "NebrasRFQ_Rfq",
                newName: "ProjectNumber");

            migrationBuilder.RenameColumn(
                name: "ReplayDate",
                table: "NebrasRFQ_Rfq",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "NebrasRFQ_Rfq",
                newName: "CloseDate");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "NebrasRFQ_Rfq",
                newName: "ProjectNotes");

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "NebrasRFQ_Rfq",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "NebrasRFQ_Rfq",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RfqType",
                table: "NebrasRFQ_Rfq",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RfqValue",
                table: "NebrasRFQ_Rfq",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "NebrasRFQ_Rfq",
                type: "int",
                nullable: true);
        }
    }
}
