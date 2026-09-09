using MOD.Pms.Enums;
using MOD.Pms.Mubaadaras;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace MOD.Pms.Data.InitialDevelopmentDataSeeder
{
    public interface IMubaadaraDummyDataSeeder
    {
        Task SeedAsync();
    }

    public class MubaadaraDummyDataSeeder : ITransientDependency, IMubaadaraDummyDataSeeder
    {
        private readonly IRepository<Mubaadara, Guid> _mubaadaraRepository;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IOrganizationUnitDummyDataSeeder _organizationUnitDummyDataSeeder;
        private readonly ICurrentTenant _currentTenant;

        public MubaadaraDummyDataSeeder(
            IRepository<Mubaadara, Guid> mubaadaraRepository,
            IIdentityUserRepository identityUserRepository,
            IOrganizationUnitDummyDataSeeder organizationUnitDummyDataSeeder,
            ICurrentTenant currentTenant)
        {
            _mubaadaraRepository = mubaadaraRepository;
            _identityUserRepository = identityUserRepository;
            _organizationUnitDummyDataSeeder = organizationUnitDummyDataSeeder;
            _currentTenant = currentTenant;
        }

        private static readonly Guid[] TypeIds =
        {
            Guid.Parse("91037B26-61C7-3913-D5F1-3A23973773AD"), // Administrative
            Guid.Parse("D5054471-A245-59D1-8C6A-3A23973773AE"), // Technical
            Guid.Parse("2F556F3B-3E37-0C31-AAA5-3A23973773CB"), // Financial
            Guid.Parse("DC7397FB-E825-0F4E-26A8-3A23973773D0"), // Training
            Guid.Parse("88BB1105-A994-D8DA-9B89-3A23973773D4"), // Development
        };

        private static readonly Guid[] StatusIds =
        {
            Guid.Parse("91C422D6-4CCB-2B8B-7D81-3A23973773E1"), // Not Started
            Guid.Parse("EDF40DD0-BCAB-0F7E-DAB7-3A23973773E5"), // In Progress
            Guid.Parse("6AFA728E-4324-EAAE-5D02-3A23973773E9"), // Completed
            Guid.Parse("23CB7A29-16B6-4B04-944E-3A23973773EC"), // Delayed
            Guid.Parse("798B293C-301B-FD55-AB5A-3A23973773F0"), // On Hold
        };

        private static readonly ApprovalStatus[] ApprovalStatuses =
        {
            ApprovalStatus.Pendding,
            ApprovalStatus.Approved,
            ApprovalStatus.Rejected,
        };

        private static readonly MubaadaraTypes[] Categories =
        {
            MubaadaraTypes.MainTarget,
            MubaadaraTypes.Projects,
            MubaadaraTypes.Tasks,
            MubaadaraTypes.ExtraTasks,
        };

        private static readonly (string En, string Ar)[] Titles =
        {
            ("Digital Records Modernization", "تحديث السجلات الرقمية"),
            ("Staff Skills Development Program", "برنامج تطوير مهارات الموظفين"),
            ("Facility Energy Efficiency Upgrade", "تحسين كفاءة الطاقة بالمرافق"),
            ("Procurement Process Automation", "أتمتة عمليات الشراء"),
            ("Annual Budget Optimization Review", "مراجعة تحسين الميزانية السنوية"),
            ("New Employee Onboarding Revamp", "تطوير برنامج تأهيل الموظفين الجدد"),
            ("Cybersecurity Awareness Initiative", "مبادرة التوعية بالأمن السيبراني"),
            ("Fleet Maintenance Scheduling System", "نظام جدولة صيانة الأسطول"),
            ("Document Archiving Standardization", "توحيد معايير أرشفة الوثائق"),
            ("Internal Communications Improvement", "تحسين الاتصالات الداخلية"),
            ("Remote Work Infrastructure Rollout", "نشر بنية العمل عن بعد"),
            ("Vendor Contract Renegotiation", "إعادة التفاوض على عقود الموردين"),
            ("Customer Feedback Portal Launch", "إطلاق بوابة آراء العملاء"),
            ("Warehouse Inventory Digitization", "رقمنة مخزون المستودعات"),
            ("Employee Wellness Program", "برنامج صحة الموظفين"),
            ("Data Backup Resilience Project", "مشروع مرونة النسخ الاحتياطي للبيانات"),
            ("Supplier Quality Audit Initiative", "مبادرة تدقيق جودة الموردين"),
            ("Mobile App Accessibility Overhaul", "تطوير إمكانية الوصول لتطبيق الجوال"),
            ("Legal Compliance Review 2026", "مراجعة الامتثال القانوني 2026"),
            ("Cross-Department Reporting Hub", "مركز التقارير المشترك بين الإدارات"),
            ("Green Fleet Transition Plan", "خطة التحول لأسطول صديق للبيئة"),
            ("Talent Acquisition Pipeline Redesign", "إعادة تصميم مسار استقطاب المواهب"),
            ("Network Security Hardening", "تعزيز أمن الشبكة"),
            ("Public Records Digital Archive", "الأرشيف الرقمي للسجلات العامة"),
            ("Customer Support Response Time Initiative", "مبادرة تحسين زمن استجابة الدعم"),
            ("Facilities Preventive Maintenance Plan", "خطة الصيانة الوقائية للمرافق"),
            ("Budget Forecasting Model Upgrade", "تحديث نموذج التنبؤ بالميزانية"),
            ("Employee Recognition Program Relaunch", "إعادة إطلاق برنامج تكريم الموظفين"),
            ("Cloud Migration Phase Two", "المرحلة الثانية من الانتقال إلى السحابة"),
            ("Regulatory Training Compliance Drive", "حملة الامتثال للتدريب التنظيمي"),
            ("Interdepartmental Workflow Automation", "أتمتة سير العمل بين الإدارات"),
            ("Strategic Partnership Development", "تطوير الشراكات الاستراتيجية"),
            ("Field Operations Mobile Toolkit", "حقيبة أدوات العمليات الميدانية"),
            ("Annual Risk Assessment Update", "تحديث تقييم المخاطر السنوي"),
            ("Knowledge Base Consolidation", "توحيد قاعدة المعرفة"),
            ("Procurement Vendor Diversity Program", "برنامج تنوع موردي المشتريات"),
            ("IT Helpdesk Response Optimization", "تحسين استجابة الدعم الفني"),
            ("Sustainability Reporting Framework", "إطار تقارير الاستدامة"),
            ("Succession Planning Rollout", "نشر خطة تعاقب القيادات"),
            ("Archive Digitization Phase Three", "المرحلة الثالثة من رقمنة الأرشيف"),
            ("Enterprise Risk Dashboard Build", "بناء لوحة مخاطر المؤسسة"),
        };

        [UnitOfWork]
        public async Task SeedAsync()
        {
            var unitIds = await _organizationUnitDummyDataSeeder.SeedAsync();
            var unitIdSet = unitIds.ToHashSet();

            var existing = (await _mubaadaraRepository.GetListAsync())
                .Where(m => m.TenantId == _currentTenant.Id)
                .ToList();

            if (existing.Any())
            {
                // Re-link records whose UnitId is missing or doesn't belong to this tenant's own units
                // (e.g. records seeded before organization units existed, or linked to the wrong tenant).
                var i = 0;
                foreach (var mubaadara in existing.Where(m => m.UnitId == null || !unitIdSet.Contains(m.UnitId.Value)))
                {
                    mubaadara.UnitId = unitIds.Count > 0 ? unitIds[i % unitIds.Count] : null;
                    await _mubaadaraRepository.UpdateAsync(mubaadara);
                    i++;
                }

                // Backfill Category for records seeded before that column existed - the migration
                // default (MainTarget) would otherwise leave every existing record on the same
                // value. Deterministic by index, so re-running this is a no-op.
                for (var j = 0; j < existing.Count; j++)
                {
                    existing[j].Category = Categories[j % Categories.Length];
                    await _mubaadaraRepository.UpdateAsync(existing[j]);
                }
            }

            var admin = await _identityUserRepository.FindByNormalizedUserNameAsync("ADMIN");
            var managerId = admin?.Id;

            var random = new Random();
            var currentYear = DateTime.Now.Year;

            // Insert only the titles not already seeded for this tenant, so growing the
            // Titles list and re-running is additive instead of duplicating everything.
            var existingTitles = existing.Select(m => m.Title).ToHashSet();
            var startIndex = existing.Count;

            for (var i = 0; i < Titles.Length; i++)
            {
                var (titleEn, titleAr) = Titles[i];
                if (existingTitles.Contains(titleEn)) continue;

                var seedIndex = startIndex + i;
                var startDate = new DateTime(currentYear, random.Next(1, 13), 1);

                await _mubaadaraRepository.InsertAsync(new Mubaadara
                {
                    Title = titleEn,
                    Description = titleAr,
                    TypeId = TypeIds[seedIndex % TypeIds.Length],
                    Category = Categories[seedIndex % Categories.Length],
                    StatusId = StatusIds[seedIndex % StatusIds.Length],
                    Year = currentYear,
                    Month = (Months)(startDate.Month - 1),
                    UnitId = unitIds.Count > 0 ? unitIds[seedIndex % unitIds.Count] : null,
                    ManagerId = managerId,
                    CompletionPercentage = random.Next(0, 100),
                    Amount = random.Next(1000, 50000),
                    StartDate = startDate,
                    EndDate = startDate.AddMonths(random.Next(2, 6)),
                    IsApproved = ApprovalStatuses[seedIndex % ApprovalStatuses.Length],
                }, true);
            }
        }
    }
}
