using DevExtreme.AspNet.Data.ResponseModel;
using MOD.Pms.Common;
using MOD.Pms.Enums;
using MOD.Pms.MubaadaraApprovals;
using MOD.Pms.MubaadaraChangeRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MOD.Pms.MubaadaraWorkflows
{
    public interface IMubaadaraWorkflowAppService : IApplicationService
    {
        Task<CommonOperationResultDto<MubaadarasWorkflowDto>> CreateAsync(MubaadaraApprovalInput mubaadaraApprovalInput);
        Task<MubaadarasWorkflowDto> UpdateAsync(Guid id, object input);
        Task DeleteAsync(Guid id);
        Task<LoadResult> GetListAsync(DataSourceLoadOptions loadOptions);
        Task<LoadResult> GetIncomingList(Guid id, DataSourceLoadOptions loadOptions);
        Task<LoadResult> GetArchiveList(Guid id,DataSourceLoadOptions loadOptions);
        Task<LoadResult> GetOutcomingList(Guid id, DataSourceLoadOptions loadOptions);
        Task<LoadResult> GetListByMubaadaraId(Guid id, DataSourceLoadOptions loadOptions);
    }
}
