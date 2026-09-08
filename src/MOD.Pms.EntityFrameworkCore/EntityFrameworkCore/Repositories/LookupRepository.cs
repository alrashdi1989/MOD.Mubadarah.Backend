using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using MOD.Pms.Lookups;
using MOD.Pms.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace MOD.Pms.EntityFrameworkCore.Repositories
{
    public class LookupRepository : EfCoreRepository<PmsDbContext, Lookup, Guid>, ILookupRepository
    {
        public LookupRepository(IDbContextProvider<PmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<IQueryable<Lookup>> GetLookupHierarchyQueryableAsync(Guid id)
        {
            var dbContext = await GetDbContextAsync();
            return dbContext.GetLookupHierarchyAsQueryable(id);
        }
    }
}
