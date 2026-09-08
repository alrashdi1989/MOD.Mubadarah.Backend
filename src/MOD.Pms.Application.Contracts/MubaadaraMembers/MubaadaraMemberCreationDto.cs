using MOD.Pms.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace MOD.Pms.MubaadaraMembers
{
    public class MubaadaraMemberCreationDto 
    {       
        public Guid MubaadaraId { get; set; }      
        public Guid[] UserId { get; set; }
        public MubaadaraMemberPermission MubaadaraMemberPermission { get; set; }
        public MubaadaraStructures? MubaadaraStructures { get; set; }
    }
  
}
