using MOD.Pms.Documents.Container;
using MOD.Pms.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace MOD.Pms.Documents
{
    public class DocumentManager : IDomainService, IDocumentManager
    {
        private readonly IRepository<MubaadaraAttachmentDocument, Guid> _mubaadaraAttachmentDocumentRepository;
        private readonly IBlobContainer<MubaadaraAttachmentContainer> _mubaadaraAttachmentDocumentContainer;

        public DocumentManager(
            IRepository<MubaadaraAttachmentDocument, Guid> mubaadaraAttachmentDocumentRepository,
            IBlobContainer<MubaadaraAttachmentContainer> mubaadaraAttachmentDocumenttblobContainer
        )
        {
            _mubaadaraAttachmentDocumentRepository = mubaadaraAttachmentDocumentRepository;
            _mubaadaraAttachmentDocumentContainer = mubaadaraAttachmentDocumenttblobContainer;
        }

        public async Task<Document> CreateDocumentAsync(byte[] content, Guid reffrenceId, Guid documentTypeId, string fileName, string contentType, ReffrenceDocumentType reffrenceType)
        {
            switch (reffrenceType)
            {
                case ReffrenceDocumentType.MubaadaraAttachment:
                    {
                        // save data into database
                        var newFile = new MubaadaraAttachmentDocument(content.Length, reffrenceId, fileName, documentTypeId, contentType);
                        newFile = await _mubaadaraAttachmentDocumentRepository.InsertAsync(newFile, true);

                        // save file into file server
                        await _mubaadaraAttachmentDocumentContainer.SaveAsync(newFile.Id.ToString(), content).ConfigureAwait(false);
                        return newFile;
                    }

            }
            return null;
        }

        public async Task UpdateDocumentAsync(Guid id, Guid documentTypeId, string fileName, string contentType, byte[] content, ReffrenceDocumentType reffrenceType)

        {
            switch (reffrenceType)
            {
                case ReffrenceDocumentType.MubaadaraAttachment:
                    {

                        await _mubaadaraAttachmentDocumentContainer.SaveAsync(id.ToString(), content, true).ConfigureAwait(false);
                        break;
                    }
            }
        }

        public async Task<BlobDte> GetBlobByRefIdAsync(Guid reffrenceId, ReffrenceDocumentType reffrenceType)
        {

            switch (reffrenceType)
            {
                case ReffrenceDocumentType.MubaadaraAttachment:
                    {

                        var document = await _mubaadaraAttachmentDocumentRepository.FindAsync(x => x.ReffrenceId == reffrenceId);
                        if (document == null)
                        {
                            return null;
                        }
                        var myfile = await _mubaadaraAttachmentDocumentContainer.GetAllBytesOrNullAsync(document.Id.ToString());
                        return new BlobDte(myfile, document.FileName, document.ContentType, document.Id);
                    }

            }
            return null;
        }

        public async Task<BlobDte> GetBlobAsync(Guid documentId, ReffrenceDocumentType reffrenceType)
        {

            switch (reffrenceType)
            {
                case ReffrenceDocumentType.MubaadaraAttachment:
                    {
                        var document = await _mubaadaraAttachmentDocumentRepository.FindAsync(x => x.Id == documentId);
                        if (document == null)
                        {
                            return null;
                        }
                        var myfile = await _mubaadaraAttachmentDocumentContainer.GetAllBytesOrNullAsync(document.Id.ToString());
                        return new BlobDte(myfile, document.FileName, document.ContentType, document.Id);
                    }

            }
            return null;
        }

    }
}
