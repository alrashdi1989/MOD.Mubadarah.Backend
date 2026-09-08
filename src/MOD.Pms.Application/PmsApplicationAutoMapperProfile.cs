using AutoMapper;
using MOD.Pms.Common;
using MOD.Pms.CommonDte;
using MOD.Pms.Documents;
using MOD.Pms.ExternalApiEntites;
using MOD.Pms.ExternalApiEntites.Jund;
using MOD.Pms.IdentityUsers;
using MOD.Pms.Lookups;
using MOD.Pms.MubaadaraApprovals;
using MOD.Pms.MubaadaraAttachments;
using MOD.Pms.MubaadaraChangeRequests;
using MOD.Pms.MubaadaraDetails;
using MOD.Pms.MubaadaraHEComments;
using MOD.Pms.MubaadaraHistories;
using MOD.Pms.Mubaadaras;
using MOD.Pms.MubaadarasMembers;
using MOD.Pms.MubaadaraUpdates;
using MOD.Pms.MubaadaraWorkflows;
using MOD.Pms.MubadaaraDetails;
using MOD.Pms.UserReports;
using System.Linq;
using Volo.Abp.Identity;

namespace MOD.Pms;

public class PmsApplicationAutoMapperProfile : Profile
{
    public PmsApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Lookup, LookupDto>();
        CreateMap<BlobDte, BlobDto>();
        CreateMap<UnitTreeByLevelDto, OrganizationUnit>();

        CreateMap<MubaadaraMember, MubaadaraMemberDto>().ReverseMap();
        CreateMap<MubaadaraChangeRequest, MubaadaraChangeRequestsDto>().ReverseMap();
        CreateMap<MubaadaraChangeRequestsApprovalDto, MubaadaraChangeRequestsApprovalDto>();
        CreateMap<MubaadaraHEComment, MubaadaraHECommentsDto>();

        CreateMap<Document, DocumentDto>().ReverseMap();

        CreateMap<MubaadaraAttachmentDocument, FileDto>().ReverseMap();

        CreateMap<MubaadaraAttachment, MubaadaraAttachmentDto>().ForMember(dest => dest.File, option => option.MapFrom(src => src.Documents.FirstOrDefault())).ReverseMap();

        CreateMap<MubaadaraApproval, MubaadaraApprovalDto>().ReverseMap();

        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<PmsIdentityUserCreateDto, IdentityUser>()
            .ForMember(dest => dest.ExtraProperties, option => option.MapFrom(src => src.ExtraProperties));

        CreateMap<IdentityUserDte, IdentityUsers.IdentityUserDto>()
            .ForMember(dest => dest.RankNamePosition, option => option.MapFrom(src => $"{src.Rank} / {src.Name} / {src.Position}"))
            .ForMember(dest => dest.FullName, option => option.MapFrom(src => $"{src.Rank} / {src.Name} / {src.Position} / {src.Tenant} / {src.ServiceNumber}")); ;
        CreateMap<GroupDte, GroupDto>();

// Mubaadara System
        CreateMap<Mubaadara, MubaadaraDto>().ReverseMap();
        CreateMap<MubaadaraDto, MubaadaraApprovelDte>().ReverseMap();
        CreateMap<MubaadaraDetail, MubaadaraDetailDto>().ReverseMap();
        CreateMap<MubaadaraDetailDto, MubaadaraDetailsDte>().ReverseMap();
        CreateMap<MubaadaraDetailsDte, MubaadaraDetailsDte>().ReverseMap();
        CreateMap<MubaadarasWorkflow, MubaadarasWorkflowDto>().ReverseMap();
        CreateMap<MubaadaraAttachment, MubaadaraAttachment>().ReverseMap();
        CreateMap<MubaadaraUpdate, MubaadaraUpdateDto>();
        CreateMap<IdentityUsers.IdentityUserDto, IdentityUserDte>();




    }

}
