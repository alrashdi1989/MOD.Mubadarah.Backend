using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MOD.Pms.Enums;
using MOD.Pms.Lookups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MOD.Pms.Lookups
{
    public interface ILookupAppService:IApplicationService
    {
        Task<LookupDto> CreateAsync(object input);
        Task<LookupDto> UpdateAsync(Guid id, object input);
        Task<LookupDto> GetAsync(Guid id);
        Task<LoadResult> GetListAsync(DataSourceLoadOptions loadOptions);
        Task DeleteAsync(Guid id);
        Task<LoadResult> GetLookupChildListAsync(Guid id, DataSourceLoadOptions loadOptions);     
        Task<List<LookupDto>> GetAgentCategoryListAsync();
        Task<List<LookupDto>> GetAgentDgreeListAsync();
        Task<LoadResult> GetProjectTypeListAsync(DataSourceLoadOptions loadOptions);
        Task<List<LookupDto>> GetStandardListAsync();
        Task<List<LookupDto>> GetProjectTypesAsync();
        Task<List<LookupDto>> GetDrawingMapListAsync();
        Task<List<LookupDto>> GetMemberTypeListAsync();
        Task<List<LookupDto>> GetPhaseListAsync();
        Task<LoadResult> GetReportTypeListAsync(DataSourceLoadOptions loadOptions);
        Task<List<LookupDto>> GetSubAgentTypeListAsync();
        Task<LoadResult> GetLookupParentListAsync(DataSourceLoadOptions loadOptions);
        Task<List<LookupDto>> GetScreensListAsync();
        Task<List<LookupDto>> GetStandardsSectionListAsync();
        Task<List<LookupDto>> GetMubadaaraStatusListAsync();
        Task<List<LookupDto>> GetMubaadraTypeListAsync();
        Task<List<EnumLookupDto>> GetEnumLookup(string enumName);
        Task<List<LookupDto>> GetGovernortateStatesListAsync();



    }
}
