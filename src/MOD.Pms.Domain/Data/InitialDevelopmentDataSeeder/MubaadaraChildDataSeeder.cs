using MOD.Pms.Enums;
using MOD.Pms.MubaadaraApprovals;
using MOD.Pms.MubaadaraChangeRequests;
using MOD.Pms.MubaadaraDetails;
using MOD.Pms.MubaadaraHEComments;
using MOD.Pms.MubaadarasMembers;
using MOD.Pms.MubaadaraUpdates;
using MOD.Pms.MubaadaraWorkflows;
using MOD.Pms.Mubaadaras;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Uow;

namespace MOD.Pms.Data.InitialDevelopmentDataSeeder
{
    public interface IMubaadaraChildDataSeeder
    {
        Task SeedAsync();
    }

    public class MubaadaraChildDataSeeder : ITransientDependency, IMubaadaraChildDataSeeder
    {
        private readonly IRepository<Mubaadara, Guid> _mubaadaraRepository;
        private readonly IRepository<MubaadaraDetail, Guid> _mubaadaraDetailRepository;
        private readonly IRepository<MubaadaraHEComment, Guid> _mubaadaraHECommentRepository;
        private readonly IRepository<MubaadaraMember, Guid> _mubaadaraMemberRepository;
        private readonly IRepository<MubaadarasWorkflow, Guid> _mubaadaraWorkflowRepository;
        private readonly IRepository<MubaadaraChangeRequest, Guid> _mubaadaraChangeRequestRepository;
        private readonly IRepository<MubaadaraUpdate, Guid> _mubaadaraUpdateRepository;
        private readonly IRepository<MubaadaraApproval, Guid> _mubaadaraApprovalRepository;
        private readonly IIdentityUserRepository _identityUserRepository;

        public MubaadaraChildDataSeeder(
            IRepository<Mubaadara, Guid> mubaadaraRepository,
            IRepository<MubaadaraDetail, Guid> mubaadaraDetailRepository,
            IRepository<MubaadaraHEComment, Guid> mubaadaraHECommentRepository,
            IRepository<MubaadaraMember, Guid> mubaadaraMemberRepository,
            IRepository<MubaadarasWorkflow, Guid> mubaadaraWorkflowRepository,
            IRepository<MubaadaraChangeRequest, Guid> mubaadaraChangeRequestRepository,
            IRepository<MubaadaraUpdate, Guid> mubaadaraUpdateRepository,
            IRepository<MubaadaraApproval, Guid> mubaadaraApprovalRepository,
            IIdentityUserRepository identityUserRepository)
        {
            _mubaadaraRepository = mubaadaraRepository;
            _mubaadaraDetailRepository = mubaadaraDetailRepository;
            _mubaadaraHECommentRepository = mubaadaraHECommentRepository;
            _mubaadaraMemberRepository = mubaadaraMemberRepository;
            _mubaadaraWorkflowRepository = mubaadaraWorkflowRepository;
            _mubaadaraChangeRequestRepository = mubaadaraChangeRequestRepository;
            _mubaadaraUpdateRepository = mubaadaraUpdateRepository;
            _mubaadaraApprovalRepository = mubaadaraApprovalRepository;
            _identityUserRepository = identityUserRepository;
        }

        [UnitOfWork]
        public async Task SeedAsync()
        {
            var mubaadaras = await _mubaadaraRepository.GetListAsync();
            if (!mubaadaras.Any())
            {
                return;
            }

            // These child tables aren't tenant-scoped, so seed per-Mubaadara
            // (skipping ones that already have detail rows) rather than gating
            // on a single global AnyAsync() check.
            var mubaadaraIdsWithDetails = (await _mubaadaraDetailRepository.GetListAsync())
                .Select(d => d.MubaadaraId)
                .ToHashSet();

            var admin = await _identityUserRepository.FindByNormalizedUserNameAsync("ADMIN");
            var userId = admin?.Id ?? Guid.Empty;
            var now = DateTime.Now;

            foreach (var mubaadara in mubaadaras)
            {
                if (mubaadaraIdsWithDetails.Contains(mubaadara.Id))
                {
                    continue;
                }

                await _mubaadaraDetailRepository.InsertAsync(new MubaadaraDetail
                {
                    MubaadaraId = mubaadara.Id,
                    Challenge = "Delay in receiving required approvals from stakeholders",
                    Note = "Follow-up scheduled with the responsible department",
                    Solution = "Escalated to unit management for expedited review",
                    ApproveStatus = MubaadaraChallengeStatus.Pendding,
                }, true);

                await _mubaadaraHECommentRepository.InsertAsync(new MubaadaraHEComment
                {
                    MubaadaraId = mubaadara.Id,
                    UserIdFrom = userId,
                    UserNameFrom = "admin",
                    UserIdTo = userId,
                    UserNameTo = "admin",
                    Comment = "Please provide an update on current progress.",
                    ActionDate = now,
                    IsActionDone = false,
                }, true);

                await _mubaadaraMemberRepository.InsertAsync(new MubaadaraMember
                {
                    MubaadaraId = mubaadara.Id,
                    UserId = userId,
                    MubaadaraMemberPermission = MubaadaraMemberPermission.ApprovalRequest,
                    MubaadaraStructures = MubaadaraStructures.MubaadaraManager,
                }, true);

                await _mubaadaraWorkflowRepository.InsertAsync(new MubaadarasWorkflow
                {
                    MubaadaraId = mubaadara.Id,
                    UserIdFrom = userId,
                    UserNameFrom = "admin",
                    UserIdTo = userId,
                    UserNameTo = "admin",
                    Action = "Submitted for review",
                    Classification = Classification.ToAction,
                    ActionDate = now,
                    IsActionDone = false,
                }, true);

                var changeRequest = await _mubaadaraChangeRequestRepository.InsertAsync(new MubaadaraChangeRequest
                {
                    MubaadaraId = mubaadara.Id,
                    MubaadaraRequests = MubaadaraRequests.ChangeCompletionPercentage,
                    PreviousValue = "20",
                    NewValue = "35",
                    NewCompletionPercentage = 35,
                    IsApproved = false,
                    IsHaveApprovealRow = true,
                    ApprovalStatus = ApprovalStatus.Pendding,
                }, true);

                await _mubaadaraUpdateRepository.InsertAsync(new MubaadaraUpdate
                {
                    MubaadaraId = mubaadara.Id,
                    ChangeType = UpdateType.Updates,
                    NewValue = "Completion percentage updated",
                }, true);

                await _mubaadaraApprovalRepository.InsertAsync(new MubaadaraApproval
                {
                    ReffrenceId = changeRequest.Id,
                    Priority = 1,
                    UserId = userId,
                    IsActionDone = false,
                    ActionlDate = now,
                    SenderNotes = "Please review and approve.",
                    MubaadaraRequestsReply = MubaadaraRequestsReply.Pendding,
                }, true);
            }
        }
    }
}
