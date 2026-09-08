using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MOD.Pms.Documents
{
    public class DocumentInputDto
    {
        public List<FileDto> Files { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }

        public Guid DocumentTypeId { get; set; }

    }
   
}
