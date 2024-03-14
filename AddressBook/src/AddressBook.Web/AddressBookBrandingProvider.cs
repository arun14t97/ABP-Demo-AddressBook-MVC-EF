using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AddressBook.Web;

[Dependency(ReplaceServices = true)]
public class AddressBookBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AddressBook";
}
