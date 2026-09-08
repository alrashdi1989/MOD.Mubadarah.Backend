using MOD.Pms.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MOD.Pms;

[DependsOn(
    typeof(PmsEntityFrameworkCoreTestModule)
    )]
public class PmsDomainTestModule : AbpModule
{

}
