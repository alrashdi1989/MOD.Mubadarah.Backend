using DevExtreme.AspNet.Data.ResponseModel;
using MOD.Pms.Common;
using MOD.Pms.MubaadaraHistories;
using MOD.Pms.MubaadaraUpdates;
using MOD.Pms.MubaadaraWorkflows;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace MOD.Pms.MubaadaraUpdates
{
    public interface IMubaadaraUpdateAppService : IApplicationService
    {

        Task<MubaadaraUpdateDto> CreateAsync(object input);
        Task<LoadResult> GetMubaadareUpdatesListAsync(Guid id, DataSourceLoadOptions loadOptions);

        Task DeleteAsync(Guid id);
        Task<MubaadaraUpdateDto> UpdateAsync(Guid id, object input);




    }
}
