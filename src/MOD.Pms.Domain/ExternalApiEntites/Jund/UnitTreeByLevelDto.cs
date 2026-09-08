using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD.Pms.ExternalApiEntites.Jund
{
    public class UnitTreeByLevelDto
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string? Code { get; set; }
        public string? ArabicUnitName { get; set; }
        public string DisplayName { get; set; }
        public string? EnglishUnitName { get; set; }
        public Guid? TenantId { get; set; }
        public bool IsDeleted { get; set; }
        public int Level { get; set; }
    }


}
