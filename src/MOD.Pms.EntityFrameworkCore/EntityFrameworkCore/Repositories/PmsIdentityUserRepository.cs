

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MOD.Pms.Repositories;
using MOD.Pms.UserReports;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Users;
using static MOD.Pms.Permissions.PmsPermissions;

namespace MOD.Pms.EntityFrameworkCore.Repositories
{
    public class PmsIdentityUserRepository : EfCoreIdentityUserRepository, IPmsIdentityUserRepository
    {
        public IDbContextProvider<PmsDbContext> DbContextProvider { get; }

        private bool isArabic;
        private readonly IDataFilter _dataFilter;
        private readonly IPermissionManager _permissionManager;
        private readonly IRepository<Volo.Abp.Identity.IdentityUserRole> _identityUserRoleRepository;
        private readonly IRepository<Volo.Abp.Identity.IdentityRole, Guid> _identityRoleRepository;




        public PmsIdentityUserRepository(IDbContextProvider<PmsDbContext> dbContextProvider, 
            IDataFilter dataFilter,
            IPermissionManager permissionManager, 
            IDbContextProvider<IIdentityDbContext> identitydbContextProvider) : base(identitydbContextProvider)
        {
            DbContextProvider = dbContextProvider;
            isArabic = CultureInfo.CurrentUICulture.Name != "en-US";
            _dataFilter = dataFilter;
            _permissionManager = permissionManager;


        }


        public async Task<IQueryable<IdentityUserDte>> GetIdentityUsersQueryableAsync()
        {
            var dbContext = await DbContextProvider.GetDbContextAsync();

            var result = from user in dbContext.Users.OrderBy(b => EF.Property<int>(b, "RankOrder"))
                         join tenant in dbContext.Tenants on user.TenantId equals tenant.Id
                         where user.UserName !="Admin"

                         select new IdentityUserDte()
                         {
                             Id = user.Id,
                             TenantId = user.TenantId,
                             UserName = user.UserName,
                             Email = user.Email,
                             PhoneNumber = user.PhoneNumber,
                             IsActive = user.IsActive,
                             ServiceNumber = EF.Property<string>(user, "ServiceNumber" ),
                             RankOrder = EF.Property<int>(user,"RankOrder"),
                             Rank = isArabic ? EF.Property<string>(user, "RankArabic")    : EF.Property<string>(user, "RankEnglish"),
                             Name = isArabic ? EF.Property<string>(user, "ArabicName" ) : EF.Property<string>(user, "EnglishName" ),
                             Position = isArabic ? EF.Property<string>(user, "PositionArabic" ) : EF.Property<string>(user, "PositionEnglish" ),
                             MainUnit = isArabic ? EF.Property<string>(user, "MainUnitArabic" ) : EF.Property<string>(user, "MainUnitEnglish" ),
                             MainUnitEnglish = EF.Property<string>(user, "MainUnitEnglish"),
                             Tenant = isArabic ? EF.Property<string>(tenant,"ArabicName" ) : EF.Property<string>(tenant,"EnglishName" ),
                             TenantOrder = EF.Property<int>(tenant,"Order"),

                         };


            return result;
        }

        public async Task UpdateUserTenantProcedure(Guid userId, Guid tenantId)
        { 
          var context = await GetDbContextAsync();
          var x=   await context.Database.ExecuteSqlRawAsync("EXEC dbo.UpdateUserTenantId @tenantId, @id", new List<object> { new SqlParameter("tenantId", tenantId), new SqlParameter("id", userId)});

        }


        public async Task DeleteUserRolesProcedure(Guid userId)
        {
            var context = await GetDbContextAsync();
            await context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.DeleteUserRoles @id",
                new List<object> { new SqlParameter("id", userId) });

        }

        //[Authorize()]
        //public async Task UpdateUserIsAcceptPolicy(Guid userId)
        //{
        //    var role = (await _identityRoleRepository.GetQueryableAsync()).Where(c => c.TenantId)
        //    var role = (await _identityUserRoleRepository.GetQueryableAsync()).Where(c )
        //    {
        //          await _permissionManager.se
        //    }
        //    base.GetRolesAsync(userId);
        //    var permissions = await _permissionManager.GetAllForUserAsync(userId);

        //    var context = await GetDbContextAsync();
        //        await context.Database.ExecuteSqlRawAsync("EXEC dbo.UpdateUserIsAcceptPolicy @id", new SqlParameter("id", userId));
            
        //}
                                                                                                                                  

    }
}


