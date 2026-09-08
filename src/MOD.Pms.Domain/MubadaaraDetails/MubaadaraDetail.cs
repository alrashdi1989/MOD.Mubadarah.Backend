using MOD.Pms.Enums;
using MOD.Pms.MubaadaraWorkflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace MOD.Pms.MubaadaraDetails
{
    public class MubaadaraDetail: FullAuditedEntity<Guid>
    {
        public Guid MubaadaraId { get; set; }
        public string? Challenge { get; set; }
        public string? Note { get; set; }
        public string? Solution { get; set; }
        public MubaadaraChallengeStatus ApproveStatus { get; set; }
    }
}
