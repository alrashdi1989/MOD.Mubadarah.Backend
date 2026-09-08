using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace MOD.Pms.Documents
{
   public class DocumentDto : FullAuditedEntity<Guid>
    {
        public Guid ReffrenceId { get;  set; }
        public Guid DocumentTypeId { get;  set; }
        public long FileSize { get;  set; }
        public string FileName { get;  set; }
        public string ContentType { get;  set; }
        public string src { get; set; }
    }
}
