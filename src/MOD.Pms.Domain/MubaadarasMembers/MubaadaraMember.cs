using MOD.Pms.Enums;
using MOD.Pms.Mubaadaras;
using System;

using Volo.Abp.Domain.Entities.Auditing;

namespace MOD.Pms.MubaadarasMembers
{
    public class MubaadaraMember : FullAuditedEntity<Guid>
    {
        public Mubaadara? Mubaadara { get; set; }
        public Guid MubaadaraId { get; set; }
        public Guid UserId { get; set; }
        public MubaadaraMemberPermission MubaadaraMemberPermission { get; set; }
        public MubaadaraStructures? MubaadaraStructures { get; set; }
    }
}
