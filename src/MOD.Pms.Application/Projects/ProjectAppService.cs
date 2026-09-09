using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Identity;
using Volo.Saas.Host.Dtos;
using Volo.Saas.Tenants;

namespace MOD.Pms.Projects
{
    [Authorize]
    [Route("api/app/project")]
    public class ProjectAppService : PmsAppService
    {
        private readonly IOrganizationUnitRepository _organizationUnitRepository;
        private readonly ITenantRepository _tenantRepository;

        public ProjectAppService(
            IOrganizationUnitRepository organizationUnitRepository,
            ITenantRepository tenantRepository)
        {
            _organizationUnitRepository = organizationUnitRepository;
            _tenantRepository = tenantRepository;
        }

        [HttpGet("organization-unit")]
        public async Task<List<OrganizationUnitDto>> GetListOrganizationUnitAsync()
        {
            var organizationUnits = await _organizationUnitRepository.GetListAsync();
            return ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(organizationUnits);
        }

        [HttpGet("of-tenants")]
        public async Task<List<SaasTenantDto>> GetListOfTenantsAsync(bool isLookup)
        {
            var tenants = await _tenantRepository.GetListAsync();
            return ObjectMapper.Map<List<Volo.Saas.Tenants.Tenant>, List<SaasTenantDto>>(tenants);
        }
    }
}
