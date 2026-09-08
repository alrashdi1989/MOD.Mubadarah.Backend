using MOD.Pms.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MOD.Pms.MubaadaraAttachments
{
    public class MubaadaraAttachmentDto : FullAuditedEntityDto<Guid>
    {
        public string AttachmentName { get; set; } 
        public string? ReferenceNumber { get; set; }
        public Guid MubaadaraId { get; set; }



        public List<FileDto> Files { get; set; } = new List<FileDto>();
        public FileDto File { get; set; }




    }

}
