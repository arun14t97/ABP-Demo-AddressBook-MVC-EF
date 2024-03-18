using AddressBook.AddressF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AddressBook.EntityFrameworkCore.Applications.AddressF
{
    [Collection(AddressBookTestConsts.CollectionDefinitionName)]
    public class EfCoreAddressAppService_Tests : AddressAppService_Tests<AddressBookEntityFrameworkCoreTestModule>
    {
    }
}
