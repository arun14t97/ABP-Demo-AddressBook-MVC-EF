namespace AddressBook.Permissions;

public static class AddressBookPermissions
{
    public const string GroupName = "AddressBook";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Locations
    {
        public const string Default = GroupName + ".Locations";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    // *** ADDED a NEW NESTED CLASS ***
    public static class AddressF
    {
        public const string Default = GroupName + ".AddressF";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

}
