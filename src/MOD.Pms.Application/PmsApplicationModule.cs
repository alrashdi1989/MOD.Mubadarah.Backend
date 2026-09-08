 using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
 using MOD.Pms.HttpApi.ExternalApiClients;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundWorkers;
 using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Gdpr;
using Volo.Abp.Identity;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Saas.Host;
using MOD.Pms.BackgroundWorker;
using Volo.Abp.Hangfire;
using Volo.Abp.BackgroundWorkers.Hangfire;

namespace MOD.Pms;

[DependsOn(
    typeof(PmsDomainModule),
    typeof(PmsApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(SaasHostApplicationModule),
    typeof(AbpAuditLoggingApplicationModule),
    typeof(AbpOpenIddictProApplicationModule),
    typeof(AbpAccountPublicApplicationModule),
    typeof(AbpAccountAdminApplicationModule),
    typeof(LanguageManagementApplicationModule),
    typeof(AbpGdprApplicationModule),
    typeof(TextTemplateManagementApplicationModule),
    typeof(PmsHttpApiExternalClientsModule),
    typeof(AbpBackgroundWorkersModule),
    typeof(AbpBackgroundWorkersHangfireModule)

    )]
public class PmsApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<PmsApplicationModule>();
        });


#if DEBUG
      // context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {

        context.AddBackgroundWorkerAsync<IUpdateUsersFromJundWorker>();


    }
}
