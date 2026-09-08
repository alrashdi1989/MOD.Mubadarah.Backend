using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUserRolesProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE  [dbo].[DeleteUserRoles] (
                                        @id uniqueidentifier)
                                        AS
                                        BEGIN
                                               SET NOCOUNT ON;
                                               delete from AbpUserRoles where [UserId]=@id
                                        END
                                        ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP  PROCEDURE  [dbo].[DeleteUserRoles]");


        }
    }
}
