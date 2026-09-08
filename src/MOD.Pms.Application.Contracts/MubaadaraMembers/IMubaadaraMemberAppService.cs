using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using MOD.Pms.Common;
using MOD.Pms.MubaadarasMembers;

namespace MOD.Pms.MubaadaraMembers
{
    public interface IMubaadaraMemberAppService: IApplicationService
    {
        Task<CommonOperationResultDto<MubaadaraMemberDto>> CreateAsync(object input);
        //Task<MubaadaraMembersDto> UpdateAsync(Guid id, object input);
        Task DeleteAsync(Guid id);
        Task<MubaadaraMemberDto> GetAsync(Guid id);
        Task<LoadResult> GetListAsync(DataSourceLoadOptions loadOptions);
        Task<LoadResult> GetMubaadaraMembersAsync(Guid projectId, DataSourceLoadOptions loadOptions);
        //Task<LoadResult> GetAssociateProjectsAsync(DataSourceLoadOptions loadOptions);
        //Task<LoadResult> GetMembersProjectAsync(Guid PositionId, DataSourceLoadOptions loadOptions);
        Task<bool> GetIsHaveApprovalRequestPermission(Guid mubaadaraId);
        Task<MubaadaraMemberDto> UpdateAsync(Guid id, object input);



    }

}
