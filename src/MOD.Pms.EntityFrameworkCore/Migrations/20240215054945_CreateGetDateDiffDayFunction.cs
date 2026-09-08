using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class CreateGetDateDiffDayFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[GetDateDiffDay]
                                    (
	    
	                                     @startdate datetime , @enddate datetime
                                    )
                                    RETURNS int 
                                    AS
                                    BEGIN

                                      DECLARE @result AS int;
     
                                     select @result=  DATEDIFF(day, @startdate, @enddate)
                                     RETURN @result;
                                      END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION [dbo].[GetDateDiffDay]");

        }
    }
}
