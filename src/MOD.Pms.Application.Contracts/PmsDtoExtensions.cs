using System;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;
using Volo.Saas.Host.Dtos;

namespace MOD.Pms;

public static class PmsDtoExtensions
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
            /* You can add extension properties to DTOs
             * defined in the depended modules.
             *
             * Example:
             *
             * ObjectExtensionManager.Instance
             *   .AddOrUpdateProperty<IdentityRoleDto, string>("Title");
             *
             * See the documentation for more:
             * https://docs.abp.io/en/abp/latest/Object-Extensions
             */

            ObjectExtensionManager.Instance
               .AddOrUpdateProperty<string>(new[]
               {
                        typeof(OrganizationUnitDto),
                        typeof(OrganizationUnitCreateDto),
                        typeof(OrganizationUnitUpdateDto)
               }, "EnglishName");

            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<string>(new[]
                {
                        typeof(OrganizationUnitDto),
                        typeof(OrganizationUnitCreateDto),
                        typeof(OrganizationUnitUpdateDto)
                }, "ArabicName");

            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<string>(new[]
                {
                        typeof(SaasTenantDto),
                        typeof(SaasTenantCreateDto),
                        typeof(SaasTenantUpdateDto)
                }, "EnglishName");

            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<string>(new[]
                {
                        typeof(SaasTenantDto),
                        typeof(SaasTenantCreateDto),
                        typeof(SaasTenantUpdateDto)
                }, "ArabicName");

            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<int>(new[]
                {
                        typeof(SaasTenantDto),
                        typeof(SaasTenantCreateDto),
                        typeof(SaasTenantUpdateDto)
                }, "Order");


            #region Identity User
            ObjectExtensionManager.Instance.AddOrUpdateProperty<string>(new[] { typeof(IdentityUserDto), typeof(IdentityUserCreateDto), typeof(IdentityUserUpdateDto) }, "ServiceNumber");
            ObjectExtensionManager.Instance.AddOrUpdateProperty<string>(new[] { typeof(IdentityUserDto), typeof(IdentityUserCreateDto), typeof(IdentityUserUpdateDto) }, "RankOrder");
            ObjectExtensionManager.Instance.AddOrUpdateProperty<string>(new[] { typeof(IdentityUserDto), typeof(IdentityUserCreateDto), typeof(IdentityUserUpdateDto) }, "RankEnglish");
            ObjectExtensionManager.Instance.AddOrUpdateProperty<string>(new[] { typeof(IdentityUserDto), typeof(IdentityUserCreateDto), typeof(IdentityUserUpdateDto) }, "RankArabic");
            ObjectExtensionManager.Instance.AddOrUpdateProperty<string>(new[] { typeof(IdentityUserDto), typeof(IdentityUserCreateDto), typeof(IdentityUserUpdateDto) }, "ArabicName");
            ObjectExtensionManager.Instance.AddOrUpdateProperty<string>(new[] { typeof(IdentityUserDto), typeof(IdentityUserCreateDto), typeof(IdentityUserUpdateDto) }, "EnglishName");
            ObjectExtensionManager.Instance.AddOrUpdateProperty<string>(new[] { typeof(IdentityUserDto), typeof(IdentityUserCreateDto), typeof(IdentityUserUpdateDto) }, "MainUnitArabic");
            ObjectExtensionManager.Instance.AddOrUpdateProperty<string>(new[] { typeof(IdentityUserDto), typeof(IdentityUserCreateDto), typeof(IdentityUserUpdateDto) }, "MainUnitEnglish");
            ObjectExtensionManager.Instance.AddOrUpdateProperty<Guid?>(new[] { typeof(IdentityUserDto), typeof(IdentityUserCreateDto), typeof(IdentityUserUpdateDto) }, "PositionUnitId");
            ObjectExtensionManager.Instance.AddOrUpdateProperty<string>(new[] { typeof(IdentityUserDto), typeof(IdentityUserCreateDto), typeof(IdentityUserUpdateDto) }, "PositionEnglish");
            ObjectExtensionManager.Instance.AddOrUpdateProperty<string>(new[] { typeof(IdentityUserDto), typeof(IdentityUserCreateDto), typeof(IdentityUserUpdateDto) }, "PositionArabic");
            #endregion
        });
    }
}
