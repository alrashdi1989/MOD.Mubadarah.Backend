using MOD.Pms.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;



namespace MOD.Pms.MubaadaraApprovals
{
    public class MubaadaraApprovalDto : FullAuditedEntityDto<Guid>
    {
        public Guid ReffrenceId { get; set; }
        public int Priority { get; set; }
        public Guid UserId { get; set; }
        public bool IsActionDone { get; set; }
        public DateTime ActionlDate { get; set; }
        public string? SenderNotes { get; set; }
        public string? ReceiverNotes { get; set; }
        public MubaadaraRequestsReply MubaadaraRequestsReply { get; set; }
    }


    public class MubaadaraApprovalInput
    {
        public Guid? ReffrenceId { get; set; }
        public Guid UserId { get; set; }
        public string Notes { get; set; }
        public string? SenderNotes { get; set; }
    }

    public class MubaadaraApprovalActionInput
    {
        public Guid? mubaadaraApprovalId { get; set; }
        public Guid? ForwardUserId { get; set; }
        public Guid UserId { get; set; }
        public string? ReceiverNotes { get; set; }
        public MubaadaraRequestsReply MubaadaraRequestsReply { get; set; }
    }

}
