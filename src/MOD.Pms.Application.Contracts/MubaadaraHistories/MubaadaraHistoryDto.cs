using MOD.Pms.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MOD.Pms.MubaadaraHistories
{
    public class MubaadaraHistoryDto : FullAuditedEntityDto<Guid>
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

    public class MubaadaraHistoryInput
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
