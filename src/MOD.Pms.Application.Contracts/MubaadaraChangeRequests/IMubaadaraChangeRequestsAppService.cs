using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using MOD.Pms.Common;
using MOD.Pms.Enums;

namespace MOD.Pms.MubaadaraChangeRequests
{
    public interface IMubaadaraChangeRequestsAppService : IApplicationService
    {
        //   Task<ApprovalDto> GetAsync(Guid id);
        //   Task DeleteAsync(Guid id);
        Task<CommonOperationResultDto<MubaadaraChangeRequestsInput>> CreateAsync(MubaadaraChangeRequestsInput input);
        Task<MubaadaraChangeRequestsDto> GetAsync(Guid id);
        Task<LoadResult> GetListByMubaadaraIdAsync(Guid id, DataSourceLoadOptions loadOptions);
        Task<LoadResult> GetListOfMubaadaraChangeRerquestWithItIsApprovedAsync(Guid id, DataSourceLoadOptions loadOptions);
        Task<LoadResult> GetListOfAllMubaadaraChangeRequestsWithApprovedAsync(DataSourceLoadOptions loadOptions);
        Task<int> GetIsChangeRerquestHaveApproval(Guid id);
        Task<LoadResult> GetListOfApprovelsByChangeRerquestIdAsync(Guid id, DataSourceLoadOptions loadOptions);
        Task DeleteAsync(Guid id);





      //  Task<LoadResult> GetListAsync(Guid refrenceId, TabName tabName, DataSourceLoadOptions loadOptions);
      //  Task UpdateAsync(Guid id, int input);
      //  Task UpdateIsApprovedFieldsAsync(Guid id, String note);
      //  Task<bool> GetApprovalsAsync(Guid refrenceId);
      //   Task CreateWorkFlowForApprovals(object input);
      //  Task<bool> GetIsApprovalBlockedAsync(Guid refrenceId, TabName tabName);
      //  Task UpdateApprovalStatusToReject(Guid id, String note);

        ////  Task<bool> CheckApproval(Guid referenceId, TabName tabName);
        //  Task CheckApproval(Guid referenceId, TabName tabName);
    }
}
