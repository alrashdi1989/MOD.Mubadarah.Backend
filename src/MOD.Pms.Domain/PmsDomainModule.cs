using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MOD.Pms.Localization;
using MOD.Pms.MultiTenancy;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Saas;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.Caching;
using Volo.Abp.Commercial.SuiteTemplates;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement.OpenIddict;
using MOD.Pms.Documents.Container;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp;
using Volo.Abp.VirtualFileSystem;
using System.Diagnostics;
using System;
using MOD.Pms.Emailing;
using Volo.Abp.Auditing;

namespace MOD.Pms;

[DependsOn(
    typeof(PmsDomainSharedModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpCachingModule),
    typeof(AbpBackgroundJobsDomainModule),
    typeof(AbpFeatureManagementDomainModule),
    typeof(AbpIdentityProDomainModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpOpenIddictProDomainModule),
    typeof(AbpPermissionManagementDomainOpenIddictModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(SaasDomainModule),
    typeof(TextTemplateManagementDomainModule),
    typeof(LanguageManagementDomainModule),
    typeof(VoloAbpCommercialSuiteTemplatesModule),
    typeof(AbpEmailingModule),
    typeof(AbpGdprDomainModule),
    typeof(BlobStoringDatabaseDomainModule),
    typeof(AbpBlobStoringFileSystemModule),
    typeof(AbpBackgroundJobsModule)
    )]
public class PmsDomainModule : AbpModule
{
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var settingManager = context.ServiceProvider.GetService<SettingManager>();
        //encrypts the password on set and decrypts on get
        settingManager.SetGlobalAsync("Abp.Mailing.Smtp.Password", "P@ssw0rd");

    }
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

        Configure<AbpAuditingOptions>(options =>
        {
            //options.EntityHistorySelectors.Add("ProjectAudit", typeof(Project));
            //options.EntityHistorySelectors.Add("AgentAudit", typeof(Agent));

            //options.EntityHistorySelectors.AddAllEntities();
        });

        Configure<AbpBlobStoringOptions>(options =>
        {
            options.Containers.ConfigureDefault(container =>
            {
                container.IsMultiTenant = false;
                container.UseFileSystem(fileSystem =>
                {
                    fileSystem.BasePath = context.Services.GetConfiguration().GetSection("Settings").GetSection("Pms.Files.Path").Value;
                    fileSystem.AppendContainerNameToBasePath = true;
                });
            });
            //options.Containers.Configure<AccountProfilePictureContainer>(container =>
            //{
            //    container.IsMultiTenant = false;
            //    container.UseFileSystem(fileSystem =>
            //    {
            //        fileSystem.BasePath = context.Services.GetConfiguration().GetSection("Settings").GetSection("Pms.Files.Path").Value;

            //        fileSystem.AppendContainerNameToBasePath = true;
            //    });
            //});
            //options.Containers.Configure<ProjectContainer>(container =>
            //{
            //    container.IsMultiTenant = false;
            //    container.UseFileSystem(fileSystem =>
            //    {
            //        fileSystem.BasePath = context.Services.GetConfiguration().GetSection("Settings").GetSection("Pms.Files.Path").Value;
            //        fileSystem.AppendContainerNameToBasePath = true;
            //    });
            //});
        });
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية", "ae"));
            options.Languages.Add(new LanguageInfo("en", "en", "English", "gb"));
        
        });

//        Configure<AbpBackgroundJobWorkerOptions>(options =>
//{
//    options.DefaultTimeout = 0;
//});
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PmsDomainModule>("MOD.Pms");
        });
        Configure<AbpBackgroundJobWorkerOptions>(options =>
      {
          options.DefaultTimeout = 0;
      });

 
    }
}
