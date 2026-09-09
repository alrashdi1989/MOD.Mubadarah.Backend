using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MOD.Pms;

[Dependency(ReplaceServices = true)]
public class PmsBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Mubadara";
}
