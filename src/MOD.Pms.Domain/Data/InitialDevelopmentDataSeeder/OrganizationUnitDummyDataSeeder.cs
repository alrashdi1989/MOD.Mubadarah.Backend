using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace MOD.Pms.Data.InitialDevelopmentDataSeeder
{
    public interface IOrganizationUnitDummyDataSeeder
    {
        Task<List<Guid>> SeedAsync();
    }

    public class OrganizationUnitDummyDataSeeder : ITransientDependency, IOrganizationUnitDummyDataSeeder
    {
        private readonly IOrganizationUnitRepository _organizationUnitRepository;
        private readonly OrganizationUnitManager _organizationUnitManager;
        private readonly ICurrentTenant _currentTenant;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public OrganizationUnitDummyDataSeeder(
            IOrganizationUnitRepository organizationUnitRepository,
            OrganizationUnitManager organizationUnitManager,
            ICurrentTenant currentTenant,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _organizationUnitRepository = organizationUnitRepository;
            _organizationUnitManager = organizationUnitManager;
            _currentTenant = currentTenant;
            _unitOfWorkManager = unitOfWorkManager;
        }

        private static readonly (string En, string Ar)[] ParentUnitNames =
        {
            ("Administration Directorate", "مديرية الإدارة"),
            ("Engineering Directorate", "مديرية الهندسة"),
            ("Finance Directorate", "مديرية المالية"),
            ("Human Resources Directorate", "مديرية الموارد البشرية"),
            ("Operations Directorate", "مديرية العمليات"),
        };

        // Child sections per parent directorate, in the same order as ParentUnitNames.
        // 22 sections were added on top of the original 10 to give the dashboard's
        // By-Unit breakdown more variety to test against.
        private static readonly (string En, string Ar)[][] ChildUnitNames =
        {
            new[]
            {
                ("Administrative Affairs Section", "قسم الشؤون الإدارية"),
                ("Documentation Section", "قسم التوثيق"),
                ("Public Relations Section", "قسم العلاقات العامة"),
                ("Legal Affairs Section", "قسم الشؤون القانونية"),
                ("Archiving Section", "قسم الأرشفة"),
                ("Correspondence Section", "قسم المراسلات"),
                ("Quality Assurance Section", "قسم ضمان الجودة"),
            },
            new[]
            {
                ("Design Section", "قسم التصميم"),
                ("Maintenance Section", "قسم الصيانة"),
                ("Civil Works Section", "قسم الأعمال المدنية"),
                ("Electrical Section", "قسم الكهرباء"),
                ("Mechanical Section", "قسم الميكانيكا"),
                ("Project Planning Section", "قسم تخطيط المشاريع"),
                ("Surveying Section", "قسم المساحة"),
            },
            new[]
            {
                ("Budget Section", "قسم الميزانية"),
                ("Accounts Section", "قسم الحسابات"),
                ("Procurement Section", "قسم المشتريات"),
                ("Auditing Section", "قسم التدقيق"),
                ("Payroll Section", "قسم الرواتب"),
                ("Treasury Section", "قسم الخزينة"),
            },
            new[]
            {
                ("Recruitment Section", "قسم التوظيف"),
                ("Employee Relations Section", "قسم علاقات الموظفين"),
                ("Training Section", "قسم التدريب"),
                ("Performance Management Section", "قسم إدارة الأداء"),
                ("Compensation Section", "قسم التعويضات"),
                ("Wellness Section", "قسم الرفاهية"),
            },
            new[]
            {
                ("Logistics Section", "قسم اللوجستيات"),
                ("Field Operations Section", "قسم العمليات الميدانية"),
                ("Fleet Management Section", "قسم إدارة الأسطول"),
                ("Warehouse Section", "قسم المستودعات"),
                ("Safety Section", "قسم السلامة"),
                ("Support Services Section", "قسم خدمات الدعم"),
            },
        };

        [UnitOfWork]
        public async Task<List<Guid>> SeedAsync()
        {
            var tenantId = _currentTenant.Id;

            var parentNames = ParentUnitNames.Select(x => x.En).ToHashSet();
            var childNames = ChildUnitNames.SelectMany(x => x).Select(x => x.En).ToHashSet();
            var allNames = parentNames.Concat(childNames).ToHashSet();

            // One-time cleanup: an earlier version of this seeder inserted every dummy unit
            // with TenantId = NULL regardless of the tenant being seeded, producing many
            // duplicate sets all scoped to the host. Keep only one set per name for the
            // current tenant and remove the rest so each tenant ends up with its own.
            var scoped = (await _organizationUnitRepository.GetListAsync())
                .Where(x => x.TenantId == tenantId && allNames.Contains(x.DisplayName))
                .ToList();
            var duplicates = scoped
                .GroupBy(x => x.DisplayName)
                .SelectMany(g => g.OrderBy(x => x.CreationTime).Skip(1));
            foreach (var unit in duplicates)
            {
                await _organizationUnitRepository.DeleteAsync(unit);
            }

            var existingByName = scoped
                .GroupBy(x => x.DisplayName)
                .Select(g => g.OrderBy(x => x.CreationTime).First())
                .ToDictionary(x => x.DisplayName);

            // Self-heal an earlier bug: the parent units below used to be created in a loop
            // within a single UnitOfWork without flushing between inserts, so
            // OrganizationUnitManager's sibling-Code lookup couldn't see the ones just
            // created and gave every parent the same Code ("00001"). That breaks any
            // Code-prefix ("descendant") lookup, since every parent's children then also
            // share the same prefix. Detect that signature and wipe this tenant's set so
            // the loop below recreates it with correct, distinct sibling codes.
            var parentCodes = existingByName
                .Where(x => parentNames.Contains(x.Key))
                .Select(x => x.Value.Code)
                .ToList();
            if (parentCodes.Count > 1 && parentCodes.Distinct().Count() != parentCodes.Count)
            {
                foreach (var unit in existingByName.Values)
                {
                    await _organizationUnitRepository.DeleteAsync(unit);
                }
                await _unitOfWorkManager.Current.SaveChangesAsync();
                existingByName.Clear();
            }

            var expectedCount = ParentUnitNames.Length + ChildUnitNames.Sum(c => c.Length);
            if (existingByName.Count == expectedCount)
            {
                return existingByName
                    .Where(x => childNames.Contains(x.Key))
                    .Select(x => x.Value.Id)
                    .ToList();
            }

            var leafIds = new List<Guid>();
            for (var p = 0; p < ParentUnitNames.Length; p++)
            {
                var (parentNameEn, parentNameAr) = ParentUnitNames[p];

                if (!existingByName.TryGetValue(parentNameEn, out var parentUnit))
                {
                    parentUnit = new OrganizationUnit(Guid.NewGuid(), parentNameEn, tenantId: tenantId);
                    parentUnit.SetProperty("EnglishName", parentNameEn);
                    parentUnit.SetProperty("ArabicName", parentNameAr);
                    await _organizationUnitManager.CreateAsync(parentUnit);
                    // Flush immediately: OrganizationUnitManager computes each unit's sibling
                    // Code by querying the database, so without this every parent created in
                    // this same loop would see no siblings yet and all get assigned "00001".
                    await _unitOfWorkManager.Current.SaveChangesAsync();
                    existingByName[parentNameEn] = parentUnit;
                }

                foreach (var (childNameEn, childNameAr) in ChildUnitNames[p])
                {
                    if (!existingByName.TryGetValue(childNameEn, out var childUnit))
                    {
                        childUnit = new OrganizationUnit(Guid.NewGuid(), childNameEn, parentId: parentUnit.Id, tenantId: tenantId);
                        childUnit.SetProperty("EnglishName", childNameEn);
                        childUnit.SetProperty("ArabicName", childNameAr);
                        await _organizationUnitManager.CreateAsync(childUnit);
                        await _unitOfWorkManager.Current.SaveChangesAsync();
                        existingByName[childNameEn] = childUnit;
                    }
                    leafIds.Add(childUnit.Id);
                }
            }

            return leafIds;
        }
    }
}
