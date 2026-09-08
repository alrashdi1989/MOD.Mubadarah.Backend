using DevExtreme.AspNet.Data.ResponseModel;
using MOD.Pms.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace MOD.Pms.IdentityUsers
{
    public interface IPmsIdentityUserAppService : IIdentityUserAppService
    {
        Task<CommonOperationResultDto<Volo.Abp.Identity.IdentityUserDto>> CreatePmsUserAsync(PmsIdentityUserCreateDto input);
        Task<EmployeeDto> GetJundEmployee(string serviceMilitaryId);
         Task<LoadResult> GetCollectionByLoadOptionsAsync(bool   includeCurrentUser, DataSourceLoadOptions loadOptions);
        Task<bool> GetPermissionAsync();
        Task<List<IdentityUserDto>> GetAllMubaadaraUsersAsync();
       // Task UpdateUserIsAcceptPolicy(Guid userId);
    }
}
