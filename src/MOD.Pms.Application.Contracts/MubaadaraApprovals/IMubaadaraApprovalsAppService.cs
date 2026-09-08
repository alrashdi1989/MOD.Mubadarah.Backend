using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using MOD.Pms.Common;

namespace MOD.Pms.MubaadaraApprovals
{
    public interface IMubaadaraApprovalsAppService : IApplicationService
    {
        Task<CommonOperationResultDto<MubaadaraApprovalInput>> CreateAsync(MubaadaraApprovalInput input);
        Task<CommonOperationResultDto<MubaadaraApprovalActionInput>>  UpdateMubaadaraRequestsReplyAsync(MubaadaraApprovalActionInput input);
        Task<CommonOperationResultDto<MubaadaraApprovalInput>> CreateMubaadaraWorkflow(Guid reffrenceId, Guid userId, Guid nweMubaadraApproval);
        Task<CommonOperationResultDto<MubaadaraApprovalInput>> UpdateMubaadaraWorkflow(Guid mubaadaraWorkflowId);
        Task DeleteAsync(Guid id);
    }
}
