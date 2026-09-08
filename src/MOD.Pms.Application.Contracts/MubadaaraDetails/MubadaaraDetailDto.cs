using MOD.Pms.Enums;
using MOD.Pms.MubaadaraWorkflows;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MOD.Pms.MubadaaraDetails
{
    public class MubaadaraDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid MubaadaraId { get; set; }
        public string Challenge { get; set; }
        public string Note { get; set; }
        public string Solution { get; set; }
        public MubaadaraChallengeStatus ApproveStatus { get; set; }
        public Guid UserIdTo { get; set; }




    }
}
