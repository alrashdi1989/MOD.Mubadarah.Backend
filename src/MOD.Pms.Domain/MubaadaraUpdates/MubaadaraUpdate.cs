using MOD.Pms.Enums;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MOD.Pms.MubaadaraUpdates
{
    public class MubaadaraUpdate : FullAuditedEntity<Guid>
    {
        public UpdateType ChangeType { get; set; }
        public string NewValue { get; set; }
        public virtual Guid MubaadaraId { get; set; }
    }
}
