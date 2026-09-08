using MOD.Pms.Enums;
using MOD.Pms.Mubaadaras;
using MOD.Pms.MubadaaraDetails;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;



namespace MOD.Pms.MubaadaraWorkflows
{
    public class MubaadarasWorkflowDto : FullAuditedEntityDto<Guid>
    {
        public Guid MubaadaraId { get; set; }
        public Guid? UserIdFrom { get; set; }
        public String? UserNameFrom { get; set; }
        public Guid? UserIdTo { get; set; }
        public String? UserNameTo { get; set; }
        public String? Action { get; set; }
        public Classification? Classification { get; set; }
        public Guid? MubaadaraApprovalId { get; set; }
        public DateTime ActionDate { get; set; }
        public bool? IsActionDone { get; set; }
        public MubaadaraDto Mubaadara { get; set; }

        //-----------
        //public Guid? ApprovedBy { get; set; }
        //public string? PreviousValue { get; set; }
        //public string? Notes { get; set; }
        //public string? NewValue { get; set; }
        //public DateTime? NewEndDate { get; set; }
        //public WorkflowStatus? WorkflowStatus { get; set; }
        //public MubaadaraDetails.MubaadaraDetail? MubaadaraDetail { get; set; }
        //public MubaadaraRequests MubaadaraRequests { get; set; }
        // public Guid? MubaadaraDetailId { get; set; }
    }

    public class ChallangeWorkflowInput
    {
        public Guid? MubaadaraId { get; set; }
        public Guid? MubaadaraDetailId { get; set; }
        public Guid? UserIdToAction { get; set; }
        public String? Action { get; set; }
        public ApprovalStatus IsApproved { get; set; }
        public Classification? Classification { get; set; }
        public MubaadaraRequests? MubaadaraRequests { get; set; }
        public string Notes { get; set; }
        public Guid? StatusId { get; set; }
    }

    public class MubaadarasWorkflowUpdateInput
    {
        public Guid? approvedBy { get; set; }
        public String? note { get; set; }
        public ApprovalStatus IsApproved { get; set; }
    }
}
