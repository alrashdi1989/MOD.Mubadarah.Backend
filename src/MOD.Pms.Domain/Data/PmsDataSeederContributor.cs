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


        public PmsDataSeederContributor(ILookupDataSeeder lookupDataSeeder, IMubaadaraDummyDataSeeder mubaadaraDummyDataSeeder)
        {
            _lookupDataSeeder = lookupDataSeeder;
            _mubaadaraDummyDataSeeder = mubaadaraDummyDataSeeder;
         }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _lookupDataSeeder.SeedAsync();
            await _mubaadaraDummyDataSeeder.SeedAsync();
        }
    }
}
