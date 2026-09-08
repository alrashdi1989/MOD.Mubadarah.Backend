using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MOD.Pms.MubaadaraHistories;
using MOD.Pms.Mubaadaras;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using static MOD.Pms.Permissions.PmsPermissions;

namespace MOD.Pms.MubaadaraUpdates
{
    public class MubaadaraUpdatesAppService : ApplicationService, IMubaadaraUpdateAppService
    {
        private readonly IRepository<MubaadaraUpdate, Guid> _mubaadaraUpdateRepository;

        public MubaadaraUpdatesAppService(IRepository<MubaadaraUpdate, Guid> mubaadaraUpdateRepository)
        {
            _mubaadaraUpdateRepository = mubaadaraUpdateRepository;
        }

        //CREATE
        public async Task<MubaadaraUpdateDto> CreateAsync(object input)
        {
            var mubaadaraUpdate = new MubaadaraUpdate();
            JsonConvert.PopulateObject(input.ToString(), mubaadaraUpdate);
            mubaadaraUpdate = await _mubaadaraUpdateRepository.InsertAsync(mubaadaraUpdate);
            var mubaadaraUpdatedto = ObjectMapper.Map<MubaadaraUpdate, MubaadaraUpdateDto>(mubaadaraUpdate);
            return mubaadaraUpdatedto;
        }

        public async Task<MubaadaraUpdateDto> GetAsync(Guid id)
        {
            var mubaadaraUpdate = await _mubaadaraUpdateRepository.GetAsync(id);
            var mubaadaraUpdatedto = ObjectMapper.Map<MubaadaraUpdate, MubaadaraUpdateDto>(mubaadaraUpdate);
            return mubaadaraUpdatedto;
        }

        public async Task<LoadResult> GetMubaadareUpdatesListAsync(Guid id, DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubaadaraUpdateRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == id).OrderByDescending(x => x.CreationTime); ;
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraUpdateDto>(config), loadOptions);
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _mubaadaraUpdateRepository.DeleteAsync(id);
        }

        public async Task<MubaadaraUpdateDto> UpdateAsync(Guid id, object input)
        {
            var mubaadara = await _mubaadaraUpdateRepository.GetAsync(id);
            JsonConvert.PopulateObject(input.ToString(), mubaadara);
            mubaadara = await _mubaadaraUpdateRepository.UpdateAsync(mubaadara);
            var mubaadarato = ObjectMapper.Map<MubaadaraUpdate, MubaadaraUpdateDto>(mubaadara);
            return mubaadarato;
        }
    }
}
