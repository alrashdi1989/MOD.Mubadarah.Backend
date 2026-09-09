using MOD.Pms.Data.InitialDevelopmentDataSeeder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace MOD.Pms.Data
{
    public class PmsDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ILookupDataSeeder _lookupDataSeeder;
        private readonly IMubaadaraDummyDataSeeder _mubaadaraDummyDataSeeder;
        private readonly IMubaadaraChildDataSeeder _mubaadaraChildDataSeeder;


        public PmsDataSeederContributor(
            ILookupDataSeeder lookupDataSeeder,
            IMubaadaraDummyDataSeeder mubaadaraDummyDataSeeder,
            IMubaadaraChildDataSeeder mubaadaraChildDataSeeder)
        {
            _lookupDataSeeder = lookupDataSeeder;
            _mubaadaraDummyDataSeeder = mubaadaraDummyDataSeeder;
            _mubaadaraChildDataSeeder = mubaadaraChildDataSeeder;
         }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _lookupDataSeeder.SeedAsync();
            await _mubaadaraDummyDataSeeder.SeedAsync();
            await _mubaadaraChildDataSeeder.SeedAsync();
        }
    }
}
