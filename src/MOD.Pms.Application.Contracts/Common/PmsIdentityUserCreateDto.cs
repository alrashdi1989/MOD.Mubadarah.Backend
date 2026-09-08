using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;

namespace MOD.Pms.Common
{
    public class PmsIdentityUserCreateDto: IdentityUserCreateDto
    {
        public Guid UserId { get; set; }
        public string ServiceNumber { get; set; }
        public int RankOrder { get; set; }

        public string RankEnglish { get; set; }

        public string RankArabic { get; set; }

        public string ArabicName { get; set; }

        public string EnglishName { get; set; }

        public string MainUnitArabic { get; set; }

        public string MainUnitEnglish { get; set; }
        public Guid? PositionUnitId { get; set; }
        public string PositionEnglish { get; set; }
        public string PositionArabic { get; set; }
        public Guid? TenantId { get; set; }
        public byte[] Photo { get; set; }

    }
}
