using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOD.Pms.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserTenantProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE  [dbo].[UpdateUserTenantId] (
                                       @tenantId uniqueidentifier,
                                        @id uniqueidentifier)
                                        AS
                                        BEGIN
                                               SET NOCOUNT ON;
                                               UPDATE AbpUsers SET [TenantId] = @tenantId WHERE [Id] = @id
                                        END
                                        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP  PROCEDURE  [dbo].[UpdateUserTenantId]");


        }
    }
}
