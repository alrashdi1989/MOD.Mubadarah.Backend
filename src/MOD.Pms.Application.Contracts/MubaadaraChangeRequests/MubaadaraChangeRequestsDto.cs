using MOD.Pms.Enums;
using MOD.Pms.Mubaadaras;
using MOD.Pms.MubadaaraDetails;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;



namespace MOD.Pms.MubaadaraChangeRequests
{
    public class MubaadaraChangeRequestsDto : FullAuditedEntityDto<Guid>
    {
        public Guid MubaadaraId { get; set; }
        public MubaadaraRequests MubaadaraRequests { get; set; }
        public string? PreviousValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime? NewEndDate { get; set; }
        public int? NewCompletionPercentage { get; set; }
        public Guid? NewStatusId { get; set; }
        public bool IsApproved { get; set; }
        public ApprovalStatus? ApprovalStatus { get; set; }
        public bool IsHaveApprovealRow { get; set; }


    }


    public class MubaadaraChangeRequestsInput
    {
        public Guid? MubaadaraId { get; set; }
        public MubaadaraRequests? MubaadaraRequests { get; set; }
        public DateTime? EndDate { get; set; }
       public int? CompletionPercentage { get; set; }
        public Guid? StatusId { get; set; }
        public bool IsHaveApprovealRow { get; set; }
        public Guid? UserIdTo { get; set; }

    }

    public class MubaadaraChangeRequestsApprovalDto
    {
        public Guid MubaadaraChangeRequestId { get; set; }
        public MubaadaraRequests? MubaadaraRequests { get; set; }
        public string? PreviousValue { get; set; }
        public string? NewValue { get; set; }
        public Guid UserIdTo { get; set; }
        public Guid UserIdFrom { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? DirectorateName { get; set; }
    }

    //public class ChallangeWorkflowInput
    //{
    //    public Guid? MubaadaraId { get; set; }
    //    public Guid? MubaadaraDetailId { get; set; }
    //    public Guid? UserIdToAction { get; set; }
    //    public String? Action { get; set; }
    //    public ApprovalStatus IsApproved { get; set; }
    //    public Classification? Classification { get; set; }
    //    public MubaadaraRequests? MubaadaraRequests { get; set; }
    //    public string Notes { get; set; }
    //    public Guid? StatusId { get; set; }
    //}

    //public class MubaadarasWorkflowUpdateInput
    //{
    //    public Guid? approvedBy { get; set; }
    //    public String? note { get; set; }
    //    public ApprovalStatus IsApproved { get; set; }
    //}
}
