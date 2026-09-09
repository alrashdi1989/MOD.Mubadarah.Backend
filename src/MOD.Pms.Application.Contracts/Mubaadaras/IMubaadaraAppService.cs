using DevExtreme.AspNet.Data.ResponseModel;
using MOD.Pms.Common;
using MOD.Pms.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using static Volo.Abp.Identity.IdentityPermissions;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
namespace MOD.Pms.Mubaadaras
{
    public interface IMubaadaraAppService : IApplicationService
    {
        Task<MubaadaraDto> CreateAsync(object input);
        Task DeleteAsync(Guid id);
        Task<MubaadaraDto> GetAsync(Guid id);
        Task<LoadResult> GetListAsync(DataSourceLoadOptions loadOptions);
        Task<MubaadaraDto> UpdateAsync(Guid id, object input);
        Task<List<int>> GetListOfYearsAsync();
        Task<LoadResult> GetAWithLoadOptionsync(Guid id, DataSourceLoadOptions loadOptions);
        Task<bool> GetIsUserMubaadaraManagerAsync(Guid id);
        Task UpdateMubaadaraStatusToApprovedAsync(Guid id);
        Task UpdateMubaadaraStatusToRejectedAsync(Guid id);
        Task UpdateMubaadaraEndDateAsync(Guid id, DateTime newEndDate);
        Task UpdateMubaadaraCompletionPercentageAsync(Guid id, int newCompletionPercentage);
        Task<bool> GetIsNewMubaadara(Guid id);
        Task<DateTime> GetMubaadaraEndDate(Guid id);
        void ModOrganizationUnit();
        Task<LoadResult> GetListByUserIdAsync(Guid UserId, DataSourceLoadOptions loadOptions);
        Task<LoadResult> GetMubaadarsListByUnitIdAndTargetYearAsync(Guid id, int targetYear, DataSourceLoadOptions loadOptions);
        Task<LoadResult> GetMubaadarsListByUnitIdAndTargetYearIncludingChildrenAsync(Guid id, int targetYear, DataSourceLoadOptions loadOptions);
        Task<LoadResult> GetMubaadarsListByUnitIdAsync(Guid id, DataSourceLoadOptions loadOptions);
        Task<LoadResult> GetMubaadaraAttachmentAsync(Guid id, DataSourceLoadOptions loadOptions);
        Task<List<OrganizationUnitsMubaadaraNumberDto>> GetOrganizationUnitsMubaadaraNumber(int targetYear);
        Task<LoadResult> GetListByOrganizationUnitCodeAsync(Guid id, DataSourceLoadOptions loadOptions);
        Task<List<GroupDto>> GetMubaadarsOrganizationUnitCountByTypeQueryableAsync(Guid id, int targetYear);
        Task<List<GroupDto>> GetMubaadarsOrganizationUnitCountByStatusQueryableAsync(Guid id, int targetYear);
        Task<List<GroupDto>> GetMubaadarsCountByTypeQueryableAsync(int targetYear);
        Task<bool> GetIsOrganizationUnitHaveParentAsync(Guid id);
        Task<bool> IsMubaadaraPenddingAsync(Guid id);
        Task<decimal> GetMubaadarsOrganizationUnitAverageCompletionPercentageByUnitIdAsync(Guid id, int targetYear);
        Task<decimal> GetMubaadarsOrganizationUnitTotalAmountByUnitIdAsync(Guid id, int targetYear);
        Task<int> GetNumberOfEndStatusOrganizationUnitMubaadaraAsync(Guid id,int targetYear);
        Task<LoadResult> GetMubaadaraMembersAsync(Guid mubaadaraId, DataSourceLoadOptions loadOptions);
        Task<LoadResult> GetListByUserIdAndTargertYearAsync(Guid UserId, int targetYear, DataSourceLoadOptions loadOptions); 

    }
}
