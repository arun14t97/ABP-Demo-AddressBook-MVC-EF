using Volo.Abp.Modularity;

namespace AddressBook;

[DependsOn(
    typeof(AddressBookDomainModule),
    typeof(AddressBookTestBaseModule)
)]
public class AddressBookDomainTestModule : AbpModule
{

}
