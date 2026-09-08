using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Threading;
using Volo.Abp;
using Volo.Saas.Tenants;
using Volo.Abp.Data;
using System.Linq;
using System.Globalization;
using Volo.Saas;

namespace MOD.Pms.Pages.TenantSwitch
{
    public class TenantSwitchModalModel : AbpPageModel
    {
        [BindProperty]
        public TenantInfoModel Input { get; set; }

        public SelectList TenantDropDownList { get; set; }

        protected ITenantStore TenantStore { get; }

        protected ITenantRepository TenantRepository { get; }
        protected AbpAspNetCoreMultiTenancyOptions Options { get; }



        public TenantSwitchModalModel(
            ITenantStore tenantStore,
            IOptions<AbpAspNetCoreMultiTenancyOptions> options,
            ITenantRepository tenantRepository)
        {
            TenantStore = tenantStore;
            Options = options.Value;
            LocalizationResourceType = typeof(AbpUiMultiTenancyResource);
            TenantRepository = tenantRepository;
        }

        public virtual async Task OnGetAsync()
        {
            Input = new TenantInfoModel();

            if (CurrentTenant.IsAvailable)
            {
                var tenant = await TenantRepository.FindAsync(CurrentTenant.GetId());
                var tenantConfig = await TenantStore.FindAsync(CurrentTenant.GetId());

                Input.TenantFullName = tenant?.GetProperty<string>("ArabicName");
                Input.Name = tenantConfig?.Name;
                Input.Id = tenantConfig!.Id;

                PopulateTenantDropDownList(await TenantRepository.FindByIdAsync(tenantConfig!.Id));
            }
            else
            {
                PopulateTenantDropDownList();
            }

        }

        public virtual async Task OnPostAsync()
        {
            Guid? tenantId = null;
            if (!Input.Name.IsNullOrEmpty())
            {
                var tenant = await TenantStore.FindAsync(Input.Name);
                if (tenant == null)
                {
                    throw new UserFriendlyException(L["GivenTenantIsNotExist", Input.TenantFullName]);
                }

                if (!tenant.IsActive)
                {
                    throw new UserFriendlyException(L["GivenTenantIsNotAvailable", Input.TenantFullName]);
                }

                tenantId = tenant.Id;
            }
            AbpMultiTenancyCookieHelper.SetTenantCookie(HttpContext, tenantId, Options.TenantKey);
        }

        public class TenantInfoModel
        {
            [InputInfoText("SwitchTenantHint")]
            public string Name { get; set; }

            public string TenantFullName { get; set; }

            public Guid Id { get; set; }
        }

        public void PopulateTenantDropDownList(Tenant selectedTenant = null)
        {
            var tenantsQuery = AsyncHelper.RunSync(
                () => TenantRepository.GetListAsync()).Where(t => t.ActivationState == TenantActivationState.Active)
               .OrderBy(t => t.GetProperty<int>("Order"))
                .Select(x => new TenantInfoModel
                {
                    Name = x.Name,
                    TenantFullName = CultureInfo.CurrentUICulture.Name.StartsWith("en") ? x.GetProperty<string>("EnglishName") : x.GetProperty<string>("ArabicName"),

                    Id = x.Id
                }
                );

            TenantDropDownList = new SelectList(tenantsQuery, "Name", "TenantFullName", selectedTenant?.Name);
        }
    }
}
