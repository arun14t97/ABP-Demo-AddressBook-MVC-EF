using Volo.Abp.Modularity;

namespace AddressBook;

public abstract class AddressBookApplicationTestBase<TStartupModule> : AddressBookTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
