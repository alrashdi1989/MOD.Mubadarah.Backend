using MOD.Pms.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MOD.Pms.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PmsController : AbpControllerBase
{
    protected PmsController()
    {
        LocalizationResource = typeof(PmsResource);
    }
}
