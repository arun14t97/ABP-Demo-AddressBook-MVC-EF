using System.Threading.Tasks;

namespace AddressBook.Data;

public interface IAddressBookDbSchemaMigrator
{
    Task MigrateAsync();
}
