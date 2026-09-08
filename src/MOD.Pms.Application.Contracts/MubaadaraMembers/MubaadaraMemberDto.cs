using MOD.Pms.Enums;
using System;
using Volo.Abp.Application.Dtos;


namespace MOD.Pms.MubaadarasMembers
{
    public class MubaadaraMemberDto: FullAuditedEntityDto<Guid>
    {
        public Guid MubaadaraId { get; set; }
        public Guid UserId { get; set; }
        public MubaadaraMemberPermission MubaadaraMemberPermission { get; set; }
        public MubaadaraStructures? MubaadaraStructures { get; set; }
    }

}


