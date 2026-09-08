using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MOD.Pms.Data;

/* This is used if database provider does't define
 * IPmsDbSchemaMigrator implementation.
 */
public class NullPmsDbSchemaMigrator : IPmsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
