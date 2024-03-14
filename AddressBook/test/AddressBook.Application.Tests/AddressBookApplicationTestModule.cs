using Volo.Abp.Modularity;

namespace AddressBook;

[DependsOn(
    typeof(AddressBookApplicationModule),
    typeof(AddressBookDomainTestModule)
)]
public class AddressBookApplicationTestModule : AbpModule
{

}
