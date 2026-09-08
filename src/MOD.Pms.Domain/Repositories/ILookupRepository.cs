using MOD.Pms.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MOD.Pms.Repositories
{
    public interface ILookupRepository: IRepository<Lookup, Guid>
    {
        Task<IQueryable<Lookup>> GetLookupHierarchyQueryableAsync(Guid id);

    }
}
