using MOD.Pms.Enums;
using MOD.Pms.Lookups;
using MOD.Pms.MubaadaraDetails;
using MOD.Pms.Mubaadaras;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;


namespace MOD.Pms.MubaadaraWorkflows
{
    public class MubaadarasWorkflow : FullAuditedEntity<Guid>

    {
        public Guid MubaadaraId { get; set; }
        public Guid? UserIdFrom { get; set; }
        public String? UserNameFrom { get; set; }
        public Guid? UserIdTo { get; set; }
        public String? UserNameTo { get; set; }
        public String? Action { get; set; }
        public Classification? Classification { get; set; }
        public Guid? MubaadaraApprovalId { get; set; }
        public DateTime? ActionDate { get; set; }
        public bool? IsActionDone { get; set; }
        public Mubaadara? Mubaadara { get; set; }




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
}
