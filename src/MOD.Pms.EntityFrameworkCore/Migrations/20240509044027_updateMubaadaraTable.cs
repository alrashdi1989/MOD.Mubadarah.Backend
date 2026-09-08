using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class updateMubaadaraTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // No-op: this originally altered "Mub_Mubaadaras.IsApproved", but that column
            // doesn't exist on this table until 20240703092806_solve2 adds it (as int NOT NULL
            // default 0, the same end state this migration tried to reach). On every real
            // database this migration is already recorded as applied, so it's a copy-paste
            // duplicate of 20240502065155_updateMubaadaraWorkflowTable.cs that only breaks a
            // from-scratch migration run.
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
