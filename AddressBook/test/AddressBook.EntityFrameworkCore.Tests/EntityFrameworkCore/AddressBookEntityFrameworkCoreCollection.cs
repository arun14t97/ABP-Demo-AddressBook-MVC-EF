using Xunit;

namespace AddressBook.EntityFrameworkCore;

[CollectionDefinition(AddressBookTestConsts.CollectionDefinitionName)]
public class AddressBookEntityFrameworkCoreCollection : ICollectionFixture<AddressBookEntityFrameworkCoreFixture>
{

}
