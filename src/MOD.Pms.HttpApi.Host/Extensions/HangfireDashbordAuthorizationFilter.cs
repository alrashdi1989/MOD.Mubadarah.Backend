using Hangfire.Annotations;
using Hangfire.Dashboard;
using System.Threading.Tasks;

namespace MOD.Pms.Extensions
{
    public class HangfireDashbordAuthorizationFilter : IDashboardAsyncAuthorizationFilter
    {
        public Task<bool> AuthorizeAsync([NotNull] DashboardContext context)
        {
            var httpContext=context.GetHttpContext();

           //return Task.FromResult(httpContext.User.Identity.IsAuthenticated );
          return Task.FromResult(true);
        }
    }
}
