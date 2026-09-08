using MOD.Pms.MubaadaraDetails;
using MOD.Pms.Mubaadaras;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using MOD.Pms.MubaadaraWorkflows;
using Volo.Abp.Identity;
using MOD.Pms.EntityFrameworkCore.Repositories;
using MOD.Pms.Enums;
using Microsoft.Extensions.Localization;
using MOD.Pms.Localization;
using MOD.Pms.Repositories;

namespace MOD.Pms.MubadaaraDetails
{
    public class MubadaaraDetailAppService : PmsAppService, IMubadaaraDetailAppService
    {
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IRepository<Mubaadara, Guid> _mubaadaraRepository;
        private readonly IMubaadaraWorkflowAppService _mubaadaraWorkflowRepository;
        private readonly IMubaadaraDetailRepository _mubadaaraDetailsRepository;
        private readonly IStringLocalizer<PmsResource> _l;

        public MubadaaraDetailAppService(
            IMubaadaraDetailRepository mubadaaraDetailRepository,
            IIdentityUserRepository identityUserRepository,
            IRepository<Mubaadara, Guid> mubaadaraRepository,
            IStringLocalizer<PmsResource> l,
            IMubaadaraWorkflowAppService mubaadaraWorkflowRepository
            )
        {
            _mubadaaraDetailsRepository = mubadaaraDetailRepository;
            _identityUserRepository = identityUserRepository;
            _mubaadaraRepository = mubaadaraRepository;
            _l = l;
            _mubaadaraWorkflowRepository = mubaadaraWorkflowRepository;
        }

        //CREATE
        public async Task<MubaadaraDetailDto> CreateAsync(object input)
        {
            var mubaadarachallenge = new MubaadaraDetails.MubaadaraDetail();
            JsonConvert.PopulateObject(input.ToString(), mubaadarachallenge);
            mubaadarachallenge = await _mubadaaraDetailsRepository.InsertAsync(mubaadarachallenge);
            var mubaadarachallengedto = ObjectMapper.Map<MubaadaraDetail, MubaadaraDetailDto>(mubaadarachallenge);
            return mubaadarachallengedto;
        }


        //DELETE
        public async Task DeleteAsync(Guid id)
        {
            await _mubadaaraDetailsRepository.DeleteAsync(id);
        }

        //GET
        public async Task<MubaadaraDetailDto> GetAsync(Guid id)
        {
            var mubaadarachallenge = await _mubadaaraDetailsRepository.GetAsync(id);
            var mubaadarachallengedto = ObjectMapper.Map<MubaadaraDetail, MubaadaraDetailDto>(mubaadarachallenge);
            return mubaadarachallengedto;
        }

        //GET LIST
        //public async Task<List<MubaadaraDetailsDte>> GetListAsync( Guid mubaadaraId, DataSourceLoadOptions loadOptions)
        //{
        //    var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
        //    IQueryable<MubaadaraDetailDte> mubaadaraDetails = (await _mubadaaraDetailRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == mubaadaraId);
        //    IQueryable<MubaadarasWorkflow> mubaadarasWorkflows = (await _mubaadaraWorkflowRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == mubaadaraId);
        //    var query = from mubadaaraDetail in mubaadaraDetails
        //                join mubaadarasWorkflow in mubaadarasWorkflows on mubadaaraDetail.Id equals mubaadarasWorkflow.MubaadaraDetailId
        //                select new MubaadaraDetailsDte { Challenge = mubadaaraDetail.Challenge, Note= mubadaaraDetail.Note, Solution=mubadaaraDetail.Solution, ApproveStatus= mubadaaraDetail.ApproveStatus, UserIdTo = mubaadarasWorkflow.UserIdTo};


        //    return query.ToList();
        //}

        //UPDATE
        public async Task<MubaadaraDetailDto> UpdateAsync(Guid id, object input)
        {
            var mubaadarachallenge = await _mubadaaraDetailsRepository.GetAsync(id);
            JsonConvert.PopulateObject(input.ToString(), mubaadarachallenge);
            mubaadarachallenge = await _mubadaaraDetailsRepository.UpdateAsync(mubaadarachallenge);
            var mubaadarachallengedto = ObjectMapper.Map<MubaadaraDetail, MubaadaraDetailDto>(mubaadarachallenge);
            return mubaadarachallengedto;
        }

        //public async Task<LoadResult> GetMubaadaraDetailsAsync(Guid id, DataSourceLoadOptions loadOptions)
        //{
        //    AutoMapper.IConfigurationProvider config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
        //    IQueryable<MubaadaraDetailsDte> source = (await _mubadaaraDetailsRepository.GetMubaadaraDetailsQueryableAsync()).Where(c => c.MubaadaraId == id);
        //    LoadResult result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraDetailsDte>(GetMapperConfigurationProvider()), loadOptions);
        //    return result;
        //}

        public async Task<MubaadaraDetailDto> UpdateMubaadaraDetailsStatusAsync(Guid id, MubaadaraChallengeStatus MubaadaraChallengeStatus)
        {
            var mubaadarachallenge = await _mubadaaraDetailsRepository.GetAsync(id);
            mubaadarachallenge.ApproveStatus = MubaadaraChallengeStatus;
            mubaadarachallenge = await _mubadaaraDetailsRepository.UpdateAsync(mubaadarachallenge);
            var mubaadarachallengedto = ObjectMapper.Map<MubaadaraDetail, MubaadaraDetailDto>(mubaadarachallenge);
            return mubaadarachallengedto;
        }
    }
}