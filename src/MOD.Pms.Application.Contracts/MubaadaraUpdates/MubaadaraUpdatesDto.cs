using MOD.Pms.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MOD.Pms.MubaadaraUpdates
{
    public class MubaadaraUpdateDto : FullAuditedEntityDto<Guid>
    {
        public UpdateType ChangeType { get; set; }
        public string NewValue { get; set; }
        public virtual Guid MubaadaraId { get; set; }
    }


}
