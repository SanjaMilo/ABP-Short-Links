using LinkStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace LinkStore.Permissions;

public class LinkStorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {   
        // Ova:
        var linkStoreGroup = context.AddGroup(LinkStorePermissions.GroupName, L("Permission:BookStore"));
        // Ovde:
        var linksPermission = linkStoreGroup.AddPermission(LinkStorePermissions.Links.Default, L("Permission:Links"));
        linksPermission.AddChild(LinkStorePermissions.Links.Create, L("Permission:Books.Create"));
        linksPermission.AddChild(LinkStorePermissions.Links.Redirect, L("Permission:Books.Redirect"));
        //linksPermission.AddChild(LinkStorePermissions.Links.Edit, L("Permission:Links.Edit"));
        //linksPermission.AddChild(LinkStorePermissions.Links.Delete, L("Permission:Links.Delete"));

        //Define your own permissions here. Example:
        //linkStoreGroup.AddPermission(LinkStorePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LinkStoreResource>(name);
    }
}
