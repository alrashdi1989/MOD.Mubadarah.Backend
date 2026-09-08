using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class solve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ApprovedBy",
            //    table: "Mub_Mubaadaras");

            //migrationBuilder.DropColumn(
            //    name: "ApprovedDate",
            //    table: "Mub_Mubaadaras");

            //migrationBuilder.DropColumn(
            //    name: "IsApproved",
            //    table: "Mub_Mubaadaras");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<Guid>(
            //    name: "ApprovedBy",
            //    table: "Mub_Mubaadaras",
            //    type: "uniqueidentifier",
            //    nullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "ApprovedDate",
            //    table: "Mub_Mubaadaras",
            //    type: "datetime2",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "IsApproved",
            //    table: "Mub_Mubaadaras",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);
        }
    }
}
