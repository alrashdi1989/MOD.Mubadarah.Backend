using System;
using System.Collections.Generic;
using MOD.Pms.Repositories;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOD.Pms.MubaadaraDetails;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using MOD.Pms.Mubaadaras;
using MOD.Pms.MubadaaraDetails;
using MOD.Pms.MubaadaraWorkflows;
using Org.BouncyCastle.Asn1.Cmp;

namespace MOD.Pms.EntityFrameworkCore.Repositories
{
    public class MubaadaraDetailRepository : EfCoreRepository<PmsDbContext, MubaadaraDetail, Guid>, IMubaadaraDetailRepository
    {
        public MubaadaraDetailRepository(IDbContextProvider<PmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        //public async Task<IQueryable<MubaadaraDetailsDte>> GetMubaadaraDetailsQueryableAsync()
        //{
        //    var dbContext = await GetDbContextAsync();

        //    var result = from mubadaaraDetail in dbContext.MubaadaraDetails 
        //                 join mubaadaraWorkflow in dbContext.MubaadaraWorkflow 
        //                 on mubadaaraDetail.Id equals mubaadaraWorkflow.MubaadaraDetailId
        //                 into MubaadaraDetailWorkflow
        //                 from mubaadaraWorkflow in MubaadaraDetailWorkflow.DefaultIfEmpty()
        //                 select new MubaadaraDetailsDte()
        //                 {
        //                     mubadaaraDetailId = mubadaaraDetail.Id,
        //                     mubaadaraWorkflowId = mubaadaraWorkflow.Id,
        //                     MubaadaraId = mubadaaraDetail.MubaadaraId,
        //                     Challenge = mubadaaraDetail.Challenge,
        //                     Note = mubadaaraDetail.Note,
        //                     Solution = mubadaaraDetail.Solution,
        //                     ApproveStatus = mubadaaraDetail.ApproveStatus,
        //                     UserIdTo = mubaadaraWorkflow.UserIdTo,
        //                 };
        //    return result;
        //}
    }
}
