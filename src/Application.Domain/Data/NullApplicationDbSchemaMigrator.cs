using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Application.Data;

/* This is used if database provider does't define
 * IApplicationDbSchemaMigrator implementation.
 */
public class NullApplicationDbSchemaMigrator : IApplicationDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
