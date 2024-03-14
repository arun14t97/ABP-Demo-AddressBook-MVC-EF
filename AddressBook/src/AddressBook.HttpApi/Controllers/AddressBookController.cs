using AddressBook.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AddressBook.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AddressBookController : AbpControllerBase
{
    protected AddressBookController()
    {
        LocalizationResource = typeof(AddressBookResource);
    }
}
