using AddressBook.Samples;
using Xunit;

namespace AddressBook.EntityFrameworkCore.Domains;

[Collection(AddressBookTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AddressBookEntityFrameworkCoreTestModule>
{

}
