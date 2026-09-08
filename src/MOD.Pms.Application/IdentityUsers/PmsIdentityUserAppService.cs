using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MOD.Pms.Common;
using MOD.Pms.ExternalApiEntites;
using MOD.Pms.ExternalApiEntites.Jund;
using MOD.Pms.Localization;
using MOD.Pms.Repositories;
using MOD.Pms.UserReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Settings;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.BlobStoring;
using Volo.Abp.Caching;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Saas.Tenants;
using System.Linq.Dynamic.Core;
using Volo.Abp.Users;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using Microsoft.Data.SqlClient;


namespace MOD.Pms.IdentityUsers
{
    [Authorize]
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IPmsIdentityUserAppService), typeof(IdentityUserAppService), typeof(PmsIdentityUserAppService))]
    public class PmsIdentityUserAppService : IdentityUserAppService, IPmsIdentityUserAppService, ITransientDependency
    {
        private readonly IJundClient _jundClient;
        private readonly ISettingManager _settingManager;
        private readonly IDataFilter _dataFilter;
        private readonly ITenantRepository _tenantRepository;
        private readonly IPmsIdentityUserRepository _identityUserRepository;
        private readonly IStringLocalizer<PmsResource> _stringLocalizer;
        private readonly IPermissionManager _permissionManager;
        private readonly IRepository<Volo.Abp.Identity.IdentityRole, Guid> _identityRoleRepository;
        private readonly IRepository<Volo.Abp.Identity.IdentityUserRole> _identityUserRoleRepository;
        protected IBlobContainer<AccountProfilePictureContainer> _accountProfilePictureContainer { get; }

        public PmsIdentityUserAppService(
            IdentityUserManager userManager,
            IIdentityUserRepository userRepository,
            IIdentityRoleRepository roleRepository,
            IOrganizationUnitRepository organizationUnitRepository,
            IIdentityClaimTypeRepository identityClaimTypeRepository,
            IdentityProTwoFactorManager identityProTwoFactorManager,
            IOptions<IdentityOptions> identityOptions,
            IDistributedEventBus distributedEventBus,
            IOptions<AbpIdentityOptions> abpIdentityOptions,
            IPermissionChecker permissionChecker,
            ISettingManager settingManager,
            IJundClient jundClient,
            IBlobContainer<AccountProfilePictureContainer> accountProfilePictureContainer,
            IDataFilter dataFilter,
            ITenantRepository tenantRepository,
            IPmsIdentityUserRepository identityUserRepository,
            IDistributedCache<IdentityUserDownloadTokenCacheItem,string> downloadTokenCache,
            IDistributedCache<ImportInvalidUsersCacheItem, string> importInvalidUsersCache,
            IStringLocalizer<PmsResource> stringLocalizer,
            IPermissionManager permissionManager)
            : base(userManager, userRepository, roleRepository, organizationUnitRepository, identityClaimTypeRepository,identityProTwoFactorManager,identityOptions,distributedEventBus,abpIdentityOptions,permissionChecker, downloadTokenCache,importInvalidUsersCache)
        {
             _jundClient = jundClient;
            _settingManager = settingManager;
            _accountProfilePictureContainer = accountProfilePictureContainer;
            _dataFilter = dataFilter;
            _tenantRepository = tenantRepository;
            _identityUserRepository = identityUserRepository;
            _stringLocalizer = stringLocalizer;
            _permissionManager = permissionManager;
        }


        [AllowAnonymous]
        public async Task<EmployeeDto> GetJundEmployee(string serviceMilitaryId)
        {
            Employee employee = await _jundClient.GetEmployeeAsync(serviceMilitaryId);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(employee.CivilNumber);
            if (employee.TenantId == CurrentTenant.Id.Value)
            {
                return ObjectMapper.Map<Employee, EmployeeDto>(employee);
        }
            else
            {
                throw new UserFriendlyException(_stringLocalizer["ThisEmployeeNotBelongeTnYourTenant"], "403", null, null, logLevel: Microsoft.Extensions.Logging.LogLevel.Information);
    }
}

        [AllowAnonymous]

        public async Task<CommonOperationResultDto<Volo.Abp.Identity.IdentityUserDto>> CreatePmsUserAsync(PmsIdentityUserCreateDto input)
        {

            using (_dataFilter.Disable<IMultiTenant>())
            {
                await IdentityOptions.SetAsync();

                IdentityUserCreateDto userDto = ObjectMapper.Map<PmsIdentityUserCreateDto, IdentityUserCreateDto>(input);
                string email = input.ServiceNumber + "@Mod.saf";
                Guid? tenentid = input.TenantId;



                //IdentityUser user = new IdentityUser(input.UserId, input.UserName, input.Email, input.TenantId)
                //{
                //    Surname = input.Surname,
                //    Name = input.Name
                //};
                //userDto.SetIsActive(true);
                userDto.SetProperty("ServiceNumber", input.ServiceNumber);
                userDto.SetProperty("RankOrder", input.RankOrder);
                userDto.SetProperty("RankEnglish", input.RankEnglish);
                userDto.SetProperty("RankArabic", input.RankArabic);
                userDto.SetProperty("ArabicName", input.ArabicName);
                userDto.SetProperty("EnglishName", input.EnglishName);
                userDto.SetProperty("MainUnitArabic", input.MainUnitArabic);
                userDto.SetProperty("MainUnitEnglish", input.MainUnitEnglish);
                userDto.SetProperty("PositionUnitId", input.PositionUnitId==null  ? null: input.PositionUnitId.ToString());
                userDto.SetProperty("PositionEnglish", input.PositionEnglish == null  ? "no position" : input.PositionEnglish);
                userDto.SetProperty("PositionArabic", input.PositionArabic == null ? "لا يوجد منصب" : input.PositionArabic);
                userDto.PhoneNumber = input.PhoneNumber ?? null;
                userDto.IsActive = true;
                userDto.LockoutEnabled = true;
                userDto.ShouldChangePasswordOnNextLogin = false;
                //userDto.SetEmailConfirmed(true);

                try
                {
                    using (CurrentTenant.Change(tenentid))
                    {
                        Volo.Abp.Identity.IdentityUserDto identityResult = await base.CreateAsync(userDto);
                        if (identityResult != null)
                        {
                            byte[] imageByteArray = input.Photo;

                            if (identityResult.Id != Guid.Empty)
                            {
                                await _settingManager.SetForUserAsync(identityResult.Id, AccountSettingNames.ProfilePictureSource, Enum.GetName(typeof(ProfilePictureType), ProfilePictureType.Image));

                                string userIdText = identityResult.Id.ToString();
                                await _accountProfilePictureContainer.SaveAsync(userIdText, imageByteArray, true);
                            }
                        }
                    }
                }

                catch (AbpIdentityResultException e)

                {

                    return new CommonOperationResultDto<Volo.Abp.Identity.IdentityUserDto>(L[e.Message], false);
                }
                return new CommonOperationResultDto<Volo.Abp.Identity.IdentityUserDto>(L["UserCreatedSuccess"], true);

                //else
                //{



                //    if (identityResult.Errors == null)
                //    {
                //        throw new ArgumentException("identityResult.Errors should not be null.");
                //    }

                //    throw new AbpIdentityResultException(identityResult);
                //}


            }


        }
        [AllowAnonymous]
        public override async Task<Volo.Abp.Identity.IdentityUserDto> GetAsync(Guid id)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                Volo.Abp.Identity.IdentityUserDto user = await base.GetAsync(id);
                if (user != null && user.TenantId.HasValue)
                {
                    Tenant tenant = await _tenantRepository.GetAsync(user.TenantId.Value);
                    user.ExtraProperties.Add("Tenant", tenant);
                }
                return user;
            }
        }
        [AllowAnonymous]

        public override async Task<Volo.Abp.Identity.IdentityUserDto> FindByUsernameAsync(string username)
        {
            if (username.ToLower() == "admin") return null;
               
            using (_dataFilter.Disable<IMultiTenant>())
            {


                Volo.Abp.Identity.IdentityUserDto user = await base.FindByUsernameAsync(username);
                if (user != null && user.TenantId.HasValue)
                {
                    Tenant tenant = await _tenantRepository.GetAsync(user.TenantId.Value);
                    if (await _accountProfilePictureContainer.ExistsAsync(user.Id.ToString())) {

                        var photo = await _accountProfilePictureContainer.GetAllBytesAsync(user.Id.ToString());

                        user.ExtraProperties.Add("Photo", photo);

                    }
                    user.ExtraProperties.Add("Tenant", tenant);

                }
                if (user.TenantId == CurrentTenant.Id.Value)
                {
                                      return user;
                    
                }
                else
                {
                    throw new UserFriendlyException(_stringLocalizer["ThisEmployeeNotBelongeTnYourTenant"], "403", null, null, logLevel: Microsoft.Extensions.Logging.LogLevel.Information);
                }

            }
        }

        [AllowAnonymous]
        public async Task<LoadResult> GetCollectionByLoadOptionsAsync(bool includeCurrentUser, DataSourceLoadOptions loadOptions)
        {
            loadOptions.DefaultSort = "rankOrder";
            using (_dataFilter.Disable<IMultiTenant>())
            {
                AutoMapper.IConfigurationProvider config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
                IQueryable<IdentityUserDte> source = (await _identityUserRepository.GetIdentityUsersQueryableAsync()).WhereIf(!includeCurrentUser, c => c.Id != CurrentUser.Id);

              
                return await DataSourceLoader.LoadAsync(source.ProjectTo<IdentityUserDto>(config), loadOptions);
            }

        }
        public async Task<bool> GetPermissionAsync()
        {
            var permissions = await  _permissionManager.GetAllForUserAsync(CurrentUser.Id.Value);
            return permissions.Any(c=>c.Name== "Report.Reports.DesignReport" && c.IsGranted);
        }
        [AllowAnonymous]
        public override Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            return base.GetRolesAsync(id);
        }

        public async Task<List<IdentityUserDto>> GetAllMubaadaraUsersAsync()
        {
            var role = await _identityRoleRepository.GetAsync(c => c.Name == "admin");
            var userDtoList = (await _identityUserRoleRepository.GetQueryableAsync()).Where(c => c.RoleId == role.Id);

            return (List<IdentityUserDto>)userDtoList;
        }
    }
}
