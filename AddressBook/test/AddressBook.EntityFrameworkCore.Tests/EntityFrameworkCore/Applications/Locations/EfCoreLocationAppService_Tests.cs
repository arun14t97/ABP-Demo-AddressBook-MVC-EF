using AddressBook.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AddressBook.EntityFrameworkCore.Applications.Locations
{
    [Collection(AddressBookTestConsts.CollectionDefinitionName)]
    public class EfCoreLocationAppService_Tests : LocationAppService_Tests<AddressBookEntityFrameworkCoreTestModule>
    {
    }
}
