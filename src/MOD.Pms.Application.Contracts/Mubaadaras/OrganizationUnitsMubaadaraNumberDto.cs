using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MOD.Pms.Mubaadaras
{
    public class OrganizationUnitsMubaadaraNumberDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string ArabicName { get; set; }
        public int Count { get; set; }
        public string? Code { get; set; }

    }
}
