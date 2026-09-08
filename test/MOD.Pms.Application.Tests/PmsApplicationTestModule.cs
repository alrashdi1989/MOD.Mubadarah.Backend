using Volo.Abp.Modularity;

namespace MOD.Pms;

[DependsOn(
    typeof(PmsApplicationModule),
    typeof(PmsDomainTestModule)
    )]
public class PmsApplicationTestModule : AbpModule
{

}
