using Volo.Abp.Modularity;

namespace AddressBook;

/* Inherit from this class for your domain layer tests. */
public abstract class AddressBookDomainTestBase<TStartupModule> : AddressBookTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
