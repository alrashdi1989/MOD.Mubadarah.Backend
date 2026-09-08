using MOD.Pms.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MOD.Pms.MubaadaraHistories
{
    public class MubaadaraHistory : FullAuditedEntity<Guid>
    {
        public Guid WorkflowId { get; set; }
        public MubaadaraRequests? ColumnName { get; set; }
        public int? CompletionPercentageOV { get; set; }
        public int? CompletionPercentageNV { get; set; }
        public DateTime? EndDateOV { get; set; }
        public DateTime? EndDateNV { get; set; }
        public Guid? StatusIdOV { get; set; }
        public Guid? StatusIdNV { get; set; }
    }
}
