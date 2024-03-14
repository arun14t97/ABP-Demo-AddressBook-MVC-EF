using System;
using System.Collections.Generic;
using System.Text;
using AddressBook.Localization;
using Volo.Abp.Application.Services;

namespace AddressBook;

/* Inherit your application services from this class.
 */
public abstract class AddressBookAppService : ApplicationService
{
    protected AddressBookAppService()
    {
        LocalizationResource = typeof(AddressBookResource);
    }
}
