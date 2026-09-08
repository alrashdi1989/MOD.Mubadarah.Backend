using System.Globalization;
using AutoMapper;
using MOD.Pms.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;

namespace MOD.Pms;

/* Inherit your application services from this class.
 */
public abstract class PmsAppService : ApplicationService
{
    protected PmsAppService()
    {
        LocalizationResource = typeof(PmsResource);
    }

    protected IConfigurationProvider GetMapperConfigurationProvider()
    {
        return ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
    }
    protected bool IsCurrentLanguageEnglish()
    {
        return CultureInfo.CurrentUICulture.Name == "en";
    }

}
