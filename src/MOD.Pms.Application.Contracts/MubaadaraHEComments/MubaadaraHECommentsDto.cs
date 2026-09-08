using MOD.Pms.Documents;
using MOD.Pms.Lookups;
using MOD.Pms.Mubaadaras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace MOD.Pms.MubaadaraHEComments
{
    public class MubaadaraHECommentsDto : FullAuditedEntity<Guid>
    {
        public Guid MubaadaraId { get; set; }
        public Guid? UserIdFrom { get; set; }
        public String? UserNameFrom { get; set; }
        public Guid UserIdTo { get; set; }
        public String? UserNameTo { get; set; }
        public String? Comment { get; set; }
        public DateTime? ActionDate { get; set; }
        public bool? IsActionDone { get; set; }


    }
}
