using MOD.Pms.MubaadaraAttachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD.Pms.Documents
{
    public class MubaadaraAttachmentDocument : Document
    {
        public MubaadaraAttachmentDocument(
         long fileSize,
         Guid mubaadaraAttachmentId,
          string fileName,
          Guid documentTypeId,
          string contentType)

        {
            FileSize = fileSize;
            MubaadaraAttachmentId = mubaadaraAttachmentId;
            FileName = fileName;
            DocumentTypeId = documentTypeId;
            ContentType = contentType;
        }
        public MubaadaraAttachment? MubaadaraAttachment { get; set; }
        public Guid MubaadaraAttachmentId
        {
            get => ReffrenceId;
            set => ReffrenceId = value;
        }
    }
}
