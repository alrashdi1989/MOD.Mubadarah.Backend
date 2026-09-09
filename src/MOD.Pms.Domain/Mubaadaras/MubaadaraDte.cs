using MOD.Pms.Enums;
using MOD.Pms.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MOD.Pms.Mubaadaras
{
    public class MubaadaraApprovelDte 
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public Guid TypeId { get; set; }
        public MubaadaraTypes Category { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public Months Month { get; set; }
        public Guid? TenantId { get; set; }
        public Guid? UnitId { get; set; }
        public Guid? ManagerId { get; set; }
        public Guid? HeadManagerId { get; set; }
        public Guid StatusId { get; set; }
        public decimal CompletionPercentage { get; set; }
        public decimal Amount { get; set; }
        public string? UnitHierarchyAr { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public ApprovalStatus IsApproved { get; set; }
        public Guid? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }


    }
}
