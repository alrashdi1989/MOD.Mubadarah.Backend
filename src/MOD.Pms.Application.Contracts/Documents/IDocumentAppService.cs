 using MOD.Pms.Enums;
using System;
using System.Collections.Generic;
 using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MOD.Pms.Documents
{
    public interface IDocumentAppService: IApplicationService
    {

        Task<DocumentDto> GetAsync(Guid refrenceId);
        Task<BlobDto> GetBlobByRefIdAsync(Guid refrenceId, ReffrenceDocumentType reffrenceType);
        Task UpdateDocumentAsync(Guid documentId, FileDto file);
    }
}
