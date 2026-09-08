using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MOD.Pms.MubaadaraHistories
{
    public class MubaadaraHistoryAppService: PmsAppService, IMubaadaraHistoryAppService
    {
        private readonly IRepository<MubaadaraHistory, Guid> _mubaadaraHistoryRepository;

        public MubaadaraHistoryAppService(IRepository<MubaadaraHistory, Guid> mubaadaraHistoryRepository)
        {
            _mubaadaraHistoryRepository = mubaadaraHistoryRepository;
        }

        //CREATE
        public async Task<MubaadaraHistoryDto> CreateAsync(object input)
        {
            var mubaadaraHistory = new MubaadaraHistory();
            JsonConvert.PopulateObject(input.ToString(), mubaadaraHistory);
            mubaadaraHistory = await _mubaadaraHistoryRepository.InsertAsync(mubaadaraHistory);
            var mubaadaraHistorydto = ObjectMapper.Map<MubaadaraHistory, MubaadaraHistoryDto>(mubaadaraHistory);
            return mubaadaraHistorydto;
        }

    }
}
