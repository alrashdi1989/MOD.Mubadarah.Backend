using MOD.Pms.CommonDte;
using MOD.Pms.Mubaadaras;
using MOD.Pms.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using Volo.Saas.Tenants;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace MOD.Pms.EntityFrameworkCore.Repositories
{
    public class MubaadaraRepository : EfCoreRepository<PmsDbContext, Mubaadara, Guid>, IMubaadaraRepository
    {
        private readonly IDataFilter _dataFilter;

        public MubaadaraRepository(
            IDbContextProvider<PmsDbContext> dbContextProvider,
            IDataFilter dataFilter) : base(dbContextProvider)
        {
            _dataFilter = dataFilter;
         }

        public async Task<IQueryable<MubaadaraApprovelDte>> GetMubaadaraQueryableAsync()
        {
            var dbContext = await GetDbContextAsync();

            var result = from mubaadara in dbContext.Mubaadaras
                         select new MubaadaraApprovelDte()
                         {
                             Amount = mubaadara.Amount,
                             CompletionPercentage = mubaadara.CompletionPercentage,
                             Id = mubaadara.Id,
                             ManagerId = mubaadara.ManagerId,
                             HeadManagerId = mubaadara.HeadManagerId,
                             StatusId = mubaadara.StatusId,
                             Title = mubaadara.Title,
                             Description = mubaadara.Description,
                             TypeId = mubaadara.TypeId,
                             UnitId = mubaadara.UnitId,
                             IsApproved = mubaadara.IsApproved,
                             StartDate = mubaadara.StartDate,
                             EndDate = mubaadara.EndDate,
                             ActualEndDate = mubaadara.ActualEndDate,
                             UnitHierarchyAr = mubaadara.UnitId.HasValue ? PmsDbContext.GetUnitHierarchyPathAr(mubaadara.UnitId.Value) : ""
                         };
            return result;
        }

        public async Task<IQueryable<OrganizationUnitsMubaadaraNumberDto>> GetOrganizationUnitsMubaadaraNumber(int targetYear)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                DateTime? startDate = new DateTime(targetYear, 1, 1);
                DateTime? endDate = new DateTime(targetYear, 12, 31);
                var dbContext = await GetDbContextAsync();
                var organizationUnits = dbContext.OrganizationUnits;

                var mubaadaras = dbContext.Mubaadaras;

                var query = from mubaadara in mubaadaras
                            join organizationUnit in organizationUnits on mubaadara.UnitId equals organizationUnit.Id
                            where mubaadara.StartDate >= startDate && mubaadara.EndDate <= endDate
                            select new { id = organizationUnit.Id, code = organizationUnit.Code, arabicOrganizationUnitName = organizationUnit.GetProperty("ArabicName", organizationUnit.DisplayName)};
                var organizationUnitsMubaadaraNumberDto = from data in query
                                                          group data by data.id into g

                                                          select new OrganizationUnitsMubaadaraNumberDto
                                                          {
                                                              Id = g.First().id,
                                                              ArabicName = g.First().arabicOrganizationUnitName,
                                                              Code = g.First().code,
                                                              Count = g.Count(),
                                                          };
                return organizationUnitsMubaadaraNumberDto;
            }
        }
        public async Task<IQueryable<GroupDte>> GetMubaadarsOrganizationUnitCountByTypeQueryableAsync(Guid organizationUnitId, int targetYear)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                DateTime? startDate = new DateTime(targetYear, 1, 1);
                DateTime? endDate = new DateTime(targetYear, 12, 31);
                var dbContext = await GetDbContextAsync();
                var organizationUnits = dbContext.OrganizationUnits;
                var mubaadaras = dbContext.Mubaadaras.AsQueryable().Where(c => c.UnitId == organizationUnitId);

                IQueryable<GroupDte> data = from mubaadara in mubaadaras
                            join mubaadaraType in dbContext.Lookups on mubaadara.TypeId equals mubaadaraType.Id
                                            where mubaadara.StartDate >= startDate && mubaadara.EndDate <= endDate
                                            select new
                            {
                                id = mubaadaraType.Id,
                                ar = mubaadaraType.ArabicName
                            }
                            into j
                            group j by j.id.ToString() into g
                            select new GroupDte
                                                          {
                                                              Key = g.Key,
                                                              Size = g.Count(),
                                                              Name = g.FirstOrDefault().ar
                                                          };
                return data;
            }
        }

        public async Task<IQueryable<GroupDte>> GetMubaadarsOrganizationUnitCountByStatusQueryableAsync(Guid organizationUnitId, int targetYear)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {

                var dbContext = await GetDbContextAsync();
                DateTime? startDate = new DateTime(targetYear, 1, 1);
                DateTime? endDate = new DateTime(targetYear, 12, 31);
                var lookupId = new Guid("20226EE9-894D-4C08-9E5C-1F9F78F682C3");
                var statusTypelookup = dbContext.Lookups.Where(c => c.LookupId == lookupId);
                var organizationUnits = dbContext.OrganizationUnits;
                var mubaadaras = dbContext.Mubaadaras.AsQueryable().Where(c => c.UnitId == organizationUnitId && c.StartDate >= startDate && c.EndDate <= endDate);
                IQueryable<GroupDte> data = (from  s in statusTypelookup
                                             join m in mubaadaras on s.Id equals m.StatusId into g
                               
                                            select new GroupDte
                                            {
                                                Key = s.ArabicName,
                                                Size = g.Count(),
                                                Name =  s.ArabicName,
                                            });
                return data;
            }
        }

        public async Task<IQueryable<GroupDte>> GetMubaadarsCountByTypeQueryableAsync(int targetYear)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                DateTime? startDate = new DateTime(targetYear, 1, 1);
                DateTime? endDate = new DateTime(targetYear, 12, 31);
                var dbContext = await GetDbContextAsync();
                var organizationUnits = dbContext.OrganizationUnits;
                var mubaadaras = dbContext.Mubaadaras.AsQueryable().Where(c => c.IsDeleted == false);

                IQueryable<GroupDte> data = from mubaadara in mubaadaras
                                            join mubaadaraType in dbContext.Lookups on mubaadara.TypeId equals mubaadaraType.Id
                                            where mubaadara.StartDate >= startDate && mubaadara.EndDate <= endDate
                                            select new
                                            {
                                                id = mubaadaraType.Id,
                                                ar = mubaadaraType.ArabicName
                                            }
                            into j
                                            group j by j.id.ToString() into g
                                            select new GroupDte
                                            {
                                                Key = g.Key,
                                                Size = g.Count(),
                                                Name = g.FirstOrDefault().ar
                                            };
                return data;
            }
        }

        public async Task<decimal> GetMubaadarsOrganizationUnitAverageCompletionPercentageByUnitIdAsync(Guid organizationUnitId, int targetYear)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                DateTime? startDate = new DateTime(targetYear, 1, 1);
                DateTime? endDate = new DateTime(targetYear, 12, 31);
                var dbContext = await GetDbContextAsync();
                var organizationUnits = dbContext.OrganizationUnits;
                var mubaadaras = dbContext.Mubaadaras.AsQueryable().Where(c => c.UnitId == organizationUnitId && c.StartDate >= startDate && c.EndDate <= endDate);

                decimal totalCompletionPercentage = mubaadaras.Sum(c => c.CompletionPercentage);
                decimal mubaadarasTotal = mubaadaras.Count();
                var averageCompletionPercentage = totalCompletionPercentage / mubaadarasTotal;
                return averageCompletionPercentage;
            }
        }

        public async Task<decimal> GetMubaadarsOrganizationUnitTotalAmountByUnitIdAsync(Guid organizationUnitId, int targetYear)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                DateTime? startDate = new DateTime(targetYear, 1, 1);
                DateTime? endDate = new DateTime(targetYear, 12, 31);
                var dbContext = await GetDbContextAsync();
                var organizationUnits = dbContext.OrganizationUnits;
                var mubaadaras = dbContext.Mubaadaras.AsQueryable().Where(c => c.UnitId == organizationUnitId && c.StartDate >= startDate && c.EndDate <= endDate);
                decimal totalAmount = mubaadaras.Sum(c => c.Amount);
                return totalAmount;
            }
        }


    }
}
