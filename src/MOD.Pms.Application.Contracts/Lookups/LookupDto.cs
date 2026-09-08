using MOD.Pms.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MOD.Pms.Lookups
{
    public class LookupDto:FullAuditedEntityDto<Guid>
    {
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public int Priority { get; set; }
        public Guid? LookupId { get; set; }
        public TabName? TabName { get; set; }
        public FileType? FileType { get; set; }
        public int? WarningPeriod { get; set; }
        public int? AlertPeriod { get; set; }
    }

    public class EnumLookupDto : FullAuditedEntityDto<Guid>
    {
        public int IntId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
       
    }
}
