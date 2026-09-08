using Microsoft.Extensions.DependencyInjection;
using MOD.Pms.HttpApi.ExternalApiClients.Jund;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace MOD.Pms.HttpApi.ExternalApiClients
{
    [DependsOn(
     typeof(PmsDomainSharedModule),
     typeof(PmsDomainModule))
 ]
    public class PmsHttpApiExternalClientsModule: AbpModule
    {

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddRefitClient<IJundApi>();

        }

    }
}
