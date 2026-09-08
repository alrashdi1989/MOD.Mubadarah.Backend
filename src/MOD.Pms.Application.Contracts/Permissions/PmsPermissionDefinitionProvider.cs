using MOD.Pms.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using static MOD.Pms.Permissions.PmsPermissions;

namespace MOD.Pms.Permissions;

public class PmsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        #region ControlPanel

        var pmsControlPanel = context.AddGroup(PmsPermissions.GroupName, L("Permission:ControlPanel"));

        // Lookup
        var lookupPermissionGroup = pmsControlPanel.AddPermission(PmsPermissions.LookupPermission.Default, L("Permission:Lookups"), MultiTenancySides.Both);
        lookupPermissionGroup.AddChild(PmsPermissions.LookupPermission.Insert, L("Permission:Insert"));
        lookupPermissionGroup.AddChild(PmsPermissions.LookupPermission.Delete, L("Permission:Delete"));
        lookupPermissionGroup.AddChild(PmsPermissions.LookupPermission.Update, L("Permission:Update"));
        lookupPermissionGroup.AddChild(PmsPermissions.LookupPermission.Details, L("Permission:Details"));
        lookupPermissionGroup.AddChild(PmsPermissions.LookupPermission.View, L("Permission:View"));

        #endregion

        #region IdentityUsers
        var identityUserGroup = context.AddGroup(PmsPermissions.IdentityUserGroupName, L("Permission:IdentityUsers"));
        var manageIdentityUserPermissionGroup = identityUserGroup.AddPermission(PmsPermissions.IdentityUserPermission.Default, L("Permission:IdentityUsers"), MultiTenancySides.Both);
        manageIdentityUserPermissionGroup.AddChild(PmsPermissions.IdentityUserPermission.AddUserPermissions, L("Permission:AddUserPermissions"));
        manageIdentityUserPermissionGroup.AddChild(PmsPermissions.IdentityUserPermission.AddUsers, L("Permission:AddUsers"));
        manageIdentityUserPermissionGroup.AddChild(PmsPermissions.IdentityUserPermission.MubadaaraUsers, L("Permission:MubadaaraUsers"));
        #endregion

        #region PermissionType
        var permissionTypeGroup = context.AddGroup(PmsPermissions.PermissionTypeGroupName, L("Permission:PermissionType"));
        var permissionTypePermissionGroup = permissionTypeGroup.AddPermission(PmsPermissions.PermissionTypePermission.Default, L("Permission:PermissionType"), MultiTenancySides.Both);
        permissionTypePermissionGroup.AddChild(PmsPermissions.PermissionTypePermission.MotabiePermissions, L("Permission:MotabiePermissions"));
        permissionTypePermissionGroup.AddChild(PmsPermissions.PermissionTypePermission.MubaadaraPermissions, L("Permission:MubaadaraPermissions"));
        #endregion


        #region Mubaadaras
        var mubaadarasSystemGroup = context.AddGroup(PmsPermissions.MubaadaraGroupName, L("Permission:MubaadarasSystem"));

        var mubaadarasSystemPermissionGroup = mubaadarasSystemGroup.AddPermission(PmsPermissions.MubaadaraSystemPermission.Default, L("Permission:MubaadarasSystem"));
        mubaadarasSystemPermissionGroup.AddChild(PmsPermissions.MubaadaraSystemPermission.View, L("Permission:View"));

        var mubaadaraDataGroup = mubaadarasSystemPermissionGroup.AddChild(PmsPermissions.MubaadaraDataPermission.Default, L("Permission:MubaadaraData"));
        mubaadaraDataGroup.AddChild(PmsPermissions.MubaadaraDataPermission.View, L("Permission:View"));
        mubaadaraDataGroup.AddChild(PmsPermissions.MubaadaraDataPermission.Insert, L("Permission:Insert"));
        mubaadaraDataGroup.AddChild(PmsPermissions.MubaadaraDataPermission.DeleteMubaadara, L("Permission:DeleteMubaadara"));
        mubaadaraDataGroup.AddChild(PmsPermissions.MubaadaraDataPermission.UpdateMubaadara, L("Permission:UpdateMubaadara"));
        mubaadaraDataGroup.AddChild(PmsPermissions.MubaadaraDataPermission.MubaadaraDetail, L("Permission:MubaadaraDetail"));
        mubaadaraDataGroup.AddChild(PmsPermissions.MubaadaraDataPermission.ViewMubaadaraReport, L("Permission:ViewMubaadaraReport"));


        var mubaadaraDashboardGroup = mubaadarasSystemPermissionGroup.AddChild(PmsPermissions.MubaadaraDashboardPermission.Default, L("Permission:Dashboard"));
        mubaadaraDashboardGroup.AddChild(PmsPermissions.MubaadaraDashboardPermission.View, L("Permission:View"));
        mubaadaraDashboardGroup.AddChild(PmsPermissions.MubaadaraDashboardPermission.AddCommentTab, L("Permission:AddCommentTab"));
        mubaadaraDashboardGroup.AddChild(PmsPermissions.MubaadaraDashboardPermission.AddComment, L("Permission:AddComment"));


        var mubaadaraReportsGroup = mubaadarasSystemPermissionGroup.AddChild(PmsPermissions.MubaadaraReportsPermission.Default, L("Permission:Reports"));
        mubaadaraReportsGroup.AddChild(PmsPermissions.MubaadaraReportsPermission.View, L("Permission:View"));

        var mubaadaraDetailGroup = mubaadarasSystemPermissionGroup.AddChild(PmsPermissions.MubaadaraDetailTabPermission.Default, L("Permission:Details"), MultiTenancySides.Both);

        var mubaadaraHistorieyGroup = mubaadaraDetailGroup.AddChild(PmsPermissions.MubaadaraHistorieyTabPermission.Default, L("Permission:MubaadaraHistoriey"));
        mubaadaraHistorieyGroup.AddChild(PmsPermissions.MubaadaraHistorieyTabPermission.View, L("Permission:View"));
        mubaadaraHistorieyGroup.AddChild(PmsPermissions.MubaadaraHistorieyTabPermission.Insert, L("Permission:Insert"));
        mubaadaraHistorieyGroup.AddChild(PmsPermissions.MubaadaraHistorieyTabPermission.Delete, L("Permission:Delete"));
        mubaadaraHistorieyGroup.AddChild(PmsPermissions.MubaadaraHistorieyTabPermission.Update, L("Permission:Update"));

        var mubaadaraChallengeGroup = mubaadaraDetailGroup.AddChild(PmsPermissions.MubaadaraChallengeTabPermission.Default, L("Permission:MubaadaraChallenge"));
        mubaadaraChallengeGroup.AddChild(PmsPermissions.MubaadaraChallengeTabPermission.View, L("Permission:View"));
        mubaadaraChallengeGroup.AddChild(PmsPermissions.MubaadaraChallengeTabPermission.Insert, L("Permission:Insert"));
        mubaadaraChallengeGroup.AddChild(PmsPermissions.MubaadaraChallengeTabPermission.Delete, L("Permission:Delete"));
        mubaadaraChallengeGroup.AddChild(PmsPermissions.MubaadaraChallengeTabPermission.Update, L("Permission:Update"));

        var mubaadaraAttachmentGroup = mubaadaraDetailGroup.AddChild(PmsPermissions.MubaadaraAttachmentTabPermission.Default, L("Permission:MubaadaraAttachment"));
        mubaadaraAttachmentGroup.AddChild(PmsPermissions.MubaadaraAttachmentTabPermission.View, L("Permission:View"));
        mubaadaraAttachmentGroup.AddChild(PmsPermissions.MubaadaraAttachmentTabPermission.Insert, L("Permission:Insert"));
        mubaadaraAttachmentGroup.AddChild(PmsPermissions.MubaadaraAttachmentTabPermission.Delete, L("Permission:Delete"));
        mubaadaraAttachmentGroup.AddChild(PmsPermissions.MubaadaraAttachmentTabPermission.Update, L("Permission:Update"));

        var mubaadaraMemberGroup = mubaadaraDetailGroup.AddChild(PmsPermissions.MubaadaraMemberTabPermission.Default, L("Permission:MubaadaraMember"));
        mubaadaraMemberGroup.AddChild(PmsPermissions.MubaadaraMemberTabPermission.View, L("Permission:View"));
        mubaadaraMemberGroup.AddChild(PmsPermissions.MubaadaraMemberTabPermission.Insert, L("Permission:Insert"));
        mubaadaraMemberGroup.AddChild(PmsPermissions.MubaadaraMemberTabPermission.Delete, L("Permission:Delete"));
        mubaadaraMemberGroup.AddChild(PmsPermissions.MubaadaraMemberTabPermission.Update, L("Permission:Update"));

        var workflowTabGroup = mubaadarasSystemPermissionGroup.AddChild(PmsPermissions.MubaadarasWorkflowPermission.Default, L("Permission:MubaadaraWorkflow"));
        workflowTabGroup.AddChild(PmsPermissions.MubaadarasWorkflowPermission.View, L("Permission:View"));

        #endregion

    }



    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PmsResource>(name);
    }
}

