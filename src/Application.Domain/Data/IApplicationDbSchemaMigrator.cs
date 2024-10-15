using System.Threading.Tasks;

namespace Application.Data;

public interface IApplicationDbSchemaMigrator
{
    Task MigrateAsync();
}
