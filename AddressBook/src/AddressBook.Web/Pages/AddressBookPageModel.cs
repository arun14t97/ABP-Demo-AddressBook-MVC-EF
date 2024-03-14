using AddressBook.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AddressBook.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class AddressBookPageModel : AbpPageModel
{
    protected AddressBookPageModel()
    {
        LocalizationResourceType = typeof(AddressBookResource);
    }
}
