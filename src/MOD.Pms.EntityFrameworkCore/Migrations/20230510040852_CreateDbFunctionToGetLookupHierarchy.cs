using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbFunctionToGetLookupHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[GetLookupHierarchyAsTable] (
                                       @lookupId   UNIQUEIDENTIFIER)
                                       RETURNS TABLE
                                    AS
                                    RETURN WITH
                                              lookup_hierarchy_cte
                                              AS
                                                 (SELECT PL.*
                                                  FROM Pms_Lookups PL
                                                  WHERE PL.Id = @lookupId
                                                  UNION ALL
                                                  SELECT o.*
                                                  FROM Pms_Lookups o
                                                       JOIN lookup_hierarchy_cte
                                                          ON lookup_hierarchy_cte.Id = o.LookupId)
                                           SELECT *
                                           FROM lookup_hierarchy_cte;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION [dbo].[GetLookupHierarchyAsTable]");

        }
    }
}
