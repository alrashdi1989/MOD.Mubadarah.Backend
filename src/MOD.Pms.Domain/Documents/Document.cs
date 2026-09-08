using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MOD.Pms.Documents
{
    public class Document : FullAuditedAggregateRoot<Guid>
    {
        public Guid ReffrenceId { get;  set; }
        public Guid DocumentTypeId { get; protected set; }
        public long FileSize { get; protected set; }
        public string? FileName { get; protected set; }
        public string? ContentType { get; protected set; }

        protected Document()
        {

        }

      
     
    }
}