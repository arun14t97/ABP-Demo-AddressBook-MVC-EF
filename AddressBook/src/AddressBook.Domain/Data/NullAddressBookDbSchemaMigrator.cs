using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AddressBook.Data;

/* This is used if database provider does't define
 * IAddressBookDbSchemaMigrator implementation.
 */
public class NullAddressBookDbSchemaMigrator : IAddressBookDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
