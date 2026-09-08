using DevExtreme.AspNet.Data.ResponseModel;
using MOD.Pms.Documents;
using MOD.Pms.MubaadaraAttachments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MOD.Pms.MubaadaraAttachments
{
    public interface IMubaadaraAttachmentAppService : IApplicationService
    {

        Task<MubaadaraAttachmentDto> CreateAsync(object input);
        Task<MubaadaraAttachmentDto> GetAsync(Guid id);
        Task<MubaadaraAttachmentDto> UpdateAsync(Guid id, object input);
        Task DeleteAsync(Guid id);
    }
}
