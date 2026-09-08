using Microsoft.Extensions.Configuration;
using MOD.Pms.ExternalApiEntites;
using MOD.Pms.ExternalApiEntites.Jund;
using Refit;
using System.Data;
using Volo.Abp.Data;
using Volo.Abp.Identity;

namespace MOD.Pms.HttpApi.ExternalApiClients.Jund
{
    public class JundClient : IJundClient
    {
        private IJundApi _jundApi;
        private readonly OrganizationUnitManager _organizationUnitManager;


        public JundClient(
           JundAuthHeaderHandler authHeaderHandler,
           IConfiguration configuration,
           OrganizationUnitManager organizationUnitManager
           )
        {
            var baseUrl = configuration["ExternalApis:Jund:BaseUrl"];
            _organizationUnitManager = organizationUnitManager;
            _jundApi = RestService.For<IJundApi>(new HttpClient(authHeaderHandler) {  BaseAddress = new Uri(baseUrl!), });
        }

        public async Task<Employee> GetEmployeeAsync(string serviceMilitaryId)
        {

            Employee employee = await _jundApi.GetEmployeeAsync(serviceMilitaryId);

            var photo = await _jundApi.GetEmployeePhotoAsync(serviceMilitaryId);
            if (photo.Length > 0) employee.Photo = photo;
            return employee;
        }

        public async Task GetModUnitsAsync()
        {
            ExtendedPagedListResultDto<UnitTreeByLevelDto> organizationUnit = await _jundApi.GetModUnitsAsync();
            List<UnitTreeByLevelDto> organizationUnits = new List<UnitTreeByLevelDto>();

            organizationUnits.AddRange(organizationUnit.Items.Select(c => new UnitTreeByLevelDto()
            {
                Id = c.Id,
                TenantId = c.TenantId,
                ParentId = c.ParentId,
                Code = c.Code,
                ArabicUnitName = c.ArabicUnitName,
                EnglishUnitName = c.EnglishUnitName,
                DisplayName = c.ArabicUnitName,
                Level = c.Level,
            }
            ));
            foreach (var item in organizationUnits)
            {
                OrganizationUnit organizationUnitDto = new OrganizationUnit(item.Id, item.DisplayName, item.ParentId, item.TenantId);
                // String ParentCode = OrganizationUnit.GetParentCode(item.Code);
                //organizationUnitDto.Code = OrganizationUnit.GetRelativeCode(item.Code, ParentCode);
                organizationUnitDto.SetProperty("ArabicName", item.ArabicUnitName);
                organizationUnitDto.SetProperty("EnglishName", item.EnglishUnitName);
                if (item.Level == 3)
                {
                    await _organizationUnitManager.CreateAsync(organizationUnitDto);
                }
            }
        }
    }
}

