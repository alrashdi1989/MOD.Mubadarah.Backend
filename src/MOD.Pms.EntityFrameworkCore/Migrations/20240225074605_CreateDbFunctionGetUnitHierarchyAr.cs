using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbFunctionGetUnitHierarchyAr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    CREATE FUNCTION [dbo].[GetUnitHierarchyAr]
                                    (
	                                    @unitId AS UNIQUEIDENTIFIER
                                    )
                                    RETURNS NVARCHAR(512) 
                                    AS
                                    BEGIN

                                      DECLARE @result AS NVARCHAR(512);
                                      WITH unit_hierarchy_cte AS (
                                        SELECT    
                                            org.Id,
                                            org.ArabicName,
                                            org.ParentId,
      	                                    CAST(org.ArabicName as nvarchar(max)) as path
                                        FROM dbo.AbpOrganizationUnits org WHERE org.Id = @unitId
                                        UNION ALL
         
                                        SELECT
                                            o.Id,
                                            o.ArabicName,
                                            o.ParentId,
      	                                    CONCAT(o.ArabicName, '/',unit_hierarchy_cte.path)
                                        FROM dbo.AbpOrganizationUnits o, unit_hierarchy_cte
                                        WHERE unit_hierarchy_cte.ParentId = o.Id 
                                      )   
                                      SELECT @result = unit_hierarchy_cte.path
                                      FROM unit_hierarchy_cte  where unit_hierarchy_cte.ParentId is null OPTION(MAXRECURSION 1000);
      
      
                                      RETURN @result;
                                    END;
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION [dbo].[GetUnitHierarchyAr]");

        }
    }
}
