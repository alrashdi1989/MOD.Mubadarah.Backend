using MOD.Pms.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD.Pms.MubadaaraDetails
{
    public class MubaadaraDetailsDte
    {
        public virtual Guid? mubadaaraDetailId { get; set; }
        public virtual Guid? mubaadaraWorkflowId { get; set; }
        public virtual Guid MubaadaraId { get; set; }
        public virtual String? Challenge { get; set; }
         public virtual String? Note { get; set; }
        public virtual String? Solution { get; set; }
        public virtual Guid? UserIdTo { get; set; }
        public MubaadaraChallengeStatus ApproveStatus { get; set; }


    };

}

