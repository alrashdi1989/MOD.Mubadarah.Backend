using DevExtreme.AspNet.Data.ResponseModel;
using MOD.Pms.Enums;
using MOD.Pms.Mubaadaras;
using MOD.Pms.MubadaaraDetails;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MOD.Pms.MubadaaraDetails
{
    public interface IMubadaaraDetailAppService : IApplicationService
    {
        Task<MubaadaraDetailDto> CreateAsync(object input);
        Task DeleteAsync(Guid id);
        Task<MubaadaraDetailDto> GetAsync(Guid id);
        Task<MubaadaraDetailDto> UpdateAsync(Guid id, object input);
        //Task<LoadResult> GetMubaadaraDetailsAsync(Guid id, DataSourceLoadOptions loadOptions);
        Task<MubaadaraDetailDto> UpdateMubaadaraDetailsStatusAsync(Guid id, MubaadaraChallengeStatus MubaadaraChallengeStatus);
    }
}
