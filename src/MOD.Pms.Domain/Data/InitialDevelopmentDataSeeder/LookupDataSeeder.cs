using MOD.Pms.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace MOD.Pms.Data.InitialDevelopmentDataSeeder
{
    public interface ILookupDataSeeder
    {
        Task SeedAsync();
    }
    public class LookupDataSeeder : ITransientDependency, ILookupDataSeeder
    {
        private readonly IRepository<Lookup, Guid> _lookupRepository;

        public LookupDataSeeder(IRepository<Lookup, Guid> lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }

        [UnitOfWork]
        public async Task SeedAsync()
        {
            Lookup agentTypes;
            var isAgentTypesExist = await _lookupRepository.AnyAsync(c => c.EnglishName == "AgentTypes");
            if (!isAgentTypesExist)
            {
                agentTypes = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.AgentTypeId)
                {
                    EnglishName = "AgentTypes",
                    ArabicName = "انواع الشركات",
                    Priority = 0
                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Limited",
                    ArabicName = "محدودة",
                    Priority = 0,
                    LookupId = agentTypes.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Partnership",
                    ArabicName = "مشتركة",
                    Priority = 1,
                    LookupId = agentTypes.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Holding",
                    ArabicName = "قابضة",
                    Priority = 2,
                    LookupId = agentTypes.Id,

                }, true);
            }
            Lookup documentType;
            var isDocumentTypesExist = await _lookupRepository.AnyAsync(c => c.EnglishName == "Document Types");
            if (!isDocumentTypesExist)
            {
                documentType = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.DocumentTypeId)
                {
                    EnglishName = "Document Types",
                    ArabicName = "أنواع الوثائق",
                    Priority = 1
                }, true);
                await _lookupRepository.InsertAsync(new Lookup(PmsConsts.PhotoDocumentTypeId)
                {
                    EnglishName = "photo",
                    ArabicName = "صور ",
                    Priority = 0,
                    LookupId = documentType.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "pdf",
                    ArabicName = "ملفات ",
                    Priority = 1,
                    LookupId = documentType.Id,

                }, true);


            }
            Lookup projectAttachmentType;
            var isProjectAttachmentTypeExist = await _lookupRepository.AnyAsync(c => c.EnglishName == "ProjectAttachmentType");
            if (!isProjectAttachmentTypeExist)
            {
                projectAttachmentType = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.ProjectAttachmentTypeId)
                {
                    EnglishName = "ProjectAttachmentType",
                    ArabicName = "أنواع الوثائق",
                    Priority = 2
                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Books",
                    ArabicName = "كتيبات",
                    Priority = 0,
                    LookupId = projectAttachmentType.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Guarantees",
                    ArabicName = "ضمانات",
                    Priority = 0,
                    LookupId = projectAttachmentType.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Long-term contracts",
                    ArabicName = "العقود طويلة الأجل",
                    Priority = 0,
                    LookupId = projectAttachmentType.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Official Letters",
                    ArabicName = "رسائل رسمية",
                    Priority = 0,
                    LookupId = projectAttachmentType.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Engineer Instructions",
                    ArabicName = "تعليمات المهندس",
                    Priority = 0,
                    LookupId = projectAttachmentType.Id,

                }, true);
            }
            Lookup agentDegree;
            var isAgentDegreeExist = await _lookupRepository.AnyAsync(c => c.EnglishName == "AgentDegrees");
            if (!isAgentDegreeExist)
            {
                agentDegree = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.AgentDegreeTypeId)
                {
                    EnglishName = "AgentDegrees",
                    ArabicName = "درجات الشركات",
                    Priority = 3
                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "First Degree",
                    ArabicName = "الدرجة الأولى",
                    Priority = 0,
                    LookupId = agentDegree.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Second Degree",
                    ArabicName = "الدرجة الثانية",
                    Priority = 1,
                    LookupId = agentDegree.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Third Degree",
                    ArabicName = "الدرجة الثالثة",
                    Priority = 2,
                    LookupId = agentDegree.Id,

                }, true);
            }
            Lookup ProjectPhases;
            var isProjectPhasesExist = await _lookupRepository.AnyAsync(c => c.EnglishName == "ProjectPhases");
            if (!isProjectPhasesExist)
            {
                ProjectPhases = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.ProjectPhaseId)
                {

                    EnglishName = "ProjectPhases",
                    ArabicName = "مراحل المشروع",
                    Priority = 4
                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "ApplicationStudy",
                    ArabicName = "دراسة الطلب",
                    Priority = 0,
                    LookupId = ProjectPhases.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "FirstPhase",
                    ArabicName = "المرحلة الأولى",
                    Priority = 0,
                    LookupId = ProjectPhases.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "implementedPhase",
                    ArabicName = "مرحلة تنفيذ",
                    Priority = 1,
                    LookupId = ProjectPhases.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "FinalPhase",
                    ArabicName = "المرحلة النهائية",
                    Priority = 1,
                    LookupId = ProjectPhases.Id,

                }, true);
            }
            Lookup ProjectStatue;
            var isProjectStatueExist = await _lookupRepository.AnyAsync(c => c.EnglishName == "ProjectStatue");
            if (!isProjectStatueExist)
            {
                ProjectStatue = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.ProjectStatueId)
                {
                    EnglishName = "ProjectStatue",
                      ArabicName = "حالة المشروع",
                      Priority = 0
                  }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Delayed",
                    ArabicName = "مؤجل",
                    Priority = 1,
                    LookupId = ProjectStatue.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "InProcess",
                    ArabicName = "قيد الإجراء",
                    Priority = 2,
                    LookupId = ProjectStatue.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "hanging",
                    ArabicName = "معلق",
                    Priority = 3,
                    LookupId = ProjectStatue.Id,

                }, true);
            }
            Lookup Camp;
            var isCampExist = await _lookupRepository.AnyAsync(c => c.EnglishName == "Camp");
            if (!isCampExist)
            {
                Camp = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.CampId)
                {

                    EnglishName = "Camp",
                    ArabicName = "إسم المعسكر",
                    Priority = 5
                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Al-murtfaComp",
                    ArabicName = "معسكر المرتفعة",
                    Priority = 0,
                    LookupId = Camp.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Bait AL-Falag",
                    ArabicName = "معسكر بيت الفلج",
                    Priority = 1,
                    LookupId = Camp.Id,

                }, true);

            }
            Lookup projectTypes;
            var isProjectTypesExist = await _lookupRepository.AnyAsync(c => c.EnglishName == "ProjectTypes");
            if (!isProjectTypesExist)
            {
                projectTypes = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.ProjectTypeId)
                {

                    EnglishName = "ProjectTypes",
                    ArabicName = "انواع المشاريع",
                    Priority = 6
                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Structural",
                    ArabicName = "إنشائي",
                    Priority = 0,
                    LookupId = projectTypes.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Capitalistic",
                    ArabicName = "معدات",
                    Priority = 1,
                    LookupId = projectTypes.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Joint Structural",
                    ArabicName = "إنشائي مصاحب",
                    Priority = 2,
                    LookupId = projectTypes.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Joint Capitalistic",
                    ArabicName = "معدات مصاحب",
                    Priority = 3,
                    LookupId = projectTypes.Id,

                }, true);
            }
            // adding member type dataseeder 
            Lookup memberTypes;
            var isMemberTypesExist = await _lookupRepository.AnyAsync(c => c.EnglishName == "MemberTypes");
            if (!isMemberTypesExist)
            {
                memberTypes = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.MemberTypeId)
                {

                    EnglishName = "MemberTypes",
                    ArabicName = "انواع الأعضاء",
                    Priority = 7
                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Admin",
                    ArabicName = "مدير",
                    Priority = 0,
                    LookupId = memberTypes.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Assistant Admin",
                    ArabicName = "مساعد مدير",
                    Priority = 1,
                    LookupId = memberTypes.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Member",
                    ArabicName = "عضو",
                    Priority = 2,
                    LookupId = memberTypes.Id,

                }, true);
            }
            Lookup DrawingMapType;
            var isDrawingMapType = await _lookupRepository.AnyAsync(c => c.EnglishName == "DrawingMapType");
            if (!isDrawingMapType)
            {
                DrawingMapType = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.DrawingMapTypeId)
                {

                    EnglishName = "DrawingMapType",
                    ArabicName = "انواع الخرائط",
                    Priority = 8
                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Electrical",
                    ArabicName = "كهربائي",
                    Priority = 0,
                    LookupId = DrawingMapType.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Structural",
                    ArabicName = "إنشائي",
                    Priority = 1,
                    LookupId = DrawingMapType.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Architectural",
                    ArabicName = "معماري",
                    Priority = 2,
                    LookupId = DrawingMapType.Id,

                }, true);
            }


            Lookup StandardsSection;
            var isStandardsSectionExist = await _lookupRepository.AnyAsync(c => c.EnglishName == "Standards Sections");
            if (!isStandardsSectionExist)
            {
                StandardsSection = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.StandardsSectionsId)
                {

                    EnglishName = "Standards Sections",
                    ArabicName = " أقسام المعايير",
                    Priority = 0
                }, true);
                
            }
            Lookup standardType;
            var isStandardTypesExist = await _lookupRepository.AnyAsync(c => c.EnglishName == "StandardType");
            if (!isStandardTypesExist)
            {
                standardType = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.StandardTypeId)
                {

                    EnglishName = "StandardType",
                    ArabicName = "المعايير",
                    Priority = 9
                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    ArabicName = "الثقة",
                    EnglishName = "Trust",
                    Priority = 0,
                    LookupId = standardType.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    ArabicName = "الوقت",
                    EnglishName = "Time",
                    Priority = 1,
                    LookupId = standardType.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    ArabicName = "ألعمل",
                    EnglishName = "Work",
                    Priority = 2,
                    LookupId = standardType.Id,

                }, true);
            }

        
            Lookup ReportingType;
            var isReportingType = await _lookupRepository.AnyAsync(c => c.EnglishName == "ReportingType");
            if (!isReportingType)
            {
                ReportingType = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.ReportTypeId)
                {

                    EnglishName = "ReportingType",
                    ArabicName = "أنواع التقارير",
                    Priority = 10
                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = " Finance Reports",
                    ArabicName = "تقارير مالية",
                    Priority = 0,
                    LookupId = ReportingType.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Managment Report",
                    ArabicName = "تقارير إدارية",
                    Priority = 1,
                    LookupId = ReportingType.Id,

                }, true);

            }
            Lookup ContractorType;
            var isContractorType = await _lookupRepository.AnyAsync(c => c.EnglishName == "ContractorTypes");
            if (!isContractorType)
            {
                ContractorType = await _lookupRepository.InsertAsync(new Lookup(PmsConsts.SubAgentTypeId)
                {

                    EnglishName = "ContractorTypes",
                    ArabicName = "نوع المقاول",
                    Priority = 11
                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Main Agent",
                    ArabicName = "مقاول رئيسي",
                    Priority = 0,
                    LookupId = ContractorType.Id,

                }, true);
                await _lookupRepository.InsertAsync(new Lookup
                {
                    EnglishName = "Sub Agent",
                    ArabicName = "مقاول فرعي",
                    Priority = 1,
                    LookupId = ContractorType.Id,

                }, true);

            }
        }
    }
      
}

