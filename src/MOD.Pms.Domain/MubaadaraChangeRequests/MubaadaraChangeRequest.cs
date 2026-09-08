using MOD.Pms.Enums;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MOD.Pms.MubaadaraChangeRequests
{
    public class MubaadaraChangeRequest : FullAuditedEntity<Guid>
    {
        public Guid MubaadaraId { get;   set; }
        public MubaadaraRequests MubaadaraRequests { get; set; }
        public string? PreviousValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime? NewEndDate { get; set; }
        public int? NewCompletionPercentage { get; set; }
        public Guid? NewStatusId { get; set; }
        public bool IsApproved { get;   set; }
        public bool IsHaveApprovealRow{ get; set; }
        public ApprovalStatus? ApprovalStatus { get; set; }

    }
}