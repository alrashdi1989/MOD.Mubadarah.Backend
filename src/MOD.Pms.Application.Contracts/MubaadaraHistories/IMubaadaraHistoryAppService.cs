using MOD.Pms.MubaadaraWorkflows;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace MOD.Pms.MubaadaraHistories
{
    public interface IMubaadaraHistoryAppService : IApplicationService
    {

        Task<MubaadaraHistoryDto> CreateAsync(object input);



    }
}
