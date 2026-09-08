using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace MOD.Pms.IdentityUsers
{
    public class IdentityUserClaimsPrincipalContributer : IAbpClaimsPrincipalContributor, ITransientDependency
    {
        public async Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
        {
             var identity= context.ClaimsPrincipal.Identities.FirstOrDefault();
            identity.AddClaim(new Claim("Tenant", "RAO"));
        }
        
    }
}
