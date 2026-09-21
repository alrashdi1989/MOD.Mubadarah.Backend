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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;
using Volo.Saas.Tenants;

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
        private readonly IdentityUserManager _identityUserManager;
        private readonly ITenantRepository _tenantRepository;
        private readonly IDataFilter _dataFilter;
        private readonly IGuidGenerator _guidGenerator;

        public MubaadaraChildDataSeeder(
            IRepository<Mubaadara, Guid> mubaadaraRepository,
            IRepository<MubaadaraDetail, Guid> mubaadaraDetailRepository,
            IRepository<MubaadaraHEComment, Guid> mubaadaraHECommentRepository,
            IRepository<MubaadaraMember, Guid> mubaadaraMemberRepository,
            IRepository<MubaadarasWorkflow, Guid> mubaadaraWorkflowRepository,
            IRepository<MubaadaraChangeRequest, Guid> mubaadaraChangeRequestRepository,
            IRepository<MubaadaraUpdate, Guid> mubaadaraUpdateRepository,
            IRepository<MubaadaraApproval, Guid> mubaadaraApprovalRepository,
            IIdentityUserRepository identityUserRepository,
            IdentityUserManager identityUserManager,
            ITenantRepository tenantRepository,
            IDataFilter dataFilter,
            IGuidGenerator guidGenerator)
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
            _identityUserManager = identityUserManager;
            _tenantRepository = tenantRepository;
            _dataFilter = dataFilter;
            _guidGenerator = guidGenerator;
        }

        // The member picker (identity users list) only ever surfaces users that
        // (a) aren't named "admin" and (b) have a non-null TenantId matching a
        // real SaaS tenant row - see PmsIdentityUserRepository.GetIdentityUsersQueryableAsync.
        // The only accounts that exist out of the box are per-tenant "admin"
        // bootstrap users, so that list is always empty without these.
        private static readonly (string ServiceNumber, string ArabicName, string EnglishName, string RankArabic, string RankEnglish, int RankOrder, string PositionArabic, string PositionEnglish, string UnitArabic, string UnitEnglish)[] DummyPersonnel =
        {
            ("31245", "خالد بن سالم المطيري", "Khaled Al-Mutairi", "عقيد", "Colonel", 3, "رئيس قسم المشاريع", "Projects Section Head", "مديرية الهندسة", "Engineering Directorate"),
            ("34781", "سعيد بن راشد الحارثي", "Saeed Al-Harthi", "مقدم", "Lieutenant Colonel", 4, "ضابط متابعة", "Follow-up Officer", "مديرية الإدارة", "Administration Directorate"),
            ("38902", "فهد بن ناصر العتيبي", "Fahad Al-Otaibi", "رائد", "Major", 5, "ضابط تخطيط", "Planning Officer", "مديرية التخطيط", "Planning Directorate"),
            ("41056", "ماجد بن علي الشمري", "Majid Al-Shammari", "نقيب", "Captain", 6, "منسق مشاريع", "Projects Coordinator", "مديرية العمليات", "Operations Directorate"),
            ("44210", "علي بن حمد الكندي", "Ali Al-Kindi", "ملازم أول", "First Lieutenant", 7, "ضابط إداري", "Administrative Officer", "مديرية الموارد", "Resources Directorate"),
        };

        private async Task<List<Guid>> EnsureDummyPersonnelAsync()
        {
            var userIds = new List<Guid>();

            using (_dataFilter.Disable<IMultiTenant>())
            {
                var tenantId = (await _tenantRepository.GetListAsync()).FirstOrDefault()?.Id;

                foreach (var person in DummyPersonnel)
                {
                    var existing = await _identityUserRepository.FindByNormalizedUserNameAsync(person.ServiceNumber.ToUpperInvariant());
                    if (existing != null)
                    {
                        userIds.Add(existing.Id);
                        continue;
                    }

                    var user = new IdentityUser(_guidGenerator.Create(), person.ServiceNumber, $"{person.ServiceNumber}@mod.saf", tenantId)
                    {
                        Name = person.EnglishName,
                    };
                    user.SetIsActive(true);
                    user.SetProperty("ServiceNumber", person.ServiceNumber);
                    user.SetProperty("RankArabic", person.RankArabic);
                    user.SetProperty("RankEnglish", person.RankEnglish);
                    user.SetProperty("RankOrder", person.RankOrder);
                    user.SetProperty("ArabicName", person.ArabicName);
                    user.SetProperty("EnglishName", person.EnglishName);
                    user.SetProperty("PositionArabic", person.PositionArabic);
                    user.SetProperty("PositionEnglish", person.PositionEnglish);
                    user.SetProperty("MainUnitArabic", person.UnitArabic);
                    user.SetProperty("MainUnitEnglish", person.UnitEnglish);

                    var result = await _identityUserManager.CreateAsync(user, "Aa123456*");
                    if (!result.Succeeded)
                    {
                        continue;
                    }

                    userIds.Add(user.Id);
                }
            }

            return userIds;
        }

        private async Task EnsureMubaadaraMembersAsync(List<Mubaadara> mubaadaras, List<Guid> dummyPersonnelIds)
        {
            if (!dummyPersonnelIds.Any())
            {
                return;
            }

            var structures = new[] { MubaadaraStructures.MubaadaraHeadManager, MubaadaraStructures.MubaadaraGeneralManager };

            for (var i = 0; i < mubaadaras.Count; i++)
            {
                var mubaadara = mubaadaras[i];
                var existingMemberUserIds = (await _mubaadaraMemberRepository.GetListAsync(m => m.MubaadaraId == mubaadara.Id))
                    .Select(m => m.UserId)
                    .ToHashSet();

                if (existingMemberUserIds.Count >= 3)
                {
                    continue;
                }

                var structureIndex = 0;
                for (var offset = 0; offset < dummyPersonnelIds.Count && existingMemberUserIds.Count < 3; offset++)
                {
                    var candidateUserId = dummyPersonnelIds[(i + offset) % dummyPersonnelIds.Count];
                    if (existingMemberUserIds.Contains(candidateUserId))
                    {
                        continue;
                    }

                    await _mubaadaraMemberRepository.InsertAsync(new MubaadaraMember
                    {
                        MubaadaraId = mubaadara.Id,
                        UserId = candidateUserId,
                        MubaadaraMemberPermission = MubaadaraMemberPermission.ApprovalRequest,
                        MubaadaraStructures = structures[structureIndex % structures.Length],
                    }, true);

                    existingMemberUserIds.Add(candidateUserId);
                    structureIndex++;
                }
            }
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

            // Backfill a few named, non-admin members onto every Mubaadara (not just
            // the newly-detailed ones above) so member pickers in the UI have more
            // than the single "admin" row to choose from.
            var dummyPersonnelIds = await EnsureDummyPersonnelAsync();
            await EnsureMubaadaraMembersAsync(mubaadaras, dummyPersonnelIds);
        }
    }
}
