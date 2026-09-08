using DevExtreme.AspNet.Data.ResponseModel;
using MOD.Pms.Common;
using MOD.Pms.Documents;
using MOD.Pms.MubaadaraAttachments;
using MOD.Pms.MubaadarasMembers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MOD.Pms.MubaadaraHEComments
{
    public interface IMubaadaraHECommentAppService : IApplicationService
    {

        Task<CommonOperationResultDto<MubaadaraHECommentsDto>> CreateAsync(object input);
        Task<CommonOperationResultDto<MubaadaraHECommentsDto>> CreateMubaadaraWorkflow(MubaadaraHECommentsDto MubaadaraHECommentsDto);

     //   Task DeleteAsync(Guid id);
     //   Task<MubaadaraHECommentsDto> GetAsync(Guid id);
     //   Task<LoadResult> GetListAsync(DataSourceLoadOptions loadOptions);

        //  Task<MubaadaraHECommentsDto> UpdateAsync(Guid id, object input);
    }
}
