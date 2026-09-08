using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MOD.Pms.Enums
{
    public enum ReffrenceDocumentType
    {
        Project,
        Agent,
        Drawing,
        Invoice,
        Warning,
        ChangeRequest,
        ProjectAttachment,
        Meeting,
        Form,
        Report,
        OtherProjectForm,
        MubaadaraAttachment
    }
    public enum FileType
    {
        PDF,
        Word,
        Electronic
    }
    public enum TabName
    {
        [Display(Name = "Drawing")]
        Drawing,
        [Display(Name = "Form")]
        Form,
        [Display(Name = "Agent")]
        Agent,
        [Display(Name = "Warning")]
        Warning,
        [Display(Name = "ChangeRequest")]
        ChangeRequest,
        [Display(Name = "Tenders")]
        Tenders,
        [Display(Name = "FinancialAnalysis")]
        FinancialAnalysis,
        [Display(Name = "TechnicalAnalysis")]
        TechnicalAnalysis,
        [Display(Name = "Extensions")]
        Extensions,
        [Display(Name = "AgentEvaluation")]
        AgentEvaluation,
        [Display(Name = "RecommendationResult")]
        RecommendationResult,
        [Display(Name = "Contract")]
        Contract,
        [Display(Name = "FinanceOrder")]
        FinanceOrder,
        [Display(Name = "TenderForm")]
        TenderForm,
        [Display(Name = "Member")]
        Member,
        [Display(Name = "Invoice")]
        Invoice,
        [Display(Name = "Document")]
        Document,
        [Display(Name = "ProjectAttachment")]
        ProjectAttachment,
        [Display(Name = "DependencyProject")]
        DependencyProject,
        [Display(Name = "ProjectTask")]
        ProjectTask,
        [Display(Name = "Meeting")]
        Meeting,
        [Display(Name = "Evaluation")]
        Evaluation,
        [Display(Name = "Workflow")]
        Workflow,
        [Display(Name = "SubAgent")]
        SubAgent,
        [Display(Name ="OtherProjectForms")]
        OtherProjectForms,
        [Display(Name = "ProjectHistories")]
        ProjectUpdates,
        [Display(Name = "ProjectCamera")]
        ProjectCamera,
        [Display(Name = "AnalysisPriceOffers")]
        AnalysisPriceOffers,
    }

    public enum WarningAlert
    {
        [Display(Name = "Warning")]
        Warning,
        [Display(Name = "Alert")]
        Alert
    }

    public enum MeetingStatus
    {
        [Display(Name = "Deferred")]
        Deferred,
        [Display(Name = "Canceled")]
        Canceled,
        [Display(Name = "On Time")]
        OnTime,
    }

    public enum InviteesType
    {
        [Display(Name = "Member")]
        Member,
        [Display(Name = "Agent")]
        Agent,
    }

   public enum PurchseDepartment
    {
        [Display(Name = "الخدمات الهندسية بوزارة الدفاع")]
        MODES,
        [Display(Name = "مديرية المشتريات")]
        DP,
        [Display(Name = "مديرية العقود")]
        DCLA,
    }

    public enum VoteCodeType
    {
        [Display(Name = "Main Item")]
        MainItem,
        [Display(Name = "Spare Item")]
        SpareItem,
     
    }
    public enum AnalysisResultType
    {
        [Display(Name = "Financial")]
        Financial,
        [Display(Name = "Technical")]
        Technical
    }
    public enum Classification
    {
        [Display(Name = "ToKnowledge")]
        ToKnowledge,
        [Display(Name = "ToAction")]
        ToAction
    }


    public enum DashBoard
    {
        [Display(Name = "Jobs")]
        Jobs,
        [Display(Name = "Map")]
        Map,
        [Display(Name = "PhasesStat")]
        PhasesStat,
        [Display(Name = "ProjectStat")]
        ProjectStat,
        [Display(Name = "Schedule")]
        Schedule = 4
    }


    public enum WorkflowStatus
    {
        [Display(Name = "Inbox")]
        Inbox,
        [Display(Name = "Outbox")]
        Outbox,
       

    }

    public enum ApprovalStatus
    {
        [Display(Name = "Pendding")]
        Pendding,
        [Display(Name = "Approved")]
        Approved,
        [Display(Name = "Rejected")]
        Rejected,
    }
    public enum MubaadaraMemberPermission
    {
        [Display(Name = "Read")]
        Read,
        [Display(Name = "ApprovalRequest")]
        ApprovalRequest,
    }
    

    public enum MemberPermission
    {
        [Display(Name = "Read")]
        Read,
        [Display(Name = "ReadWrite")]
        ReadWrite,
    }

    public enum CameraType
    {
        [Display(Name = "Hikvision")]
        Hikvision,
        [Display(Name = "AVIGILON")]
        AVIGILON,
        [Display(Name = "UNIVIEW")]
        UNIVIEW,
    }

    public enum InputType
    {
        [Display(Name = "Main Targets")]
        MainTargets,
        [Display(Name = "Projects / Initiatives")]
        ProjectsOrInitiatives,
        [Display(Name = "Tasks")]
        Tasks,
    }

    public enum Months
    {
        [Display(Name = "January")]
        Jan,
        [Display(Name = "February")]
        Feb,
        [Display(Name = "March")]
        Mar,
        [Display(Name = "April")]
        Apr,
        [Display(Name = "May")]
        May,
        [Display(Name = "June")]
        Jun,
        [Display(Name = "July")]
        Jul,
        [Display(Name = "August")]
        Agu,
        [Display(Name = "September")]
        Sep,
        [Display(Name = "October")]
        Oct,
        [Display(Name = "November")]
        Nov,
        [Display(Name = "December")]
        Dec,
    }

    public enum InputStatus
    {
        [Display(Name = "First Quarterly")]
        FirstQuarterly,
        [Display(Name = "Second Quarterly")]
        SecondQuarterly,
     
    }

    public enum ReportType
    {
        [Display(Name = "General Report")]
        GeneralReport,
        [Display(Name = "Mubaadara Report")]
        MubaadaraReport,
        [Display(Name = "Sub Reprot")]
        SubReprot,

    }

    public enum Quarter
    {
        [Display(Name = "الأول")]
        firstQuarter,
        [Display(Name = "الثاني")]
        SecondQuarter,
        [Display(Name = "الثالث")]
        ThirdQuarter,
        [Display(Name = "الرابع")]
        FourthQuarter,
    }


    public enum TimeLine
    {
        [Display(Name = "Yearly")]
        Yearly,
        [Display(Name = "Midterm")]
        Midterm,
        [Display(Name = "Quarterly")]
        Quarterly,
        [Display(Name = "Monthly")]
        Monthly,
    }
    public enum  Midterm 
    {
        [Display(Name = "FirstMidterm")]
        FirstMidterm,
        [Display(Name = "SecondMidterm")]
        SecondMidterm,
    }

    public enum MubaadaraRequests
    {
        [Display(Name = "InputApproved")]
        InputApproved,
        [Display(Name = "ExtensionApproved")]
        ExtensionApproved,
        [Display(Name = "ChangeMubaadaraStatus")]
        ChangeMubaadaraStatus,
        [Display(Name = "ChangeCompletionPercentage")]
        ChangeCompletionPercentage,
        [Display(Name = "ChallengeApproved")]
        ChallengeApproved,
    }

    public enum MubaadaraChallengeStatus
    {
        [Display(Name = "NoNeed")]
        NoNeed,
        [Display(Name = "Pendding")]
        Pendding,
        [Display(Name = "Approved")]
        Approved,
        [Display(Name = "Rejected")]
        Rejected,
    }

    public enum MubaadaraTypes
    {
        [Display(Name = "MainTarget")]
        MainTarget,
        [Display(Name = "Projects")]
        Projects,
        [Display(Name = "Tasks")]
        Tasks,
        [Display(Name = "ExtraTasks")]
        ExtraTasks,
    }

    public enum MubaadaraStructures
    {
        [Display(Name = "MubaadaraGeneralManager")]
        MubaadaraGeneralManager,
        [Display(Name = "MubaadaraHeadManager")]
        MubaadaraHeadManager,
        [Display(Name = "MubaadaraManager")]
        MubaadaraManager,
    }

    public enum MubaadaraRequestsReply
    {
        [Display(Name = "Pendding")]
        Pendding,
        [Display(Name = "Approved")]
        Approved,
        [Display(Name = "Rejected")]
        Rejected,
        [Display(Name = "Forward")]
        Forward,
    }

    public enum Governortates
    {
        [Display(Name = "Musandam")]
        Musandam,
        [Display(Name = "AlbatinahSouth")]
        AlbatinahSouth,
        [Display(Name = "AlbatinahNorth")]
        AlbatinahNorth,
        [Display(Name = "Dhufar")]
        Dhufar,
        [Display(Name = "Addahkhiliyyah")]
        Addahkhiliyyah,
        [Display(Name = "Alwusta")]
        Alwusta,
        [Display(Name = "Addhahirah")]
        Addhahirah,
        [Display(Name = "AssharqiyyahNorth")]
        AssharqiyyahNorth,
        [Display(Name = "AssharqiyyahSouth")]
        AssharqiyyahSouth,
        [Display(Name = "Alburaymi")]
        Alburaymi,
        [Display(Name = "Muscat")]
        Muscat,
    }

    public enum UpdateType
    {
        [Display(Name = "Updates")]
        Updates,
        [Display(Name = "Approvals")]
        Approvals,
    }

    public enum Sectors
    {
        [Display(Name = "MuscatSector")]
        MuscatSector,
        [Display(Name = "NorthernSector")]
        NorthernSector,
        [Display(Name = "CentralSector")]
        CentralSector,
        [Display(Name = "SouthernSector")]
        SouthernSector,
        [Display(Name = "WestrenSector")]
        WestrenSector,
    }

    public enum IsMeetWarrantyRequirements
    {
        [Display(Name = "Pendding")]
        Pendding,
        [Display(Name = "IsMeetRequirements")]
        IsMeetRequirements,
        [Display(Name = "IsNotMeetRequirements")]
        
        IsNotMeetRequirements,
    }
    public enum IsRecommended
    {
        [Display(Name = "Pendding")]
        Pendding,
        [Display(Name = "Recommended")]
        Recommended,
        [Display(Name = "NotRecommended")]
        NotRecommended,
    }

    public enum TeamWorkEditPermission
    {
        [Display(Name = "Read")]
        Read,
        [Display(Name = "ReadWrite")]
        ReadWrite,
    }

    public enum TeamWorkMemberPermission
    {
        [Display(Name = "GeneralManager1")]
        GeneralManager1,
        [Display(Name = "Manager1")]
        Manager1,
        [Display(Name = "Member1")]
        Member1,
        [Display(Name = "Representative1")]
        Representative1,
    }
}


