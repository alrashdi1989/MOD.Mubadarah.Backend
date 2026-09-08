using MOD.Pms.MubadaaraDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MOD.Pms.Repositories
{
    public interface IMubaadaraDetailRepository : IRepository<MubaadaraDetails.MubaadaraDetail, Guid>
    {
        //Task<IQueryable<MubaadaraDetailsDte>> GetMubaadaraDetailsQueryableAsync();

    }
}
