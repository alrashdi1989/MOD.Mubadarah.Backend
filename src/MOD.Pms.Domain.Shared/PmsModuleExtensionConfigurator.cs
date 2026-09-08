using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Localization;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Threading;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace MOD.Pms;

public static class PmsModuleExtensionConfigurator
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
            ConfigureExistingProperties();
            ConfigureExtraProperties();
        });
    }

    private static void ConfigureExistingProperties()
    {
        /* You can change max lengths for properties of the
         * entities defined in the modules used by your application.
         *
         * Example: Change user and role name max lengths

           IdentityUserConsts.MaxNameLength = 99;
           IdentityRoleConsts.MaxNameLength = 99;

         * Notice: It is not suggested to change property lengths
         * unless you really need it. Go with the standard values wherever possible.
         *
         * If you are using EF Core, you will need to run the add-migration command after your changes.
         */
    }

    private static void ConfigureExtraProperties()
    {
        /* You can configure extra properties for the
         * entities defined in the modules used by your application.
         *
         * This class can be used to define these extra properties
         * with a high level, easy to use API.
         *
         * Example: Add a new property to the user entity of the identity module

           ObjectExtensionManager.Instance.Modules()
              .ConfigureIdentity(identity =>
              {
                  identity.ConfigureUser(user =>
                  {
                      user.AddOrUpdateProperty<string>( //property type: string
                          "SocialSecurityNumber", //property name
                          property =>
                          {
                              //validation rules
                              property.Attributes.Add(new RequiredAttribute());
                              property.Attributes.Add(new StringLengthAttribute(64) {MinimumLength = 4});

                              //...other configurations for this property
                          }
                      );
                  });
              });

         * See the documentation for more:
         * https://docs.abp.io/en/abp/latest/Module-Entity-Extensions
         */

        ObjectExtensionManager.Instance.Modules()
             .ConfigureIdentity(identity =>
             {
                 identity.ConfigureOrganizationUnit(organizationUnit =>
                 {
                     organizationUnit.AddOrUpdateProperty<String>("ArabicName",
                         property =>
                         {
                             property.Attributes.Add(new StringLengthAttribute(250));
                             
                             
                         });
                     organizationUnit.AddOrUpdateProperty<String>("EnglishName",
                            property =>
                        {
                             property.Attributes.Add(new StringLengthAttribute(250));
                        });
                 });



                 identity.ConfigureUser(user =>
                 {

                     user.AddOrUpdateProperty<string>( //property type: string
                     "ServiceNumber", //property name
                     property =>
                     {
                         //validation rules
                         property.Attributes.Add(new StringLengthAttribute(250) { MinimumLength = 4 });
                     }
                     );
                     user.AddOrUpdateProperty<string>( //property type: int
                  "RankOrder", //property name
                  property => { });
                     user.AddOrUpdateProperty<string>( //property type: string
                     "RankEnglish", //property name
                     property =>
                     {
                         //validation rules
                         property.Attributes.Add(new StringLengthAttribute(250));
                     }
                     );
                     user.AddOrUpdateProperty<string>( //property type: string
                     "RankArabic", //property name
                     property =>
                     {
                         //validation rules
                         property.Attributes.Add(new StringLengthAttribute(250));
                     }
                     );
                     user.AddOrUpdateProperty<string>( //property type: string
                     "ArabicName", //property name
                     property =>
                     {
                         //validation rules
                         property.Attributes.Add(new StringLengthAttribute(250) { MinimumLength = 4 });
                     }
                     );
                     user.AddOrUpdateProperty<string>( //property type: string
                     "EnglishName", //property name
                     property =>
                     {
                         //validation rules
                         property.Attributes.Add(new StringLengthAttribute(250) { MinimumLength = 4 });
                     }
                     );
                     user.AddOrUpdateProperty<string>( //property type: string
                     "MainUnitArabic", //property name
                     property =>
                     {
                         //validation rules
                         property.Attributes.Add(new StringLengthAttribute(250) { MinimumLength = 4 });
                     }
                     );
                     user.AddOrUpdateProperty<string>( //property type: string
                     "MainUnitEnglish", //property name
                     property =>
                     {
                         //validation rules
                         property.Attributes.Add(new StringLengthAttribute(250) { MinimumLength = 4 });
                     }
                     );
                     user.AddOrUpdateProperty<Guid?>( //property type: string
                     "PositionUnitId", //property name
                     property =>
                     {
                         //validation rules
                         property.Attributes.Add(new StringLengthAttribute(250) { MinimumLength = 4 });
                     }
                     );
                     user.AddOrUpdateProperty<string>( //property type: string
                     "PositionEnglish", //property name
                     property =>
                     {
                         //validation rules
                         property.Attributes.Add(new StringLengthAttribute(250) { MinimumLength = 4 });
                     }
                     );
                     user.AddOrUpdateProperty<string>( //property type: string
                     "PositionArabic", //property name
                     property =>
                     {
                         //validation rules
                         property.Attributes.Add(new StringLengthAttribute(250) { MinimumLength = 4 });
                     }
                     );
                 });
             });
    }
}
