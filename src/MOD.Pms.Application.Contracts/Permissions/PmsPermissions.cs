using Volo.Abp.MultiTenancy;

namespace MOD.Pms.Permissions;

public static class PmsPermissions
{
    public const string GroupName = "Pms";
    public const string LookupGroupName = "Lookup";
    public const string IdentityUserGroupName = "IdentityUser";
    public const string PermissionTypeGroupName = "PermissionType";

    public const string MubaadaraGroupName = "MubaadarasSystem";


    #region ControlPanel

    public static class LookupPermission
    {
        public const string Default = LookupGroupName;
        public const string View = Default + ".View";
        public const string Insert = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Details = Default + ".Details";
    }

    #endregion

    #region IdentityUser
    public static class IdentityUserPermission
    {
        public const string Default = IdentityUserGroupName;
        public const string AddUsers = Default + ".AddUsers";
        public const string AddUserPermissions = Default + ".AddUserPermissions";
        public const string MubadaaraUsers = Default + ".MubadaaraUsers";
    }

    #endregion

    #region IdentityUser
    public static class PermissionTypePermission
    {
        public const string Default = PermissionTypeGroupName;
        public const string MubaadaraPermissions = Default + ".MubaadaraPermissions";
        public const string MotabiePermissions = Default + ".MotabiePermissions";
    }

    #endregion

    #region Mubaadaras
    public static class MubaadaraSystemPermission
    {
        public const string Default = MubaadaraGroupName;
        public const string View = Default + ".View";
    }
    public static class MubaadaraDashboardPermission
    {
        public const string Default = MubaadaraSystemPermission.Default + ".MubaadaraDashboard";
        public const string View = Default + ".View";
        public const string AddCommentTab = Default + ".AddCommentTab";
        public const string AddComment = Default + ".AddComment";

    }




    public static class MubaadaraReportsPermission
    {
        public const string Default = MubaadaraSystemPermission.Default + ".MubaadaraReports";
        public const string View = Default + ".View";
    }

    public static class MubaadaraDataPermission
    {
        public const string Default = MubaadaraSystemPermission.Default + ".MubaadaraData";
        public const string Insert = Default + ".Create";
        public const string View = Default + ".View";
        public const string DeleteMubaadara = Default + ".DeleteMubaadara";
        public const string UpdateMubaadara = Default + ".UpdateMubaadara";
        public const string MubaadaraDetail = Default + ".MubaadaraDetail";
        public const string ViewMubaadaraReport = Default + ".ViewMubaadaraReport";

    }

    public static class MubaadaraDetailTabPermission
    {
        public const string Default = MubaadaraSystemPermission.Default + ".MubaadaraDetails";
    }
    public static class MubaadaraHistorieyTabPermission
    {
        public const string Default = MubaadaraDetailTabPermission.Default + ".MubaadaraHistoriey";
        public const string View = Default + ".View";
        public const string Insert = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
    public static class MubaadaraChallengeTabPermission
    {
        public const string Default = MubaadaraDetailTabPermission.Default + ".MubaadaraChallenge";
        public const string View = Default + ".View";
        public const string Insert = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class MubaadaraAttachmentTabPermission
    {
        public const string Default = MubaadaraDetailTabPermission.Default + ".MubaadaraAttachment";
        public const string View = Default + ".View";
        public const string Insert = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class MubaadaraMemberTabPermission
    {
        public const string Default = MubaadaraDetailTabPermission.Default + ".MubaadaraMember";
        public const string View = Default + ".View";
        public const string Insert = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }


    public static class MubaadarasWorkflowPermission
    {
        public const string Default = MubaadaraSystemPermission.Default + ".MubaadaraWorkflow";
        public const string View = Default + ".View";
    }
    #endregion

}


