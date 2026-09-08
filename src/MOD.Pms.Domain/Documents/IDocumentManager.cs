 
using MOD.Pms.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MOD.Pms.Documents
{
    public interface IDocumentManager
    {

        Task<Document> CreateDocumentAsync(byte[] content, Guid ReffrenceId, Guid documentTypeId, string name, string contentType, ReffrenceDocumentType reffrenceType);
        Task<BlobDte> GetBlobAsync(Guid documentId, ReffrenceDocumentType reffrenceType);
        Task<BlobDte> GetBlobByRefIdAsync(Guid ReffrenceId, ReffrenceDocumentType reffrenceType);
        Task UpdateDocumentAsync(Guid id, Guid documentTypeId, string fileName, string contentType, byte[] content, ReffrenceDocumentType reffrenceType);
    }
}