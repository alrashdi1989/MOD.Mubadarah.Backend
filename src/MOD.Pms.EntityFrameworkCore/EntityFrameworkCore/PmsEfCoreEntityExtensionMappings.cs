using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;
using Volo.Saas.Tenants;

namespace MOD.Pms.EntityFrameworkCore;

public static class PmsEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        PmsGlobalFeatureConfigurator.Configure();
        PmsModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
            /* You can configure extra properties for the
             * entities defined in the modules used by your application.
             *
             * This class can be used to map these extra properties to table fields in the database.
             *
             * USE THIS CLASS ONLY TO CONFIGURE EF CORE RELATED MAPPING.
             * USE PmsModuleExtensionConfigurator CLASS (in the Domain.Shared project)
             * FOR A HIGH LEVEL API TO DEFINE EXTRA PROPERTIES TO ENTITIES OF THE USED MODULES
             *
             * Example: Map a property to a table field:

                 ObjectExtensionManager.Instance
                     .MapEfCoreProperty<IdentityUser, string>(
                         "MyProperty",
                         (entityBuilder, propertyBuilder) =>
                         {
                             propertyBuilder.HasMaxLength(128);
                         }
                     );

             * See the documentation for more:
             * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
             */

            #region Extra Properties for Orgnization Unit

            ObjectExtensionManager.Instance.MapEfCoreProperty<OrganizationUnit, string>("ArabicName",
                (builder, propertyBuilder) =>
                {
                    propertyBuilder.IsRequired();
                    propertyBuilder.HasMaxLength(250);
                });
            ObjectExtensionManager.Instance.MapEfCoreProperty<OrganizationUnit, string>("EnglishName",
                (builder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(250);
                });






            #endregion Extra Properties for Orgnization Unit

            #region Tenant

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, string>("EnglishName",
                (builder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(100);
                });

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, string>("ArabicName",
                (builder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(100);
                });

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, int>("Order",
                (builder, propertyBuilder) =>
                {
                });




            #endregion Tenant

            #region Identity User

            ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, string>("ServiceNumber",
            (builder, propertyBuilder) =>
            {

                propertyBuilder.HasMaxLength(250);
            });
            ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, int>("RankOrder",
          (builder, propertyBuilder) => { });
            ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, string>("RankEnglish",
               (builder, propertyBuilder) =>
               {

                   propertyBuilder.HasMaxLength(250);
               });
            ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, string>("RankArabic",
               (builder, propertyBuilder) =>
               {

                   propertyBuilder.HasMaxLength(250);
               });

            ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, string>("ArabicName",
             (builder, propertyBuilder) =>
             {
                 propertyBuilder.HasMaxLength(250);
             });

            ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, string>("EnglishName",
                (builder, propertyBuilder) =>
                {

                    propertyBuilder.HasMaxLength(250);
                });

            ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, string>("MainUnitArabic",
             (builder, propertyBuilder) =>
             {
                 propertyBuilder.HasMaxLength(250);
             });

            ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, string>("MainUnitEnglish",
                (builder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(250);
                });

            ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, Guid?>("PositionUnitId");

            ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, string>("PositionEnglish",
                (builder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(250);
                });

            ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, string>("PositionArabic",
                (builder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(250);
                });

            ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, bool>("IsAcceptPolicy",
                (builder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(250);
                });

            #endregion
        });
    }
}
