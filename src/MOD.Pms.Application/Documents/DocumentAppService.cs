using Microsoft.Extensions.Configuration;
using MOD.Pms.Enums;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MOD.Pms.Documents
{
    public class DocumentAppService : PmsAppService, IDocumentAppService
    {
        private readonly IRepository<Document, Guid> _documentRepository;
        private readonly IDocumentManager _documentManager;
        private readonly IConfiguration _configuration;

        public DocumentAppService(
            IRepository<Document, Guid> documentRepository,
            IDocumentManager documentManager,
            IConfiguration configuration)
        {
            _documentRepository = documentRepository;
            _documentManager = documentManager;
            _configuration = configuration;
        }

        public async Task<DocumentDto> GetAsync(Guid refrenceId)
        {
            var document = await _documentRepository.GetAsync(refrenceId);
            var documentDto = ObjectMapper.Map<Document, DocumentDto>(document);
            return documentDto;
        }

        public async Task<BlobDto> GetBlobByRefIdAsync(Guid reffrenceId, ReffrenceDocumentType reffrenceType)
        {
            var document = await _documentManager.GetBlobByRefIdAsync(reffrenceId, reffrenceType);
            if (document == null)
            {
                return null;
            }
            return ObjectMapper.Map<BlobDte, BlobDto>(document);
        }

        public async Task UpdateDocumentAsync(Guid documentId, FileDto file)
        {
            await _documentManager.UpdateDocumentAsync(documentId, PmsConsts.PdfDocumentTypeId, documentId.ToString(), file.ContentType, file.Content, ReffrenceDocumentType.MubaadaraAttachment);
        }
    }
}
