using AddressBook.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AddressBook.Permissions;

public class AddressBookPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var AddressBookGroup = context.AddGroup(AddressBookPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AddressBookPermissions.MyPermission1, L("Permission:MyPermission1"));
        var locationsPermission = AddressBookGroup.AddPermission(AddressBookPermissions.Locations.Default, L("Permission:Locations"));
        locationsPermission.AddChild(AddressBookPermissions.Locations.Create, L("Permission:Locations.Create"));
        locationsPermission.AddChild(AddressBookPermissions.Locations.Edit, L("Permission:Locations.Edit"));
        locationsPermission.AddChild(AddressBookPermissions.Locations.Delete, L("Permission:Locations.Delete"));

        var addressFPermission = AddressBookGroup.AddPermission(AddressBookPermissions.AddressF.Default, L("Permission:AddressF"));
        addressFPermission.AddChild(AddressBookPermissions.AddressF.Create, L("Permission:AddressF.Create"));
        addressFPermission.AddChild(AddressBookPermissions.AddressF.Edit, L("Permission:AddressF.Edit"));
        addressFPermission.AddChild(AddressBookPermissions.AddressF.Delete, L("Permission:AddressF.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AddressBookResource>(name);
    }
}
