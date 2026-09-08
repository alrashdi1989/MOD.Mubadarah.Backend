
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using MOD.Pms.Common;
using MOD.Pms.Enums;
using MOD.Pms.Localization;
using MOD.Pms.MubaadarasMembers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using static MOD.Pms.Permissions.PmsPermissions;

namespace MOD.Pms.MubaadaraMembers
{
    [Authorize]
    public class MubaadaraMembersAppService : ApplicationService, IMubaadaraMemberAppService
    {
        private readonly IRepository<MubaadaraMember, Guid> _mubaadaraMembersRepository;
        private readonly IDataFilter _dataFilter;

        private readonly IStringLocalizer<PmsResource> _l;

        public MubaadaraMembersAppService(IRepository<MubaadaraMember, Guid> mubaadaraMembersRepository, IDataFilter dataFilter, IStringLocalizer<PmsResource> l)
        {
            _mubaadaraMembersRepository = mubaadaraMembersRepository;
            _dataFilter = dataFilter;
            _l = l;
        }

        public async Task<CommonOperationResultDto<MubaadaraMemberDto>> CreateAsync(object input)
        {
            var mubaadaraMemberCreationDto = new MubaadaraMemberCreationDto();
            JsonConvert.PopulateObject(input.ToString(), mubaadaraMemberCreationDto);
            var members = new List<MubaadaraMember>();
            foreach (var item in mubaadaraMemberCreationDto.UserId)
            {
                var Exist = await _mubaadaraMembersRepository.AnyAsync(c => c.MubaadaraId == mubaadaraMemberCreationDto.MubaadaraId && c.UserId == item);
                if (!Exist)
                {
                    var mubaadaraMember = new MubaadaraMember
                    {
                        MubaadaraId = mubaadaraMemberCreationDto.MubaadaraId,
                        UserId = item,
                        MubaadaraMemberPermission = mubaadaraMemberCreationDto.MubaadaraMemberPermission,
                        MubaadaraStructures = mubaadaraMemberCreationDto.MubaadaraStructures,
                    };
                    members.Add(mubaadaraMember);
                }
            }
            await _mubaadaraMembersRepository.InsertManyAsync(members);
            return new CommonOperationResultDto<MubaadaraMemberDto>(_l["AddedMubaadaraMember"], true);
        }

        public async Task<MubaadaraMemberDto> UpdateAsync(Guid id, object input)
        {
            var mubaadaraMemberdto = new MubaadaraMemberDto();
            JsonConvert.PopulateObject(input.ToString(), mubaadaraMemberdto);
            var mubaadaraMember = await _mubaadaraMembersRepository.GetAsync(id);
            JsonConvert.PopulateObject(input.ToString(), mubaadaraMember);
            mubaadaraMember = await _mubaadaraMembersRepository.UpdateAsync(mubaadaraMember);
            return mubaadaraMemberdto;
        }

        //DELETE
        public async Task DeleteAsync(Guid id)
        {
            await _mubaadaraMembersRepository.DeleteAsync(x => x.Id == id);
        }


        //GET MEMBERS BY ID
        public async Task<MubaadaraMemberDto > GetAsync(Guid id)
        {
            var mubaadaraMember = await _mubaadaraMembersRepository.GetAsync(x => x.Id == id);
            var mubaadaraMemberdto = ObjectMapper.Map<MubaadaraMember, MubaadaraMemberDto>(mubaadaraMember);
            return mubaadaraMemberdto;
        }

        //GET LIST OF ALL MEMBERS
    //    [Authorize(MembersTabPermission.View)]
        public async Task<LoadResult> GetListAsync(DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            //var source = await _memberRepository.WithDetailsAsync(c=>c.IdentityUser);
            var source = await _mubaadaraMembersRepository.GetQueryableAsync();
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraMemberDto>(config), loadOptions);
            return result;
        }

        public async Task<LoadResult> GetMubaadaraMembersAsync(Guid mubaadaraId, DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubaadaraMembersRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == mubaadaraId);
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraMemberDto>(config), loadOptions);
            return result;
        }

        public async Task<bool> GetIsHaveApprovalRequestPermission(Guid mubaadaraId)
        {

            var member = await _mubaadaraMembersRepository.FindAsync(x => x.MubaadaraId == mubaadaraId && x.UserId == (Guid)CurrentUser.Id);
            if (member != null)
            {
                if (member.MubaadaraMemberPermission == MubaadaraMemberPermission.ApprovalRequest)
                    return true;
                else return false;
            }
            else
            {
                return false;

            }
        }
    }
}
