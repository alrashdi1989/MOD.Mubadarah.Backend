using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Data;
using AutoMapper.QueryableExtensions;
using MOD.Pms.Mubaadaras;
using MOD.Pms.Common;
using MOD.Pms.Enums;
using Volo.Abp.Identity;
using Microsoft.Extensions.Localization;
using MOD.Pms.Localization;
using MOD.Pms.Repositories;
using Volo.Abp.TextTemplating;
using Volo.Abp.Emailing.Smtp;
using MOD.Pms.MubaadaraChangeRequests;
using MOD.Pms.MubaadaraApprovals;

namespace MOD.Pms.MubaadaraWorkflows
{
    public class MubaadaraWorkflowAppService : PmsAppService, IMubaadaraWorkflowAppService
    {
        private readonly IRepository<MubaadarasWorkflow, Guid> _mubaadaraWorkflowRepository;
        private readonly IRepository<MubaadaraChangeRequest, Guid> _mubaadaraChangeRequestRepository;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IRepository<Mubaadara, Guid> _mubaadaraRepository;
        private readonly ILookupRepository _lookupsRepository;
        private readonly IStringLocalizer<PmsResource> _l;
        private readonly IDataFilter _dataFilter;
        private readonly ITemplateRenderer _templateRenderer;
        private readonly SmtpEmailSender _emailSender;

        public MubaadaraWorkflowAppService(
            IRepository<MubaadarasWorkflow,Guid> mubaadaraWorkflowRepository,
            IIdentityUserRepository identityUserRepository,
            IRepository<MubaadaraChangeRequest, Guid> mubaadaraChangeRequestRepository,
            IRepository<Mubaadara, Guid> mubaadaraRepository,
            ILookupRepository lookupsRepository,
            IStringLocalizer<PmsResource> l,
            IDataFilter dataFilter,
            ITemplateRenderer templateRenderer,
            SmtpEmailSender emailSender)
        {
            _mubaadaraWorkflowRepository = mubaadaraWorkflowRepository;
            _identityUserRepository = identityUserRepository;
            _mubaadaraRepository = mubaadaraRepository;
            _lookupsRepository = lookupsRepository;
            _l = l;
            _dataFilter = dataFilter;
            _templateRenderer = templateRenderer;
            _emailSender = emailSender;
            _mubaadaraChangeRequestRepository = mubaadaraChangeRequestRepository;
        }

        public async Task<CommonOperationResultDto<MubaadarasWorkflowDto>> CreateAsync(MubaadaraApprovalInput mubaadaraApprovalInput)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var UserFromData = await _identityUserRepository.GetAsync((Guid)CurrentUser.Id);//current user id
                var UserToData = await _identityUserRepository.GetAsync((Guid)mubaadaraApprovalInput.UserId);
                var mubaadaraChangeRequests = await _mubaadaraChangeRequestRepository.GetAsync((Guid)mubaadaraApprovalInput.ReffrenceId);

                var MubaadarasWorkflow = new MubaadarasWorkflow()
                {
                    MubaadaraId = (Guid)mubaadaraApprovalInput.ReffrenceId,
                    UserIdFrom = (Guid)CurrentUser.Id,
                    UserNameFrom = $"{UserFromData.GetProperty<string>("PositionArabic", "PositionArabic")} - {UserFromData.GetProperty<string>("RankArabic", "RankArabic")} - {UserFromData.GetProperty<string>("ArabicName", "ArabicName")}",
                    UserIdTo = mubaadaraApprovalInput.UserId,
                    UserNameTo = $"{UserToData.GetProperty<string>("PositionArabic", "PositionArabic")} - {UserToData.GetProperty<string>("RankArabic", "RankArabic")} - {UserToData.GetProperty<string>("ArabicName", "ArabicName")}",
                    Action = mubaadaraChangeRequests.MubaadaraRequests.ToString(),
                    Classification = Enums.Classification.ToAction,
                };
                 await _mubaadaraWorkflowRepository.InsertAsync(MubaadarasWorkflow);
                return new CommonOperationResultDto<MubaadarasWorkflowDto>(_l["Message"], true);
            }
        }




        public async Task<LoadResult> GetListAsync(DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = await _mubaadaraWorkflowRepository.GetQueryableAsync();
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadarasWorkflowDto>(config), loadOptions);
            return result;
        }

        //GET LIST
        public async Task DeleteAsync(Guid id)
        {
            await _mubaadaraWorkflowRepository.DeleteAsync(id);
        }

        public async Task<MubaadarasWorkflowDto> GetAsync(Guid id)
        {
            var mubaadarasWorkflow = await _mubaadaraWorkflowRepository.GetAsync(id);
            var mubaadarasWorkflowDto = ObjectMapper.Map<MubaadarasWorkflow, MubaadarasWorkflowDto>(mubaadarasWorkflow);
            return mubaadarasWorkflowDto;
        }

        public async Task<MubaadarasWorkflowDto> UpdateAsync(Guid id, object input)
        {
            var mubaadarasWorkflow = await _mubaadaraWorkflowRepository.GetAsync(id);
            JsonConvert.PopulateObject(input.ToString(), mubaadarasWorkflow);
            mubaadarasWorkflow = await _mubaadaraWorkflowRepository.UpdateAsync(mubaadarasWorkflow);
            var mubaadaraWorkflowDto = ObjectMapper.Map<MubaadarasWorkflow, MubaadarasWorkflowDto>(mubaadarasWorkflow);
            return mubaadaraWorkflowDto;
        }

        public async Task<LoadResult> GetIncomingList(Guid id, DataSourceLoadOptions loadOptions)
        {
            loadOptions.Sort = new[] {
             new SortingInfo { Desc = true, Selector = "creationTime" }
             };

            using (_dataFilter.Disable<IMultiTenant>())
            {
                var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
                var source = (await _mubaadaraWorkflowRepository.WithDetailsAsync(c => c.Mubaadara)).Where(c => c.UserIdTo == CurrentUser.Id.Value && c.IsActionDone != true).OrderByDescending(c => c.CreationTime);
                var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadarasWorkflowDto>(config), loadOptions);
                return result;
            }
        }

        public async Task<LoadResult> GetArchiveList(Guid id, DataSourceLoadOptions loadOptions)
        {
            loadOptions.Sort = new[] {
             new SortingInfo { Desc = true, Selector = "creationTime" }
             };

            using (_dataFilter.Disable<IMultiTenant>())
            {
                var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
                var source = (await _mubaadaraWorkflowRepository.WithDetailsAsync(c => c.Mubaadara)).Where(c => c.UserIdTo == CurrentUser.Id.Value && c.IsActionDone == true).OrderByDescending(c => c.CreationTime);
                var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadarasWorkflowDto>(config), loadOptions);
                return result;
            }
        }

        public async Task<LoadResult> GetOutcomingList(Guid id, DataSourceLoadOptions loadOptions)
        {
            loadOptions.Sort = new[] {
             new SortingInfo { Desc = true, Selector = "creationTime" }
             };

            using (_dataFilter.Disable<IMultiTenant>())
            {
                var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
                var source = (await _mubaadaraWorkflowRepository.WithDetailsAsync(c => c.Mubaadara)).Where(c => c.UserIdFrom == CurrentUser.Id.Value).OrderByDescending(c => c.CreationTime);
                var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadarasWorkflowDto>(config), loadOptions);
                return result;
            }
        }

        // Get List of workflow 
        public async Task<LoadResult> GetListByMubaadaraId(Guid id, DataSourceLoadOptions loadOptions)
        {
            loadOptions.Sort = new[] {
             new SortingInfo { Desc = true, Selector = "creationTime" }
             };

            using (_dataFilter.Disable<IMultiTenant>())
            {
                var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
                var source = (await _mubaadaraWorkflowRepository.WithDetailsAsync(c => c.Mubaadara)).Where(c => c.MubaadaraId == id && c.UserIdFrom == c.Mubaadara.ManagerId).OrderByDescending(c => c.CreationTime);
                var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadarasWorkflowDto>(config), loadOptions);
                return result;
            }
        }

      
        public async Task CreateMubaadaraChangeRequestAsync(MubaadaraChangeRequestsInput input)
        {
            //var mubaadara = await _mubaadaraRepository.GetAsync((Guid)input.MubaadaraId);
            //var mubaadaraChangeRequests = new MubaadaraChangeRequest();
            //mubaadaraChangeRequests.MubaadaraId = (Guid)input.MubaadaraId;

            //if (input.MubaadaraRequests == MubaadaraRequests.ChangeCompletionPercentage)
            //{
            //    mubaadaraChangeRequests.PreviousValue = System.Convert.ToString((int)mubaadara.CompletionPercentage) + "% ";
            //    mubaadaraChangeRequests.NewValue = System.Convert.ToString(input.NewCompletionPercentage) + "% ";
            //    mubaadaraChangeRequests.MubaadaraRequests = MubaadaraRequests.ChangeCompletionPercentage;
            //}

            //else if (input.MubaadaraRequests == MubaadaraRequests.ChangeMubaadaraStatus)
            //{
            //    mubaadaraChangeRequests.PreviousValue = (await _lookupsRepository.GetAsync(mubaadara.StatusId)).ArabicName;
            //    mubaadaraChangeRequests.NewValue = (await _lookupsRepository.GetAsync(input.NewStatusId)).ArabicName;
            //    mubaadaraChangeRequests.MubaadaraRequests = MubaadaraRequests.ChangeMubaadaraStatus;
            //}

            //else if (input.MubaadaraRequests == MubaadaraRequests.ExtensionApproved)
            //{
            //    mubaadaraChangeRequests.PreviousValue = System.Convert.ToString(mubaadara.EndDate);
            //    mubaadaraChangeRequests.NewEndDate = input.NewEndDate;
            //    mubaadaraChangeRequests.MubaadaraRequests = MubaadaraRequests.ChangeCompletionPercentage;
            //}
            //await _mubaadaraChangeRequestRepository.InsertAsync(mubaadaraChangeRequests);
        }





    }
}

