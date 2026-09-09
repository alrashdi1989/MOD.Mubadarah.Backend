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

        public OrganizationUnitDummyDataSeeder(
            IOrganizationUnitRepository organizationUnitRepository,
            OrganizationUnitManager organizationUnitManager,
            ICurrentTenant currentTenant)
        {
            _organizationUnitRepository = organizationUnitRepository;
            _organizationUnitManager = organizationUnitManager;
            _currentTenant = currentTenant;
        }

        private static readonly (string En, string Ar)[] UnitNames =
        {
            ("Administration Directorate", "مديرية الإدارة"),
            ("Engineering Directorate", "مديرية الهندسة"),
            ("Finance Directorate", "مديرية المالية"),
            ("Human Resources Directorate", "مديرية الموارد البشرية"),
            ("Operations Directorate", "مديرية العمليات"),
        };

        [UnitOfWork]
        public async Task<List<Guid>> SeedAsync()
        {
            var tenantId = _currentTenant.Id;

            // One-time cleanup: an earlier version of this seeder inserted every dummy unit
            // with TenantId = NULL regardless of the tenant being seeded, producing many
            // duplicate sets all scoped to the host. Keep only one set per name for the
            // current tenant and remove the rest so each tenant ends up with its own.
            var dummyNames = UnitNames.Select(x => x.En).ToHashSet();
            var scoped = (await _organizationUnitRepository.GetListAsync())
                .Where(x => x.TenantId == tenantId && dummyNames.Contains(x.DisplayName))
                .ToList();
            var duplicates = scoped
                .GroupBy(x => x.DisplayName)
                .SelectMany(g => g.OrderBy(x => x.CreationTime).Skip(1));
            foreach (var unit in duplicates)
            {
                await _organizationUnitRepository.DeleteAsync(unit);
            }

            var existing = scoped
                .GroupBy(x => x.DisplayName)
                .Select(g => g.OrderBy(x => x.CreationTime).First())
                .ToList();
            if (existing.Count == UnitNames.Length)
            {
                return existing.Select(x => x.Id).ToList();
            }

            var ids = new List<Guid>();
            foreach (var (nameEn, nameAr) in UnitNames)
            {
                var unit = new OrganizationUnit(Guid.NewGuid(), nameEn, tenantId: tenantId);
                unit.SetProperty("EnglishName", nameEn);
                unit.SetProperty("ArabicName", nameAr);
                await _organizationUnitManager.CreateAsync(unit);
                ids.Add(unit.Id);
            }

            return ids;
        }
    }
}
