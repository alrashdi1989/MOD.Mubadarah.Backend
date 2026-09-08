using MOD.Pms.Enums;
using MOD.Pms.UserReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;


namespace MOD.Pms.Repositories
{
    public interface IPmsIdentityUserRepository
    {
        Task DeleteUserRolesProcedure(Guid userId);
        Task<IQueryable<IdentityUserDte>> GetIdentityUsersQueryableAsync();
        Task UpdateUserTenantProcedure(Guid userId, Guid tenantId);
        //Task UpdateUserIsAcceptPolicy(Guid userId);

    }
}
