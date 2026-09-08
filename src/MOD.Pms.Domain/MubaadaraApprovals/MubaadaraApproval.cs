using MOD.Pms.Enums;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MOD.Pms.MubaadaraApprovals
{
    public class MubaadaraApproval : FullAuditedEntity<Guid>
    {
        public Guid ReffrenceId { get;   set; }
        public int Priority { get;   set; }
        public Guid UserId { get; set; }
        public bool IsActionDone { get;   set; }
        public DateTime ActionlDate { get; set; }
        public string? SenderNotes { get;   set; }
        public string? ReceiverNotes { get; set; }
        public MubaadaraRequestsReply? MubaadaraRequestsReply { get; set; }
    }
}