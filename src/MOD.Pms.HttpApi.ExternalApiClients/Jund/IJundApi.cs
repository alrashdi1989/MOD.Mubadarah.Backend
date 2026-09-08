using MOD.Pms.ExternalApiEntites;
using MOD.Pms.ExternalApiEntites.Jund;

using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace MOD.Pms.HttpApi.ExternalApiClients.Jund
{
    public interface IJundApi
    {
        [Get("/person-by-military-service-id/{serviceMilitaryId}")]
        Task<Employee> GetEmployeeAsync(string serviceMilitaryId);

        [Get("/person-photo-by-military-service-id/{serviceMilitaryId}")]
        Task<byte[]> GetEmployeePhotoAsync(string serviceMilitaryId);

        [Get("/units-by-level-and-tenant/94ffcc2e-7587-419b-e948-39f8ede01390?level=3")]
        Task<ExtendedPagedListResultDto<UnitTreeByLevelDto>> GetModUnitsAsync();  
}

}
