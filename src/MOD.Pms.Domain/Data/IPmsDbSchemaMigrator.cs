using System.Threading.Tasks;

namespace MOD.Pms.Data;

public interface IPmsDbSchemaMigrator
{
    Task MigrateAsync();
}
