using MOD.Pms.CommonDte;
using MOD.Pms.Enums;
using MOD.Pms.Mubaadaras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MOD.Pms.Repositories
{
    public interface IMubaadaraRepository : IRepository<Mubaadara, Guid>
    {
        Task<IQueryable<MubaadaraApprovelDte>> GetMubaadaraQueryableAsync();
        Task<IQueryable<OrganizationUnitsMubaadaraNumberDto>> GetOrganizationUnitsMubaadaraNumber(int targetYear);
        Task<IQueryable<OrganizationUnitsMubaadaraNumberDto>> GetOrganizationUnitsMubaadaraNumberByDateRange(DateTime fromDate, DateTime toDate);
        Task<IQueryable<GroupDte>> GetMubaadarsOrganizationUnitCountByTypeQueryableAsync(Guid organizationUnitId, int targetYear);
        Task<IQueryable<GroupDte>> GetMubaadarsOrganizationUnitCountByStatusQueryableAsync(Guid organizationUnitId, int targetYear);
        Task<IQueryable<GroupDte>> GetMubaadarsCountByTypeQueryableAsync(int targetYear);
        Task<decimal> GetMubaadarsOrganizationUnitAverageCompletionPercentageByUnitIdAsync(Guid organizationUnitId, int targetYear);
        Task<decimal> GetMubaadarsOrganizationUnitAverageCompletionPercentageByUnitIdAndDateRangeAsync(Guid organizationUnitId, DateTime fromDate, DateTime toDate);
        Task<decimal> GetMubaadarsOrganizationUnitTotalAmountByUnitIdAsync(Guid organizationUnitId, int targetYear);
    }
}
