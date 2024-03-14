using System.Threading.Tasks;
using AddressBook.Localization;
using AddressBook.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace AddressBook.Web.Menus;

public class AddressBookMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<AddressBookResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AddressBookMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "AddressBook",
                l["Menu:AddressBook"],
                icon: "fa-solid fa-map-location-dot"
            ).AddItem(
                new ApplicationMenuItem(
                    "AddressBook.Locations",
                    l["Menu:Locations"],
                    url: "/Locations"
                    ))
            );

        return Task.CompletedTask;
    }
}
