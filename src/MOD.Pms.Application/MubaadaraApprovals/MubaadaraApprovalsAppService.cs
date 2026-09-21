using Microsoft.Extensions.Localization;
using MOD.Pms.Common;
using MOD.Pms.Localization;
using MOD.Pms.Enums;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using MOD.Pms.MubaadaraChangeRequests;
using MOD.Pms.Mubaadaras;
using MOD.Pms.MubaadaraWorkflows;
using Volo.Abp.Identity;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;


namespace MOD.Pms.MubaadaraApprovals
{
    [Authorize]
    public class MubaadaraApprovalsAppService : PmsAppService, IMubaadaraApprovalsAppService
    {
        private readonly IRepository<MubaadaraApproval, Guid> _mubaadaraApprovalRepository;
        private readonly IRepository<MubaadaraChangeRequest, Guid> _mubaadaraChangeRequestRepository;
        private readonly IRepository<Mubaadara, Guid> _mubaadaraRepository;
        private readonly IRepository<MubaadarasWorkflow, Guid> _mubaadaraWorkflowRepository;
        private readonly IStringLocalizer<PmsResource> _l;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IDataFilter _dataFilter;

        public MubaadaraApprovalsAppService(
            IRepository<MubaadaraApproval, Guid> mubaadaraApprovalRepository,
            IRepository<MubaadarasWorkflow, Guid> mubaadaraWorkflowRepository,
            IRepository<MubaadaraChangeRequest, Guid> mubaadaraChangeRequestRepository,
            IRepository<Mubaadara, Guid> mubaadaraRepository,
            IIdentityUserRepository identityUserRepository,
            IDataFilter dataFilter,
            IStringLocalizer<PmsResource> l)
        {
            _mubaadaraApprovalRepository = mubaadaraApprovalRepository;
            _mubaadaraChangeRequestRepository = mubaadaraChangeRequestRepository;
            _mubaadaraRepository = mubaadaraRepository;
            _mubaadaraWorkflowRepository = mubaadaraWorkflowRepository;
            _identityUserRepository = identityUserRepository;
            _dataFilter = dataFilter;
            _l = l;
        }

        public async Task <CommonOperationResultDto<MubaadaraApprovalInput>> CreateAsync(MubaadaraApprovalInput input) {
            var mubaadaraApproval = new MubaadaraApproval();
            mubaadaraApproval.ReffrenceId = (Guid)input.ReffrenceId;
            mubaadaraApproval.UserId = input.UserId;
            mubaadaraApproval.SenderNotes = input.Notes;
            mubaadaraApproval.MubaadaraRequestsReply = MubaadaraRequestsReply.Pendding;
            mubaadaraApproval.IsActionDone =  false;
            MubaadaraApproval newMubaadaraAproval = await _mubaadaraApprovalRepository.InsertAsync(mubaadaraApproval);
            Guid newMubaadaraApprovalId= newMubaadaraAproval.Id;
// Update Mubaadara Change Request IsHaveApprovealRow to True -------------------------------------------------------------------------------------------------------
            var mubaadaraChangeRequests = new MubaadaraChangeRequest();
            mubaadaraChangeRequests = await _mubaadaraChangeRequestRepository.GetAsync(mubaadaraApproval.ReffrenceId);
            mubaadaraChangeRequests.IsHaveApprovealRow = true;
            await _mubaadaraChangeRequestRepository.UpdateAsync(mubaadaraChangeRequests, true);
// Call CreateMubaadaraWorkflow() To Insert Mubaadara Workflow For Snet Approval Code await _mubaadaraApprovalRepository.InsertAsync(mubaadaraApproval);---------------------------------------------------------------------------------------------------------------------------------------------------
            await CreateMubaadaraWorkflow((Guid)input.ReffrenceId, input.UserId , newMubaadaraApprovalId);
            return new CommonOperationResultDto<MubaadaraApprovalInput>(_l["Message"], true);
        }

        public async Task<CommonOperationResultDto<MubaadaraApprovalActionInput>> UpdateMubaadaraRequestsReplyAsync(MubaadaraApprovalActionInput input)
        {
            var mubaadaraApproval = await _mubaadaraApprovalRepository.GetAsync((Guid)input.mubaadaraApprovalId);
            var mubaadaraChangeRequests = await _mubaadaraChangeRequestRepository.GetAsync(mubaadaraApproval.ReffrenceId);
            var mubaadara = await _mubaadaraRepository.GetAsync(mubaadaraChangeRequests.MubaadaraId);

            mubaadaraApproval.ReceiverNotes = input.ReceiverNotes;
            mubaadaraApproval.IsActionDone = true;
            mubaadaraApproval.ActionlDate = DateTime.Today;
            await _mubaadaraApprovalRepository.UpdateAsync(mubaadaraApproval, true);

            if (input.MubaadaraRequestsReply == MubaadaraRequestsReply.Approved)
            {
                // 1- Update Mubaadara Approval Requests Reply -----------------------------------------------------------------------------------------------------------------------------------
                mubaadaraApproval.MubaadaraRequestsReply = MubaadaraRequestsReply.Approved;

                // 2- Update Mubaadara Change Requests Reply -----------------------------------------------------------------------------------------------------------------------------------
                mubaadaraChangeRequests.IsApproved = true;
                mubaadaraChangeRequests.ApprovalStatus = ApprovalStatus.Approved;

                // 3- Update Mubaadara -----------------------------------------------------------------------------------------------------------------------------------

                if (mubaadaraChangeRequests.MubaadaraRequests == MubaadaraRequests.ChangeCompletionPercentage)
                {
                    mubaadara.CompletionPercentage = (decimal)mubaadaraChangeRequests.NewCompletionPercentage;
                }
                else if (mubaadaraChangeRequests.MubaadaraRequests == MubaadaraRequests.ChangeMubaadaraStatus)
                {
                    mubaadara.StatusId = (Guid)mubaadaraChangeRequests.NewStatusId;
                }
                else if (mubaadaraChangeRequests.MubaadaraRequests == MubaadaraRequests.ExtensionApproved)
                {
                    mubaadara.ActualEndDate = mubaadaraChangeRequests.NewEndDate;
                }
            }

            else if (input.MubaadaraRequestsReply == MubaadaraRequestsReply.Rejected)
            {
                // 1- Update Mubaadara Approval Requests Reply -----------------------------------------------------------------------------------------------------------------------------------
                mubaadaraApproval.MubaadaraRequestsReply = MubaadaraRequestsReply.Rejected;

                // 2- Update Mubaadara Change Requests Reply -----------------------------------------------------------------------------------------------------------------------------------
                mubaadaraChangeRequests.IsApproved = false;
                mubaadaraChangeRequests.ApprovalStatus = ApprovalStatus.Rejected;
            }

            else if (input.MubaadaraRequestsReply == MubaadaraRequestsReply.Forward)
            {
                // 1- Update Mubaadara Approval Requests Reply -----------------------------------------------------------------------------------------------------------------------------------
                mubaadaraApproval.MubaadaraRequestsReply = MubaadaraRequestsReply.Forward;
                mubaadaraApproval.ReceiverNotes = "تم التحويل للإجراء";

                // 2- Update Mubaadara Change Requests Reply -----------------------------------------------------------------------------------------------------------------------------------
                mubaadaraChangeRequests.IsApproved = false;
                var newMubaadaraApproval = new MubaadaraApproval();
                newMubaadaraApproval.ReffrenceId = (Guid)mubaadaraApproval.ReffrenceId;
                newMubaadaraApproval.UserId = (Guid)input.ForwardUserId;
                newMubaadaraApproval.SenderNotes = input.ReceiverNotes;
                newMubaadaraApproval.MubaadaraRequestsReply = MubaadaraRequestsReply.Pendding;
                newMubaadaraApproval.IsActionDone = false;
                MubaadaraApproval newMubaadara = await _mubaadaraApprovalRepository.InsertAsync(newMubaadaraApproval);
                Guid newMubaadaraApprovalId = mubaadaraApproval.Id;
                await _mubaadaraChangeRequestRepository.UpdateAsync(mubaadaraChangeRequests, true);

                mubaadaraChangeRequests = await _mubaadaraChangeRequestRepository.GetAsync(mubaadaraApproval.ReffrenceId);
                mubaadaraChangeRequests.IsHaveApprovealRow = true;
                await _mubaadaraChangeRequestRepository.UpdateAsync(mubaadaraChangeRequests, true);

                // 3- Call CreateMubaadaraWorkflow() To Insert Mubaadara Workflow For Snet Approval Code await _mubaadaraApprovalRepository.InsertAsync(mubaadaraApproval) ---------------------------------------------------------------------------------------------------------------------------------------------------
                await CreateMubaadaraWorkflow(newMubaadaraApproval.ReffrenceId, (Guid)input.ForwardUserId, newMubaadaraApprovalId);

            }
            await UpdateMubaadaraWorkflow(mubaadaraApproval.Id);
            return new CommonOperationResultDto<MubaadaraApprovalActionInput>(_l["Message"], true);
        }

        public async Task<CommonOperationResultDto<MubaadaraApprovalInput>> CreateMubaadaraWorkflow(Guid reffrenceId,  Guid userId, Guid newApprovalId)
        {
            var mubaadaraChangeRequests = await _mubaadaraChangeRequestRepository.GetAsync(reffrenceId);
            Volo.Abp.Identity.IdentityUser UserFromData;
            Volo.Abp.Identity.IdentityUser UserToData;
            using (_dataFilter.Disable<IMultiTenant>())
            {
                // The sender and the picked receiver can belong to different tenants
                // than the current one, so this lookup must not be tenant-filtered.
                UserFromData = await _identityUserRepository.GetAsync((Guid)CurrentUser.Id);//current user id
                UserToData = await _identityUserRepository.GetAsync(userId);
            }
            var mubaadarasWorkflow = new MubaadarasWorkflow()
            {
                MubaadaraId = (Guid)mubaadaraChangeRequests.MubaadaraId,
                UserIdFrom = (Guid)CurrentUser.Id,
                UserNameFrom = $"{UserFromData.GetProperty<string>("PositionArabic", "PositionArabic")} - {UserFromData.GetProperty<string>("RankArabic", "RankArabic")} - {UserFromData.GetProperty<string>("ArabicName", "ArabicName")}",
                UserIdTo = userId,
                UserNameTo = $"{UserToData.GetProperty<string>("PositionArabic", "PositionArabic")} - {UserToData.GetProperty<string>("RankArabic", "RankArabic")} - {UserToData.GetProperty<string>("ArabicName", "ArabicName")}",
                Action = _l["ActionMessage"].ToString() + " " + _l[mubaadaraChangeRequests.MubaadaraRequests.ToString()].ToString(),
                Classification = Enums.Classification.ToAction,
                MubaadaraApprovalId = newApprovalId,
               // ApprovalStatus = Enums.ApprovalStatus.Pendding,             
            };
            await _mubaadaraWorkflowRepository.InsertAsync(mubaadarasWorkflow);
            return new CommonOperationResultDto<MubaadaraApprovalInput>(_l["Message"], true);
        }

        public async Task<CommonOperationResultDto<MubaadaraApprovalInput>> UpdateMubaadaraWorkflow(Guid mubaadaraApprovalId)
        {
            var mubaadaraWorkflow = await _mubaadaraWorkflowRepository.FindAsync(c => c.MubaadaraApprovalId == mubaadaraApprovalId);
            if (mubaadaraWorkflow != null)
            {
                mubaadaraWorkflow.IsActionDone = true;
                mubaadaraWorkflow.ActionDate = DateTime.Today;

                await _mubaadaraWorkflowRepository.UpdateAsync(mubaadaraWorkflow, true);
            }
            return new CommonOperationResultDto<MubaadaraApprovalInput>(_l["Message"], true);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _mubaadaraApprovalRepository.DeleteAsync(id);
        }

    }
}
