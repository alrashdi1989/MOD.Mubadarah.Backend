using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.Extensions.Configuration;
using MOD.Pms.Common;
using MOD.Pms.CommonDte;
using MOD.Pms.EntityFrameworkCore.Repositories;
using MOD.Pms.Enums;
using MOD.Pms.ExternalApiEntites.Jund;
using MOD.Pms.MubaadaraAttachments;
using MOD.Pms.MubaadaraHEComments;
using MOD.Pms.MubaadarasMembers;
using MOD.Pms.MubaadaraWorkflows;
using MOD.Pms.MubadaaraDetails;
using MOD.Pms.Permissions;
using MOD.Pms.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;
using static MOD.Pms.Permissions.PmsPermissions;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;


namespace MOD.Pms.Mubaadaras
{
    public class MubaadaraAppService : PmsAppService, IMubaadaraAppService
    {
        private readonly IMubaadaraRepository _mubaadaraRepository;
        private readonly IRepository<MubaadarasWorkflow, Guid> _mubaadaraWorkflowRepository;
        private readonly IRepository<MubaadaraDetails.MubaadaraDetail, Guid> _mubadaaraDetailRepository;
        private readonly IRepository<UserOrganizationUnitPermission, Guid> _userOrganizationUnitPermissionRepository;
        private readonly IRepository<MubaadaraAttachment, Guid> _mubaadaraAttachmentRepository;
        private readonly IOrganizationUnitRepository _organizationUnitRepository;
        private readonly IJundClient _jundClient;
        private readonly IDataFilter _dataFilter;
        private readonly IConfiguration _configuration;
        private readonly IRepository<MubaadaraMember, Guid> _mubaadaraMembersRepository;
        private readonly IRepository<MubaadaraHEComment, Guid> _mubaadaraHECommentRepository;



        public MubaadaraAppService(IMubaadaraRepository mubaadaraRepository,
        IOrganizationUnitRepository organizationUnitRepository,
        IRepository<MubaadaraDetails.MubaadaraDetail, Guid> mubadaaraDetailRepository,
        IRepository<MubaadarasWorkflow, Guid> mubaadaraWorkflowRepository,
        IRepository<UserOrganizationUnitPermission, Guid> userOrganizationUnitPermissionRepository,
        IRepository<MubaadaraAttachment, Guid> mubaadaraAttachmentRepository,
        IRepository<MubaadaraMember, Guid> mubaadaraMembersRepository,
        IRepository<MubaadaraHEComment, Guid> mubaadaraHECommentRepository,
        IJundClient jundClient,
        IDataFilter dataFilter,
        IConfiguration configuration
        )
        {
            _mubaadaraRepository = mubaadaraRepository;
            _mubadaaraDetailRepository = mubadaaraDetailRepository;
            _mubaadaraWorkflowRepository = mubaadaraWorkflowRepository;
            _userOrganizationUnitPermissionRepository = userOrganizationUnitPermissionRepository;
            _organizationUnitRepository = organizationUnitRepository;
            _mubaadaraAttachmentRepository = mubaadaraAttachmentRepository;
            _jundClient = jundClient;
            _dataFilter = dataFilter;
            _configuration = configuration;
            _mubaadaraMembersRepository = mubaadaraMembersRepository;
            _mubaadaraHECommentRepository = mubaadaraHECommentRepository;


        }

        //CREATE
        public async Task<MubaadaraDto> CreateAsync(object input)
        {
            var mubaadara = new Mubaadara();
            JsonConvert.PopulateObject(input.ToString(), mubaadara);
            mubaadara = await _mubaadaraRepository.InsertAsync(mubaadara);
            var mubaadaradto = ObjectMapper.Map<Mubaadara, MubaadaraDto>(mubaadara);
            return mubaadaradto;
        }

        //DELETE
        public async Task DeleteAsync(Guid id)
        {
            await _mubaadaraRepository.DeleteAsync(id);
        }

        //GET
        public async Task<MubaadaraDto> GetAsync(Guid id)
        {
            var mubaadara = await _mubaadaraRepository.GetAsync(id);
            var mubaadaradto = ObjectMapper.Map<Mubaadara, MubaadaraDto>(mubaadara);
            return mubaadaradto;
        }

        public async Task<LoadResult> GetAWithLoadOptionsync(Guid id, DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubaadaraRepository.GetQueryableAsync()).Where(c => c.Id == id);
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraDto>(config), loadOptions);
            return result;
        }

        //GET LIST
        public async Task<LoadResult> GetListAsync(DataSourceLoadOptions loadOptions)
        {
            using (_dataFilter.Disable<OrganizationUnitRole>())
            {
                var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
                var source = await _mubaadaraRepository.GetMubaadaraQueryableAsync();
                var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraDto>(config), loadOptions);
                return result;
            }
        }

        //UPDATE
        public async Task<MubaadaraDto> UpdateAsync(Guid id, object input)
        {
            var mubaadara = await _mubaadaraRepository.GetAsync(id);
            JsonConvert.PopulateObject(input.ToString(), mubaadara);
            mubaadara = await _mubaadaraRepository.UpdateAsync(mubaadara);
            var mubaadaradto = ObjectMapper.Map<Mubaadara, MubaadaraDto>(mubaadara);
            return mubaadaradto;
        }

        //GET LIST OF YEARS
        public async Task<List<int>> GetListOfYearsAsync()
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            List<DateTime> years = (await _mubaadaraRepository.GetQueryableAsync()).Select(c => c.StartDate.Value.Year).Distinct()
            .AsEnumerable().Select(x => new DateTime(x, 1, 1)).ToList();
            List<int> intYears = years.ToList().Select(x => x.Year).ToList();
            return intYears;
        }

        //GET Mubadaara Detail LIST
        public async Task<LoadResult> GetMubadaaraDetailListAsync(Guid id, DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubadaaraDetailRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == id);
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraDetailDto>(config), loadOptions);
            return result;
        }

        //Get Mubaadare ManagerId
        public async Task<bool> GetIsUserMubaadaraManagerAsync(Guid id)
        {
            var mubaadara = await _mubaadaraRepository.GetAsync(id);
            if (mubaadara.ManagerId == (Guid)CurrentUser.Id)
            {
                return true;
            }
            else
                return false;
        }

        public async Task UpdateMubaadaraStatusToApprovedAsync(Guid id)
        {
            var mubaadara = await _mubaadaraRepository.GetAsync(id);
            mubaadara.IsApproved = ApprovalStatus.Approved;
            await _mubaadaraRepository.UpdateAsync(mubaadara);
        }

        public async Task UpdateMubaadaraStatusToRejectedAsync(Guid id)
        {
            var mubaadara = await _mubaadaraRepository.GetAsync(id);
            mubaadara.IsApproved = ApprovalStatus.Rejected;
            await _mubaadaraRepository.UpdateAsync(mubaadara);
        }

        public async Task UpdateMubaadaraEndDateAsync(Guid id, DateTime newEndDate)
        {
            var mubaadara = await _mubaadaraRepository.GetAsync(id);
            mubaadara.EndDate = newEndDate;
            await _mubaadaraRepository.UpdateAsync(mubaadara);
        }

        public async Task UpdateMubaadaraCompletionPercentageAsync(Guid id, int newCompletionPercentage)
        {
            var mubaadara = await _mubaadaraRepository.GetAsync(id);
            mubaadara.CompletionPercentage = newCompletionPercentage;
            await _mubaadaraRepository.UpdateAsync(mubaadara);
        }

        public async Task<bool> GetIsNewMubaadara(Guid id)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubaadaraWorkflowRepository.GetQueryableAsync())
                .Where(c => c.MubaadaraId == id);
            if (source.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<DateTime> GetMubaadaraEndDate(Guid id)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var mubaadara = await _mubaadaraRepository.GetAsync(id);
            return (DateTime)mubaadara.EndDate;
        }
 
        public void ModOrganizationUnit()
        {
            _jundClient.GetModUnitsAsync().Wait();
        }

        public async Task<LoadResult> GetListByUserIdAsync(Guid UserId, DataSourceLoadOptions loadOptions)
        {
            AutoMapper.IConfigurationProvider config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;

            IQueryable<Mubaadara> mubaadaras = await _mubaadaraRepository.GetQueryableAsync();
            IQueryable<UserOrganizationUnitPermission> userOrganizationUnitPermissions = (await _userOrganizationUnitPermissionRepository.GetQueryableAsync()).Where(c => c.UserId == UserId);
            var source = from mubaadara in mubaadaras
                         join userOrganizationUnitPermission in userOrganizationUnitPermissions
                         on mubaadara.UnitId equals userOrganizationUnitPermission.OrganizationUnitId
                         select mubaadara;
            return await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraDto>(config), loadOptions);
        }

        public async Task<LoadResult> GetListByUserIdAndTargertYearAsync(Guid UserId,int targetYear, DataSourceLoadOptions loadOptions)
        {
            DateTime? startDate = new DateTime(targetYear, 1,1);
            DateTime? endDate = new DateTime(targetYear, 12,31);

            AutoMapper.IConfigurationProvider config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;

            IQueryable<Mubaadara> mubaadaras = await _mubaadaraRepository.GetQueryableAsync();
            IQueryable<UserOrganizationUnitPermission> userOrganizationUnitPermissions = (await _userOrganizationUnitPermissionRepository.GetQueryableAsync()).Where(c => c.UserId == UserId);
            var source = from mubaadara in mubaadaras
                         join userOrganizationUnitPermission in userOrganizationUnitPermissions
                         on mubaadara.UnitId equals userOrganizationUnitPermission.OrganizationUnitId
                         where mubaadara.StartDate >= startDate && mubaadara.EndDate <= endDate
                         select mubaadara;
            return await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraDto>(config), loadOptions);
        }
        public async Task<List<GroupDto>> GetMubaadarsCountByTypeQueryableAsync(int targetYear)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {

                var source = await _mubaadaraRepository.GetMubaadarsCountByTypeQueryableAsync(targetYear);
                if (source != null)
                {
                    return ObjectMapper.Map<List<GroupDte>, List<GroupDto>>(source.ToList());
                }
                else { return null; }
            }
        }
        public async Task<LoadResult> GetMubaadarsListByUnitIdAndTargetYearAsync(Guid id, int targetYear, DataSourceLoadOptions loadOptions)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                DateTime? startDate = new DateTime(targetYear, 1, 1);
                DateTime? endDate = new DateTime(targetYear, 12, 31);
                var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
                var source = (await _mubaadaraRepository.GetQueryableAsync()).Where(c => c.UnitId == id && c.StartDate >= startDate && c.EndDate <= endDate);
                var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraDto>(config), loadOptions);
                return result;
            }
        }

        public async Task<LoadResult> GetMubaadarsListByUnitIdAndTargetYearIncludingChildrenAsync(Guid id, int targetYear, DataSourceLoadOptions loadOptions)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                DateTime? startDate = new DateTime(targetYear, 1, 1);
                DateTime? endDate = new DateTime(targetYear, 12, 31);

                var parentUnit = await _organizationUnitRepository.GetAsync(id);
                // Org unit Codes are only unique among siblings under the same tenant (every
                // tenant's top-level units restart at "00001"), so the tenant must be matched
                // explicitly here rather than relying on the (disabled) multi-tenancy filter -
                // otherwise this would pull in same-coded units from other tenants too.
                var unitIds = (await _organizationUnitRepository.GetListAsync())
                    .Where(ou => ou.TenantId == parentUnit.TenantId && ou.Code.StartsWith(parentUnit.Code))
                    .Select(ou => ou.Id)
                    .ToList();

                var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
                var source = (await _mubaadaraRepository.GetQueryableAsync())
                    .Where(c => c.UnitId.HasValue && unitIds.Contains(c.UnitId.Value) && c.StartDate >= startDate && c.EndDate <= endDate);
                var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraDto>(config), loadOptions);
                return result;
            }
        }

        public async Task<LoadResult> GetMubaadarsListByUnitIdAsync(Guid id,  DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubaadaraRepository.GetQueryableAsync()).Where(c => c.UnitId == id );
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraDto>(config), loadOptions);
            return result;
        }

        public async Task<LoadResult> GetMubaadaraAttachmentAsync(Guid id, DataSourceLoadOptions loadOptions)
        {
            IQueryable<MubaadaraAttachment> mubaadaraAttachment = (await _mubaadaraAttachmentRepository.WithDetailsAsync(c => c.Documents)).Where(c => c.MubaadaraId == id);
            return await DataSourceLoader.LoadAsync(mubaadaraAttachment.ProjectTo<MubaadaraAttachment>(GetMapperConfigurationProvider()), loadOptions);
        }

        public async Task<List<OrganizationUnitsMubaadaraNumberDto>> GetOrganizationUnitsMubaadaraNumber(int targetYear)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var organizationUnitsMubaadaraNumberDto = await _mubaadaraRepository.GetOrganizationUnitsMubaadaraNumber(targetYear);
                return organizationUnitsMubaadaraNumberDto.ToList();
            }
        }

        public async Task<LoadResult> GetListByOrganizationUnitCodeAsync(Guid id, DataSourceLoadOptions loadOptions)
        {
            using (_dataFilter.Disable<OrganizationUnitRole>())
            {
                var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
                var source = (await _mubaadaraRepository.GetQueryableAsync()).Where(c => c.UnitId == id);
                var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraDto>(config), loadOptions);
                return result;
            }
        }

        public async Task<int> GetNumberOfEndStatusOrganizationUnitMubaadaraAsync(Guid id, int targetYear)
        {
            DateTime? startDate = new DateTime(targetYear, 1, 1);
            DateTime? endDate = new DateTime(targetYear, 12, 31);
            using (_dataFilter.Disable<OrganizationUnitRole>())
            {
                var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
                var source = (await _mubaadaraRepository.GetQueryableAsync()).Where(c => c.UnitId == id && c.StatusId == new Guid("4d9eaaba-8108-4ddd-a91f-3a10ae8f4c9a") && c.StartDate >= startDate && c.EndDate <= endDate).Count(); 
                return source;
            }
        }
        public async Task<List<GroupDto>> GetMubaadarsOrganizationUnitCountByTypeQueryableAsync(Guid id, int targetYear)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var source = await _mubaadaraRepository.GetMubaadarsOrganizationUnitCountByTypeQueryableAsync(id, targetYear);
                if (source != null)
                {
                    return ObjectMapper.Map<List<GroupDte>, List<GroupDto>>(source.ToList());
                }
                else { return null; }
            }
        }

        public async Task<List<GroupDto>> GetMubaadarsOrganizationUnitCountByStatusQueryableAsync(Guid id, int targetYear)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var source = await _mubaadaraRepository.GetMubaadarsOrganizationUnitCountByStatusQueryableAsync(id, targetYear);
                if (source != null)
                {
                    return ObjectMapper.Map<List<GroupDte>, List<GroupDto>>(source.ToList());
                }
                else { return null; }
            }
        }

        public async Task<decimal> GetMubaadarsOrganizationUnitAverageCompletionPercentageByUnitIdAsync(Guid organizationUnitId ,int targetYear)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var source = await _mubaadaraRepository.GetMubaadarsOrganizationUnitAverageCompletionPercentageByUnitIdAsync(organizationUnitId,targetYear);
                if (source > 0)
                {
                    return source;
                }
                else
                {
                    return 0;
                }

            }
        }

        public async Task<decimal> GetMubaadarsOrganizationUnitTotalAmountByUnitIdAsync(Guid organizationUnitId, int targetYear)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var source = await _mubaadaraRepository.GetMubaadarsOrganizationUnitTotalAmountByUnitIdAsync(organizationUnitId, targetYear);
                if (source > 0)
                {
                    return source;
                }
                else
                {
                    return 0;
                }

            }
        }



        public async Task<bool> GetIsOrganizationUnitHaveParentAsync(Guid id)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var source = await _organizationUnitRepository.GetAsync(id);
                if (
                    source.ParentId != new Guid("08A7CE37-6EF2-0755-EB7C-3A024B9A2F50")
                    &&
                    source.ParentId != new Guid("FD7DE1C5-1E4E-6649-9FB7-3A024204EA5C"))
                    {
                    return true;
                }
                else { return false; }
            }
        }

        public async Task<bool> IsMubaadaraPenddingAsync(Guid id)
        {
            var mubaadara = await _mubaadaraRepository.GetAsync(id);
            var mubaadaradto = ObjectMapper.Map<Mubaadara, MubaadaraDto>(mubaadara);
            var isMubaadaraApproved = mubaadaradto.IsApproved;
            if (isMubaadaraApproved == ApprovalStatus.Pendding) 
            {
                return true ;
            }
            else 
            {
                return false ;
            }
        }

        public async Task<LoadResult> GetMubaadaraMembersAsync(Guid id, DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubaadaraMembersRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == id);
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraMemberDto>(config), loadOptions);
            return result;
        }




        public async Task<LoadResult> GetMubaadaraHECommentsAsync(Guid id, DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubaadaraHECommentRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == id);
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraHECommentsDto>(config), loadOptions);
            return result;
        }

        public async Task<Guid> GetMubaadaraCommentUserIdAsync(Guid id)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubaadaraMembersRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == id);
            var mubaadaraGeneralManagerId = (source.Where(c => c.MubaadaraStructures == MubaadaraStructures.MubaadaraGeneralManager)).Select(c => c.UserId).FirstOrDefault();
            var mubaadaraHeadMangerId = (source.Where(c => c.MubaadaraStructures == MubaadaraStructures.MubaadaraHeadManager)).Select(c => c.UserId).FirstOrDefault();
            var mubaadaraMangerId = (source.Where(c => c.MubaadaraStructures == MubaadaraStructures.MubaadaraManager)).Select(c => c.UserId).FirstOrDefault();

            if (mubaadaraGeneralManagerId != Guid.Empty )
            {
                return mubaadaraGeneralManagerId;
            }
            else if (mubaadaraHeadMangerId != Guid.Empty)
            {
                return mubaadaraHeadMangerId;
            }
            else
            {
                return mubaadaraMangerId;
            }
        }


    }
}
