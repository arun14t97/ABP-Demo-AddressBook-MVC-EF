using AddressBook.Samples;
using Xunit;

namespace AddressBook.EntityFrameworkCore.Applications;

[Collection(AddressBookTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AddressBookEntityFrameworkCoreTestModule>
{

}
