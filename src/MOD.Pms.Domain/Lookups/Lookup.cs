using MOD.Pms.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using Volo.Abp.Domain.Entities.Auditing;

namespace MOD.Pms.Lookups
{
    public class Lookup: FullAuditedEntity<Guid>
    {
        public Lookup(Guid id):base(id)
        {
        }
        public Lookup()
        {

        }
        public string? ArabicName { get; set; }
        public string? EnglishName { get; set; }
        public int Priority { get; set; }
        public Guid? LookupId { get; set; }
        public Lookup? Type { get; set; }
        public TabName? TabName { get; set; }
        public int ? WarningPeriod { get; set; }
        public int? AlertPeriod { get; set; }
        public FileType? FileType { get; set; }
        public ICollection<Lookup>  Types { get; set; } = new List<Lookup>();

    }
}
