using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Owl.reCAPTCHA;
using System.Threading.Tasks;
using Volo.Abp.Account.ExternalProviders;
using Volo.Abp.Account.Public.Web.Pages.Account;
using Volo.Abp.Account.Public.Web;
using Volo.Abp.Account.Security.Recaptcha;
using Volo.Abp.Security.Claims;

namespace MOD.Pms.Pages.Account
{
    public class MyLoginModel : LoginModel
    {


        public MyLoginModel(
    IAuthenticationSchemeProvider schemeProvider,
    IOptions<AbpAccountOptions> accountOptions,
               IAbpRecaptchaValidatorFactory recaptchaValidatorFactory,
                IAccountExternalProviderAppService accountExternalProviderAppService,
            ICurrentPrincipalAccessor currentPrincipalAccessor,
         IOptions<IdentityOptions> identityOptions,
IOptionsSnapshot<reCAPTCHAOptions> reCaptchaOptions
    ) : base(
        schemeProvider,
            accountOptions,
            recaptchaValidatorFactory,
            accountExternalProviderAppService,
            currentPrincipalAccessor,
           identityOptions,
           reCaptchaOptions)
        {

        }

        public override Task<IActionResult> OnPostAsync(string action)
        {
            //TODO: Add logic
            return base.OnPostAsync(action);
        }
    }
}