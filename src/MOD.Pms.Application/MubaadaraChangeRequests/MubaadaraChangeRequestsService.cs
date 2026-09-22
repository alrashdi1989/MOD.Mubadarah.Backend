using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.Extensions.Localization;

using MOD.Pms.Common;
using MOD.Pms.Localization;
using MOD.Pms.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Microsoft.AspNetCore.Authorization;
using static MOD.Pms.Permissions.PmsPermissions;
using MOD.Pms.Repositories;
using System.Collections.Generic;
using System.Globalization;
using MOD.Pms.Mubaadaras;
using MOD.Pms.MubaadaraWorkflows;
using MOD.Pms.MubaadaraApprovals;
using Volo.Abp.Identity;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace MOD.Pms.MubaadaraChangeRequests
{
    [Authorize]
    public class MubaadaraChangeRequestsService : PmsAppService, IMubaadaraChangeRequestsAppService
    {
        private readonly IRepository<MubaadaraChangeRequest, Guid> _mubaadaraChangeRequestRepository;
        private readonly IRepository<MubaadaraApproval, Guid> _mubaadaraApprovalRepository;
        private readonly IMubaadaraRepository _mubaadaraRepository;
        private readonly ILookupRepository _lookupsRepository;
        private readonly IOrganizationUnitRepository _organizationUnitRepository;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IDataFilter _dataFilter;
        private readonly IStringLocalizer<PmsResource> _l;
        private readonly IMubaadaraApprovalsAppService _mubaadaraApprovalsAppService;

        public MubaadaraChangeRequestsService(
            IRepository<MubaadaraChangeRequest, Guid> mubaadaraChangeRequestRepository,
            IRepository<MubaadaraApproval, Guid> mubaadaraApprovalRepository,
            ILookupRepository lookupsRepository,
            IMubaadaraRepository mubaadaraRepository,
            IOrganizationUnitRepository organizationUnitRepository,
            IIdentityUserRepository identityUserRepository,
            IDataFilter dataFilter,
            IMubaadaraApprovalsAppService mubaadaraApprovalsAppService,
            IStringLocalizer<PmsResource> l
            )
        {
            _mubaadaraChangeRequestRepository = mubaadaraChangeRequestRepository;
            _mubaadaraRepository = mubaadaraRepository;
            _lookupsRepository = lookupsRepository;
            _organizationUnitRepository = organizationUnitRepository;
            _identityUserRepository = identityUserRepository;
            _dataFilter = dataFilter;
            _mubaadaraApprovalRepository = mubaadaraApprovalRepository;
            _mubaadaraApprovalsAppService = mubaadaraApprovalsAppService;
            _l = l;
        }

        public async Task <CommonOperationResultDto<MubaadaraChangeRequestsInput>> CreateAsync(MubaadaraChangeRequestsInput input) {

            var mubaadara = await _mubaadaraRepository.GetAsync((Guid) input.MubaadaraId);
            var mubaadaraChangeRequests = new MubaadaraChangeRequest();
            mubaadaraChangeRequests.MubaadaraId = (Guid)input.MubaadaraId;
            mubaadaraChangeRequests.ApprovalStatus = ApprovalStatus.Pendding;
            mubaadaraChangeRequests.IsApproved = false;
            mubaadaraChangeRequests.IsHaveApprovealRow = false;


            if (input.MubaadaraRequests == MubaadaraRequests.ChangeCompletionPercentage)
            {
                mubaadaraChangeRequests.PreviousValue = System.Convert.ToString((int)mubaadara.CompletionPercentage) + "% ";
                mubaadaraChangeRequests.NewValue = System.Convert.ToString(input.CompletionPercentage) + "% ";
                mubaadaraChangeRequests.MubaadaraRequests = MubaadaraRequests.ChangeCompletionPercentage;
                mubaadaraChangeRequests.NewCompletionPercentage = Convert.ToInt32(input.CompletionPercentage);

            }

            else if (input.MubaadaraRequests == MubaadaraRequests.ChangeMubaadaraStatus)
            {
                mubaadaraChangeRequests.PreviousValue = (await _lookupsRepository.GetAsync(mubaadara.StatusId)).ArabicName;
                mubaadaraChangeRequests.NewValue = (await _lookupsRepository.GetAsync((Guid)input.StatusId)).ArabicName;
                mubaadaraChangeRequests.MubaadaraRequests = MubaadaraRequests.ChangeMubaadaraStatus;
                mubaadaraChangeRequests.NewStatusId = input.StatusId;
            }

            else if (input.MubaadaraRequests == MubaadaraRequests.ExtensionApproved)
            {
                mubaadaraChangeRequests.PreviousValue = System.Convert.ToString(mubaadara.EndDate);
                mubaadaraChangeRequests.NewValue = System.Convert.ToString(input.EndDate);
                mubaadaraChangeRequests.NewEndDate = input.EndDate;
                mubaadaraChangeRequests.MubaadaraRequests = MubaadaraRequests.ExtensionApproved;
            }
            await _mubaadaraChangeRequestRepository.InsertAsync(mubaadaraChangeRequests, autoSave: true);

            if (input.UserIdTo.HasValue && input.UserIdTo != Guid.Empty)
            {
                await _mubaadaraApprovalsAppService.CreateAsync(new MubaadaraApprovalInput
                {
                    ReffrenceId = mubaadaraChangeRequests.Id,
                    UserId = input.UserIdTo.Value,
                });
            }

            return new CommonOperationResultDto<MubaadaraChangeRequestsInput>(_l["Message"], true);

        }

        public async Task<LoadResult> GetListOfApprovelsByChangeRerquestIdAsync(Guid id, DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubaadaraApprovalRepository.GetQueryableAsync()).Where(c => c.ReffrenceId == id);
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraApprovalDto>(config), loadOptions);
            return result;
        }
            //public async Task CreateAsync(object input)
            //{

            //    var approvalList = new List<Approval>();

            //    var approvalInput = new ApprovalInput();
            //    JsonConvert.PopulateObject(input.ToString(), approvalInput);
            //    int i = 0;
            //     var maxPir = await _approvalRepository.CountAsync(c => c.ReffrenceId == approvalInput.reffrenceId && c.TabName == approvalInput.tabName);
            //    i = maxPir + 1;
            //    foreach (var item in approvalInput.userId)
            //    {

            //            var approval = new Approval()
            //            {
            //                UserId = item,
            //                TabName = approvalInput.tabName,
            //                ReffrenceId = approvalInput.reffrenceId,
            //                Priority = i,
            //                ApprovalStatus = ApprovalStatus.Pendding


            //            };
            //        if (i == 1)
            //        {

            //                var tabName = _l[approval.TabName.ToString()];
            //                using (_dataFilter.Disable<IMultiTenant>())
            //                {

            //                    var emailBody = await _templateRenderer.RenderAsync(
            //                            StandardEmailTemplates.Message, new
            //                            {

            //                                text = L["TitleApproval"],
            //                                message = string.Format(L["MessageApproval"], tabName)

            //                            });
            //                    var user = await _identityUserRepository.GetAsync(approval.UserId);
            //                    await _emailSender.SendAsync(
            //                                                     user.Email,
            //                                                     "Approval<اعتماد>",
            //                                                     emailBody
            //                                                 );
            //                }

            //        }
            //            approvalList.Add(approval);

            //        i++;
            //        }
            //        await _approvalRepository.InsertManyAsync(approvalList);
            //    }


            public async Task DeleteAsync(Guid id)
        {
            await _mubaadaraChangeRequestRepository.DeleteAsync(id);
        }

        public async Task<MubaadaraChangeRequestsDto> GetAsync(Guid id)
        {
            var mubaadaraChangeRequest = await _mubaadaraChangeRequestRepository.GetAsync(id);
            var mubaadaraChangeRequestdto = ObjectMapper.Map<MubaadaraChangeRequest, MubaadaraChangeRequestsDto>(mubaadaraChangeRequest);
            return mubaadaraChangeRequestdto;
        }

        public async Task<LoadResult> GetListByMubaadaraIdAsync(Guid id,DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubaadaraChangeRequestRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == id );
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraChangeRequestsDto>(config), loadOptions);
            return result;
        }

        public async Task<LoadResult> GetListOfMubaadaraChangeRerquestWithItIsApprovedAsync(Guid id, DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider; ;
            IQueryable<MubaadaraChangeRequest> MubaadaraChangeRequestsDtos = (await _mubaadaraChangeRequestRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == id);
            IQueryable<MubaadaraApproval> MubaadaraApprovalDtos = (await _mubaadaraApprovalRepository.GetQueryableAsync()).Where(c => c.MubaadaraRequestsReply == MubaadaraRequestsReply.Approved);

            var query = from ChangeRequest in MubaadaraChangeRequestsDtos
                        join Approval in MubaadaraApprovalDtos on ChangeRequest.Id equals Approval.ReffrenceId
                        select new MubaadaraChangeRequestsApprovalDto
                        {
                            MubaadaraChangeRequestId = ChangeRequest.Id,
                            MubaadaraRequests = ChangeRequest.MubaadaraRequests,
                            UserIdTo = Approval.UserId,
                            UserIdFrom = (Guid)Approval.CreatorId,
                            PreviousValue = ChangeRequest.PreviousValue,
                            NewValue = ChangeRequest.NewValue,
                            RequestDate = Approval.CreationTime,
                            ApprovalDate = Approval.ActionlDate,
                        };

            loadOptions.Sort = new[] {
             new SortingInfo { Desc = true, Selector = "approvalDate" }
             };

            var result = await DataSourceLoader.LoadAsync(query.ProjectTo<MubaadaraChangeRequestsApprovalDto>(config), loadOptions);
           

            return result;
        }

        // Same shape as GetListOfMubaadaraChangeRerquestWithItIsApprovedAsync but across every
        // Mubaadara (not just one), plus each row's directorate name - used by the standalone
        // "سجلات التغيير" (Change Logs) page. Resolves the name the same way
        // MubaadaraRepository.GetOrganizationUnitsMubaadaraNumberByDateRange already does
        // (ArabicName extra property, falling back to DisplayName) and, critically, the same
        // IMultiTenant filter disabled around the Mubaadara/OrganizationUnit join - without
        // that, OrganizationUnit rows outside the current request's tenant scope silently
        // don't match and the column comes back empty, even though the join/lookup logic
        // itself is otherwise correct.
        public async Task<LoadResult> GetListOfAllMubaadaraChangeRequestsWithApprovedAsync(DataSourceLoadOptions loadOptions)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var changeRequests = (await _mubaadaraChangeRequestRepository.GetQueryableAsync());
                var approvals = (await _mubaadaraApprovalRepository.GetQueryableAsync()).Where(c => c.MubaadaraRequestsReply == MubaadaraRequestsReply.Approved);

                var joined = (
                    from ChangeRequest in changeRequests
                    join Approval in approvals on ChangeRequest.Id equals Approval.ReffrenceId
                    select new
                    {
                        ChangeRequest.Id,
                        ChangeRequest.MubaadaraId,
                        ChangeRequest.MubaadaraRequests,
                        ChangeRequest.PreviousValue,
                        ChangeRequest.NewValue,
                        Approval.UserId,
                        UserIdFrom = Approval.CreatorId,
                        Approval.CreationTime,
                        Approval.ActionlDate,
                    }
                ).ToList();

                var mubaadaras = await _mubaadaraRepository.GetListAsync();
                var mubaadaraUnitById = mubaadaras.ToDictionary(m => m.Id, m => m.UnitId);

                var units = await _organizationUnitRepository.GetListAsync();
                var unitNameById = units.ToDictionary(u => u.Id, u => u.GetProperty("ArabicName", u.DisplayName));

                // The "approved by" column can't go through the usual user lookup here:
                // that lookup (pms-identity-user/collection-by-load-options) inner-joins
                // Tenants and excludes the admin account, so approvers who are host users
                // - or admin itself - resolve to nothing and the cell renders blank. This
                // page spans every unit, so it hits those users constantly. Resolved to a
                // ready-made display name here instead, exactly like DirectorateName above.
                var approverIds = joined.Select(x => x.UserId).Distinct().ToList();
                var approvers = await _identityUserRepository.GetListByIdsAsync(approverIds);
                var approverNameById = approvers.ToDictionary(u => u.Id, BuildUserDisplayName);

                var result = joined.Select(x => new MubaadaraChangeRequestsApprovalDto
                {
                    MubaadaraChangeRequestId = x.Id,
                    MubaadaraRequests = x.MubaadaraRequests,
                    UserIdTo = x.UserId,
                    UserIdFrom = x.UserIdFrom ?? Guid.Empty,
                    PreviousValue = x.PreviousValue,
                    NewValue = x.NewValue,
                    RequestDate = x.CreationTime,
                    ApprovalDate = x.ActionlDate,
                    DirectorateName = mubaadaraUnitById.TryGetValue(x.MubaadaraId, out var unitId) && unitId.HasValue && unitNameById.TryGetValue(unitId.Value, out var name)
                        ? name
                        : null,
                    ApprovedByName = approverNameById.TryGetValue(x.UserId, out var approverName) ? approverName : null,
                });

                loadOptions.Sort = new[] {
                 new SortingInfo { Desc = true, Selector = "approvalDate" }
                 };

                var loadResult = DataSourceLoader.Load(result, loadOptions);
                return loadResult;
            }
        }

        // Same "Rank / Name / Position" shape the user lookup shows elsewhere, read
        // off the user's extra properties. Falls back to whatever parts exist, and
        // finally to the user name, so host/admin accounts (which carry none of the
        // military extra properties) still show something rather than an empty cell.
        private static string BuildUserDisplayName(IdentityUser user)
        {
            var isArabic = CultureInfo.CurrentUICulture.Name != "en-US";

            var parts = new[]
            {
                user.GetProperty<string>(isArabic ? "RankArabic" : "RankEnglish"),
                user.GetProperty<string>(isArabic ? "ArabicName" : "EnglishName"),
                user.GetProperty<string>(isArabic ? "PositionArabic" : "PositionEnglish"),
            }.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();

            return parts.Count > 0 ? string.Join(" / ", parts) : user.UserName;
        }

        public async Task<int> GetIsChangeRerquestHaveApproval(Guid id)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubaadaraApprovalRepository.GetQueryableAsync()).Where(c => c.ReffrenceId == id);
            if (source.Count()> 0)
            {
                return 0;
            }
            else {
                return 1;
            }
        }

        public async Task<LoadResult> GetListByMubaadaraIdWithDetailsAsync(Guid id, DataSourceLoadOptions loadOptions)
        {
            var MubaadaraChangeRequests = (await _mubaadaraChangeRequestRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == id);

            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = (await _mubaadaraChangeRequestRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == id);
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<MubaadaraChangeRequestsDto>(config), loadOptions);
            return result;
        }



        //public async Task UpdateApprovalStatusToReject(Guid id, String note)
        //{
        //    var approval = await _approvalRepository.GetAsync(id);
        //    Guid refrenceId = approval.ReffrenceId;
        //    approval.ApprovalStatus = ApprovalStatus.Rejected;
        //    approval.Notes = note;
        //    await _approvalRepository.UpdateAsync(approval, true);


        //    if (approval.TabName == TabName.Extensions)
        //    {
        //        var durationExtension = await _durationExtensionRepository.GetAsync(refrenceId);
        //        durationExtension.IsApproved = true;
        //        await _durationExtensionRepository.UpdateAsync(durationExtension);
        //        var projectId = durationExtension.ProjectId;


        //    }

        //    else if (approval.TabName == TabName.ChangeRequest)
        //    {
        //        var changeRequest = await _changeRequestRepository.GetAsync(refrenceId);
        //        changeRequest.IsApproval = true;
        //        await _changeRequestRepository.UpdateAsync(changeRequest);
        //        var projectId = changeRequest.ProjectId;
        //        //var projectId = await _changeRequestRepository.GetAsync(refrenceId);


        //    }
        //    else if (approval.TabName == TabName.Drawing)
        //    {

        //        var drawing = await _drawingRepository.GetAsync(refrenceId);
        //        drawing.IsApproval = true;
        //        await _drawingRepository.UpdateAsync(drawing, true);
        //    }

        //    else if (approval.TabName == TabName.OtherProjectForms)
        //    {

        //        var otherprojectforms = await _otherProjectFormRepository.GetAsync(refrenceId);
        //        otherprojectforms.IsApproval = true;
        //        await _otherProjectFormRepository.UpdateAsync(otherprojectforms, true);
        //    }
        //    else if (approval.TabName == TabName.Warning)
        //    {

        //        var warning = await _warningRepository.GetAsync(refrenceId);
        //        warning.IsApproval = true;
        //        await _warningRepository.UpdateAsync(warning, true);
        //    }


        //}



        //public async Task UpdateAsync(Guid id, int input)
        //{

        //    var approval = await _approvalRepository.GetAsync(id);
        //    approval.Priority = input;
        //    await _approvalRepository.UpdateAsync(approval);

        //}


        //public Task<bool> GetApprovalsAsync(Guid refrenceId)
        //{
        //    return _approvalRepository.AnyAsync(c => c.ReffrenceId == refrenceId && c.IsApproved);
        //}


        //public async Task UpdateIsApprovedFieldsAsync(Guid id, string note)
        //{
        //    var approval = await _approvalRepository.GetAsync(id);
        //    approval.IsApproved = true;
        //    approval.ApprovalStatus = ApprovalStatus.Approved;
        //    approval.Notes = note;
        //    await _approvalRepository.UpdateAsync(approval, true);
        //    var tabName = _l[approval.TabName.ToString()];

        //    using (_dataFilter.Disable<IMultiTenant>())
        //    {

        //        Guid refrenceId = approval.ReffrenceId;
        //        var ExtApprovals = (await _approvalRepository.GetQueryableAsync()).Where(c => c.ReffrenceId == refrenceId);
        //        bool isApproval = ExtApprovals.All(c => c.IsApproved == true);

        //        var priority = approval.Priority + 1;
        //        var nextApproval = await _approvalRepository.FindAsync(c => c.ReffrenceId == refrenceId && c.Priority == priority);
        //        if (nextApproval != null)
        //        {
        //            var nextUser = await _identityUserRepository.FindAsync(nextApproval.UserId);

        //            var emailBody1 = await _templateRenderer.RenderAsync(
        //            StandardEmailTemplates.Message, new
        //            {
        //                text = L["TitleApproval"],
        //                message = string.Format(L["MessageApproval"], tabName)
        //            });
        //            await _emailSender.SendAsync(
        //                                                     nextUser.Email,
        //                                                    "Approval<اعتماد>",
        //                                                     emailBody1
        //                                                 );



        //        }

        //        //sending email
        //        if (approval.TabName == TabName.Extensions && isApproval == true)
        //        {
        //            var durationExtension = await _durationExtensionRepository.GetAsync(refrenceId);
        //            durationExtension.IsApproved = isApproval;
        //            await _durationExtensionRepository.UpdateAsync(durationExtension);
        //            var projectId = durationExtension.ProjectId;

        //            List<string> emailAddressList = (await _memberRepository1.GetMembersQueryableAsync()).Where(x => x.Member.ProjectId == projectId).Select(x => x.User.Email).ToList();
        //            Project project = await _projectRepository.GetAsync((Guid)projectId);

        //            var emailBody = await _templateRenderer.RenderAsync(
        //                         StandardEmailTemplates.Message, new
        //                         {
        //                             text = L["TitleApproval"],
        //                             message = string.Format(L["MessageExtension"], project.ArabicName)
        //                         }
        //                     );
        //            if (emailAddressList is { Count: > 0 })
        //            {
        //                await _backgroundJobManager.EnqueueAsync(
        //                    new EmailSendingArgs
        //                    {
        //                        EmailAddressList = emailAddressList,
        //                        Subject = "Approval<اعتماد>",
        //                        Body = emailBody
        //                    }
        //                );
        //            }
        //        }

        //        else if (approval.TabName == TabName.ChangeRequest && isApproval == true)
        //        {
        //            var changeRequest = await _changeRequestRepository.GetAsync(refrenceId);
        //            changeRequest.IsApproval = isApproval;
        //            await _changeRequestRepository.UpdateAsync(changeRequest);
        //            var projectId = changeRequest.ProjectId;
        //            //var projectId = await _changeRequestRepository.GetAsync(refrenceId);

        //            List<string> emailAddressList = (await _memberRepository1.GetMembersQueryableAsync()).Where(x => x.Member.ProjectId == projectId).Select(x => x.User.Email).ToList();
        //            Project project = await _projectRepository.GetAsync((Guid)projectId);

        //            var emailBody = await _templateRenderer.RenderAsync(
        //           StandardEmailTemplates.Message, new
        //           {
        //               text = L["TitleApproval"],
        //           }
        //       );
        //            if (emailAddressList is { Count: > 0 })
        //            {
        //                await _backgroundJobManager.EnqueueAsync(
        //                    new EmailSendingArgs
        //                    {
        //                        EmailAddressList = emailAddressList,
        //                        Subject = "Approval<اعتماد>",
        //                        Body = emailBody
        //                    }
        //                );
        //            }
        //        }
        //        else if (approval.TabName == TabName.Drawing && isApproval == true)
        //        {

        //            var drawing = await _drawingRepository.GetAsync(refrenceId);
        //            drawing.IsApproval = isApproval;
        //            await _drawingRepository.UpdateAsync(drawing, true);
        //        }

        //        else if (approval.TabName == TabName.OtherProjectForms && isApproval == true)
        //        {

        //            var otherprojectforms = await _otherProjectFormRepository.GetAsync(refrenceId);
        //            otherprojectforms.IsApproval = isApproval;
        //            await _otherProjectFormRepository.UpdateAsync(otherprojectforms, true);
        //        }
        //        else if (approval.TabName == TabName.Warning && isApproval == true)
        //        {

        //            var warning = await _warningRepository.GetAsync(refrenceId);
        //            warning.IsApproval = isApproval;
        //            await _warningRepository.UpdateAsync(warning, true);
        //        }


        //        var workflow = await _workflowRepository.FindAsync(c => c.ApprovalId == id);
        //        if (workflow != null)
        //        {
        //            workflow.WorkflowStatus = WorkflowStatus.Outbox;
        //            workflow.SendDateTime = DateTime.Now;
        //            await _workflowRepository.UpdateAsync(workflow);
        //        }

        //    }
        //}

        //public async Task CreateWorkFlowForApprovals(object input)
        //{


        //    using (_dataFilter.Disable<IMultiTenant>())
        //    {

        //        Guid projectId = Guid.Empty;
        //        var approval = new Approval();
        //        JsonConvert.PopulateObject(input.ToString(), approval);
        //        var UserFromData = await _identityUserRepository.GetAsync((Guid)CurrentUser.Id);//current user id
        //        var currentApproval = await _approvalRepository.FindAsync(c => c.ReffrenceId == approval.ReffrenceId && c.TabName == approval.TabName && c.UserId == (Guid)CurrentUser.Id);
        //        var CurrentApprovalId = Guid.Empty;
        //        if (currentApproval != null) { CurrentApprovalId = currentApproval.Id; } // CURRENT APPROVAL 


        //        // Get Approval Id for current user who is approving 
        //        var nextApprovalId = Guid.Empty;
        //        var userIdto = Guid.Empty;
        //        var nextApproval = await _approvalRepository.FindAsync(c => c.ReffrenceId == approval.ReffrenceId && c.TabName == approval.TabName && c.Priority == approval.Priority);
        //        if (nextApproval != null) { nextApprovalId = nextApproval.Id; userIdto = nextApproval.UserId; }




        //        // Get The Current user workflow using approval ID 
        //        var workflow = await _workflowRepository.FindAsync(c => c.ApprovalId == CurrentApprovalId);

        //        if (workflow != null)
        //        {
        //            workflow.WorkflowStatus = WorkflowStatus.Outbox;
        //            workflow.SendDateTime = DateTime.Now;
        //            await _workflowRepository.UpdateAsync(workflow);
        //        }

        //        // this condition to add workflow to the next user 
        //        if (userIdto != Guid.Empty)
        //        {



        //            var User = await _identityUserRepository.FindAsync(userIdto);


        //            projectId = await GetProjectId(approval);

        //            var workFlow = new Workflow()
        //            {
        //                ProjectId = projectId,
        //                UserIdFrom = (Guid)CurrentUser.Id,
        //                UserNameFrom = $"{UserFromData.GetProperty<string>("PositionArabic", "PositionArabic")} - {UserFromData.GetProperty<string>("RankArabic", "RankArabic")} - {UserFromData.GetProperty<string>("ArabicName", "ArabicName")}",
        //                UserIdTo = userIdto,
        //                UserNameTo = $"{User.GetProperty<string>("PositionArabic", "PositionArabic")} - {User.GetProperty<string>("RankArabic", "RankArabic")} - {User.GetProperty<string>("ArabicName", "ArabicName")}",
        //                //Action = "تم إرسال الإجراء تلقائياً وذلك لإعتماد" + approval.TabName.ToString(),
        //                Action = _l["ActionMessage"].ToString() + " " + _l[approval.TabName.ToString()].ToString(),
        //                AlertDays = 0,
        //                Classification = Classification.ToAction,
        //                WorkflowStatus = WorkflowStatus.Inbox,
        //                ApprovalId = nextApprovalId
        //            };
        //            await _workflowRepository.InsertAsync(workFlow);
        //        }
        //    }
        //}
        //public async Task CreateWorkFlowForSaving(object input)
        //{
        //    try
        //    {
        //        using (_dataFilter.Disable<IMultiTenant>())
        //        {
        //            Guid projectId = Guid.Empty;
        //            var approval = new Approval();
        //            JsonConvert.PopulateObject(input.ToString(), approval);
        //            var UserFromData = await _identityUserRepository.GetAsync((Guid)CurrentUser.Id);//current user id
        //            var currentApproval = await _approvalRepository.FindAsync(c => c.ReffrenceId == approval.ReffrenceId && c.TabName == approval.TabName && c.Priority == 1);
        //            var CurrentApprovalId = Guid.Empty;
        //            var userIdto = Guid.Empty;
        //            if (currentApproval != null) { CurrentApprovalId = currentApproval.Id; userIdto = currentApproval.UserId; } // CURRENT APPROVAL 



        //            // this condition to add workflow to the next user 
        //            if (userIdto != Guid.Empty)
        //            {



        //                var User = await _identityUserRepository.FindAsync((Guid)userIdto);


        //                projectId = await GetProjectId(approval);

        //                var workFlow = new Workflow()
        //                {
        //                    ProjectId = projectId,
        //                    UserIdFrom = (Guid)CurrentUser.Id,
        //                    UserNameFrom = $"{UserFromData.GetProperty<string>("PositionArabic", "PositionArabic")} - {UserFromData.GetProperty<string>("RankArabic", "RankArabic")} - {UserFromData.GetProperty<string>("ArabicName", "ArabicName")}",
        //                    UserIdTo = userIdto,
        //                    UserNameTo = $"{User.GetProperty<string>("PositionArabic", "PositionArabic")} - {User.GetProperty<string>("RankArabic", "RankArabic")} - {User.GetProperty<string>("ArabicName", "ArabicName")}",
        //                    //Action = "تم إرسال الإجراء تلقائياً وذلك لإعتماد" + approval.TabName.ToString(),
        //                    Action = _l["ActionMessage"].ToString() + " " + _l[approval.TabName.ToString()].ToString(),
        //                    AlertDays = 0,
        //                    Classification = Classification.ToAction,
        //                    WorkflowStatus = WorkflowStatus.Inbox,
        //                    ApprovalId = CurrentApprovalId,
        //                    TabName = approval.TabName,

        //                };
        //                await _workflowRepository.InsertAsync(workFlow);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }


        //}
        //private async Task<Guid> GetProjectId(Approval approval)
        //{
        //    Guid projectId = Guid.Empty;
        //    switch (approval.TabName)
        //    {
        //        case TabName.Drawing:
        //            var outputDrawing = (await _drawingRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            projectId = outputDrawing.FirstOrDefault().ProjectId;
        //            break;
        //        case TabName.Form:
        //            break;
        //        case TabName.Invoice:
        //            var outputInvoice = (await _invoiceRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            projectId = outputInvoice.FirstOrDefault().ProjectId;
        //            break;
        //        case TabName.Agent:
        //            break;
        //        case TabName.Warning:
        //            var outputWarning = (await _warningRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            projectId = outputWarning.FirstOrDefault().ProjectId;
        //            break;
        //        case TabName.ChangeRequest:
        //            var outputChangeRequest = (await _changeRequestRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            projectId = outputChangeRequest.FirstOrDefault().ProjectId;
        //            break;
        //        case TabName.Tenders:

        //            var outputTender = (await _tenderRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            projectId = outputTender.FirstOrDefault().ProjectId;
        //            break;
        //        case TabName.FinancialAnalysis:
        //            outputTender = (await _tenderRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            projectId = outputTender.FirstOrDefault().ProjectId;
        //            break;
        //        case TabName.TechnicalAnalysis:
        //            outputTender = (await _tenderRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            projectId = outputTender.FirstOrDefault().ProjectId;
        //            break;
        //        case TabName.Extensions:
        //            var outputDurationExt = (await _durationExtensionRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            projectId = outputDurationExt.FirstOrDefault().ProjectId.Value;
        //            break;
        //        case TabName.AgentEvaluation:
        //            var agentproject = (await _agentProjectRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            projectId = agentproject.FirstOrDefault().ProjectId;
        //            break;
        //        case TabName.RecommendationResult:
        //            outputTender = (await _tenderRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            projectId = outputTender.FirstOrDefault().ProjectId;
        //            break;

        //        case TabName.AnalysisPriceOffers:
        //            outputTender = (await _tenderRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            projectId = outputTender.FirstOrDefault().ProjectId;
        //            break;
        //        case TabName.Contract:
        //            var outputTenderForm = (await _tenderFormRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            var tenderid = outputTenderForm.FirstOrDefault().tenderId;
        //            outputTender = (await _tenderRepository.GetQueryableAsync()).Where(c => c.Id == tenderid);
        //            projectId = outputTender.FirstOrDefault().ProjectId;
        //            break;
        //        case TabName.FinanceOrder:
        //            outputTenderForm = (await _tenderFormRepository.GetQueryableAsync()).Where(c => c.Id == approval.ReffrenceId);
        //            tenderid = outputTenderForm.FirstOrDefault().tenderId;
        //            outputTender = (await _tenderRepository.GetQueryableAsync()).Where(c => c.Id == tenderid);
        //            projectId = outputTender.FirstOrDefault().ProjectId;
        //            break;
        //        default:
        //            break;
        //    }

        //    return projectId;
        //}



        //public async Task CheckApproval(Guid referenceId, TabName tabName)
        //{








    }
}
