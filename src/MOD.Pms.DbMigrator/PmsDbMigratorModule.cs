using Microsoft.Extensions.DependencyInjection;
using MOD.Pms.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MOD.Pms.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PmsEntityFrameworkCoreModule),
    typeof(PmsApplicationContractsModule)
)]
public class PmsDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = false;
        });

    }
}
