namespace LinkStore.Permissions;

public static class LinkStorePermissions
{
    public const string GroupName = "LinkStore";



    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    // Ovde:
    public static class Links
    {
        public const string Default = GroupName + ".Links";
        public const string Create = Default + ".Create";
        public const string Redirect = Default + ".Redirect";
        //public const string Edit = Default + ".Edit";
        //public const string Delete = Default + ".Delete";
    }
}
