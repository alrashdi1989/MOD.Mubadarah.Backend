using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Pms.Documents
{
    public  class BlobDto
    {
        public BlobDto(byte[] content, string name,string contentType, Guid documentId)
        {
            Content = content;
            Name = name;
            ContentType = contentType;
            DocumentId = documentId;

        }

        public byte[] Content { get; set; }
        public string Name{get;set;}
        public string ContentType{get;set;}
        public Guid DocumentId { get; set; }

    }
}
