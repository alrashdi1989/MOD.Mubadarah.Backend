using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using MOD.Pms.Enums;
using MOD.Pms.Localization;
using MOD.Pms.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Emailing;
using Volo.Abp.Emailing.Smtp;
using Volo.Abp.ObjectMapping;
using static MOD.Pms.Permissions.PmsPermissions;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace MOD.Pms.Lookups
{
    [Authorize]
    public class LookupsAppService : ApplicationService, ILookupAppService
    {
        private readonly ILookupRepository _lookupsRepository;
        private readonly IStringLocalizer<PmsResource> _l;


        public LookupsAppService(ILookupRepository lookupsRepository, IStringLocalizer<PmsResource> l)
        {
            _lookupsRepository = lookupsRepository;
            _l = l;


        }
        public async Task<LookupDto> GetAsync(Guid id)
        {
            var lookup = await _lookupsRepository.GetAsync(id);
            var lookupdto = ObjectMapper.Map<Lookup, LookupDto>(lookup);
            return lookupdto;
        }
        //GetList
        //public async Task<ListResultDto<LookupDto>> GetListAsync()
        //{
        //    var lookups = await _lookupsRepository.GetListAsync();
        //    return new ListResultDto<LookupDto>(lookups.Select(loc => ObjectMapper.Map<Lookup, LookupDto>(loc)).ToList());
        //}
        public async Task<LoadResult> GetListAsync(DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _lookupsRepository.GetQueryableAsync()).OrderBy(c=>c.Priority);
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<LookupDto>(config), loadOptions);
            return result;
        }
        [Authorize(LookupPermission.View)]
        public async Task<LoadResult> GetLookupChildListAsync(Guid id, DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId.Value == id).OrderBy(c => c.Priority); ;

            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<LookupDto>(config), loadOptions);
            return result;
        }

        public async Task<LoadResult> GetLookupParentListAsync(DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _lookupsRepository.GetQueryableAsync()).Where(c => !c.LookupId.HasValue ); 

            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<LookupDto>(config), loadOptions);
            return result;
        }
        [Authorize(LookupPermission.Insert)]
        public async Task<LookupDto> CreateAsync(object input)
        {
            var lookup = new Lookup();
            JsonConvert.PopulateObject(input.ToString(), lookup);
            if (lookup.LookupId == Guid.Empty)lookup.LookupId = null;

            lookup = await _lookupsRepository.InsertAsync(lookup);

            var lookupdto = ObjectMapper.Map<Lookup, LookupDto>(lookup);
            return lookupdto;
        }
        [Authorize(LookupPermission.Update)]
        public async Task<LookupDto> UpdateAsync(Guid id, object input)
        {
            var lookup = await _lookupsRepository.GetAsync(id);
            JsonConvert.PopulateObject(input.ToString(), lookup);
            lookup = await _lookupsRepository.UpdateAsync(lookup);
            var lookupdto = ObjectMapper.Map<Lookup, LookupDto>(lookup);
            return lookupdto;
        }
        [Authorize(LookupPermission.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _lookupsRepository.DeleteAsync(id);
        }

       
        public async Task<LoadResult> GetProjectTypeListAsync(DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = await _lookupsRepository.GetLookupHierarchyQueryableAsync(PmsConsts.ProjectTypeId);

            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<LookupDto>(config), loadOptions);
            return result;
        }

        public async Task<LoadResult> GetReportTypeListAsync(DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;

            var source = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.ReportTypeId);
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<LookupDto>(config), loadOptions);
            return result;
        }
 
        public async Task<List<LookupDto>> GetProjectAttachmentTypeListAsync()
        {
            //var source = await _lookupsRepository.GetLookupHierarchyQueryableAsync(PmsConsts.ProjectAttachmentTypeId);
            var source = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.ProjectAttachmentTypeId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(source.ToList());
        }

        public async Task<List<LookupDto>> GetScreensListAsync()
        {
            var source = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.ScreensId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(source.ToList());
        }

        public virtual async Task<List<LookupDto>> GetProjectTypesAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.ProjectTypeId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetDocumentTypeListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.DocumentTypeId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetAgentCategoryListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.AgentTypeId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetDrawingMapListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.DrawingMapTypeId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetAgentDgreeListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.AgentDegreeTypeId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetCampListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.CampId);
            var dddd = items.ToList();
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetProjectStatueListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.ProjectStatueId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetStandardsSectionListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.StandardsSectionsId);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetStandardListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.StandardTypeId);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetMemberTypeListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.MemberTypeId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetPhaseListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.ProjectPhaseId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetSubAgentTypeListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.SubAgentTypeId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetMubadaaraStatusListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.MubaadraStatusId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<LookupDto>> GetMubaadraTypeListAsync()
        {
            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == PmsConsts.MubaadraTypeId).OrderBy(c => c.Priority);
            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }

        public virtual async Task<List<EnumLookupDto>> GetEnumLookup(string enumName)
        {
            var result = new List<EnumLookupDto>();
            Type enumType = Type.GetType("MOD.Pms.Enums." + enumName + ", MOD.Pms.Domain.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

            if (enumType != null)
            {
                Array values = Enum.GetValues(enumType!);

                for (int i = 0; values != null && i < values.Length; i++)
                {
                    int id = (int)values.GetValue(i);
                    {
                        string text = $"{Enum.GetName(enumType, values.GetValue(i))}";
                        result.Add(new EnumLookupDto { IntId = id, EnglishName = text, ArabicName = _l[text] });
                    }
                }
                return result;
            }



            return new List<EnumLookupDto>().ToList();

        }

        public virtual async Task<List<LookupDto>> GetGovernortateStatesListAsync()
        {
             Guid guid = Guid.Parse("362D2651-8ADC-5FFE-91DF-3A141971D5D6");

            var items = (await _lookupsRepository.GetQueryableAsync()).Where(c => c.LookupId == guid).OrderBy(c => c.Priority);

            return ObjectMapper.Map<List<Lookup>, List<LookupDto>>(items.ToList());
        }




    }
}
