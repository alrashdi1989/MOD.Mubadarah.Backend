using System;
using Volo.Abp.Identity;

namespace MOD.Pms;

public static class PmsConsts
{
    public const string DbTablePrefix = "App";
    public const string DbTablePmsPrefix = "Pms_";
    public const string DbTableMubaadaraPrefix = "Mub_";
    public const string DbTableNebarsPrefix = "Nebars_";
    public const string DbTableNebrasRFQPrefix = "NebrasRFQ_";



    public const string DbSchema = null;
    public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;
    public const string AdminPasswordDefaultValue = IdentityDataSeedContributor.AdminPasswordDefaultValue;

    //public static Guid TapesId = Guid.Parse("b1c4f76f-ceb7-3242-cab8-3a06a983e557");

    public static Guid AgentTypeId = Guid.Parse("a166cfc3-4ffe-e1e2-3a64-3a066443df19");
    public static Guid ProjectTypeId = Guid.Parse("3227708b-4fc9-b899-feb1-3a066443dfe2");
    public static Guid MemberTypeId = Guid.Parse("2E29F454-EB03-4D90-BA4B-AC37F531B8AC");
    public static Guid AgentDegreeTypeId = Guid.Parse("E3C3AF4D-E6CA-7D7D-97EB-3A0663F12E28");
    public static Guid DrawingMapTypeId = Guid.Parse("e8999dfc-e3db-b93b-efed-3a073a283eda");
    public static Guid DocumentTypeId = Guid.Parse("0FB97BAC-CB27-DD23-AD04-3A0699F3A363");
    public static Guid PhotoDocumentTypeId = Guid.Parse("cf8c7302-791e-95f8-8cf4-3a06f6913bf0");
    public static Guid PdfDocumentTypeId = Guid.Parse("189d597e-a6f9-b245-51ae-3a06f6913bf6");
    public static Guid StandardTypeId = Guid.Parse("d326c807-716f-1266-f52a-3a06be884379");
    public static Guid ProjectAttachmentTypeId = Guid.Parse("e3a86d01-7526-d83e-23c9-3a07435aa64b");
    public static Guid ProjectPhaseId = Guid.Parse("b01ff678-0e2e-dd10-85f1-3a0772275d66");
    public static Guid CampId = Guid.Parse("2592B446-52B9-EA8F-28F5-3A077229435D");
    public static Guid ScreensId = Guid.Parse("82FE32E1-B0B9-B4D8-DFE0-3A0CB7914AFF");
    public static Guid PhaseId = Guid.Parse("b01ff678-0e2e-dd10-85f1-3a0772275d66");
    public static Guid ImplementationId = Guid.Parse("0F610040-4E9F-F769-185A-3A0B326AF309");
    public static Guid ProjectStatueId = Guid.Parse("E79923F9-9ADC-24FA-6F30-3A0AD3E9C381");
    public static Guid ReportTypeId = Guid.Parse("2E0404FC-1B75-9B30-675E-3A0922C58C16");
    public static Guid SubAgentTypeId = Guid.Parse("E932EBCB-8E79-DC80-F1C9-3A0B73190C6F");
    public static Guid ProjectCreatorId = Guid.Parse("2C48CF99-7FD1-598E-675B-3A0D0F0D6ED5");
    public static Guid StandardsSectionsId = Guid.Parse("583BD1C1-8696-48ED-BFD1-0089FBEBD492");
    public static Guid MubaadraTypeId = Guid.Parse("9e6440ef-75eb-4343-8fe2-b2edeb7fa2eb");
    public static Guid MubaadraStatusId = Guid.Parse("20226ee9-894d-4c08-9e5c-1f9f78f682c3");
    public static Guid DrawingTypeId = Guid.Parse("DBD7873C-14FE-42AA-9EEB-AC161E3765E0");


}
