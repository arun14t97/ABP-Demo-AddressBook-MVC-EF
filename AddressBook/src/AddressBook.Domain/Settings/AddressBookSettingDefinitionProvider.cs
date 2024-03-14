using Volo.Abp.Settings;

namespace AddressBook.Settings;

public class AddressBookSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AddressBookSettings.MySetting1));
    }
}
