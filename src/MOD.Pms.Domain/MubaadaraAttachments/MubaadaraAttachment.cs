using MOD.Pms.Documents;
using MOD.Pms.Lookups;
using MOD.Pms.Mubaadaras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace MOD.Pms.MubaadaraAttachments
{
    public class MubaadaraAttachment : FullAuditedEntity<Guid>
    {
        public string? AttachmentName { get; set; }
        public string? ReferenceNumber { get; set; }


        //FK
        public Guid MubaadaraId { get; set; }
        public Mubaadara? Mubaadara { get; set; }
        public Lookup? ProjectAttachmentType { get; set; }

        public ICollection<MubaadaraAttachmentDocument>? Documents { get; set; }

    }
}
