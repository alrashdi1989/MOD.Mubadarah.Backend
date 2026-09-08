using Microsoft.AspNetCore.Authorization;
using MOD.Pms.Documents;
using MOD.Pms.Documents.Container;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using static MOD.Pms.Permissions.PmsPermissions;

namespace MOD.Pms.MubaadaraAttachments
{
    [Authorize]

    public class MubaadaraAttachmentAppService : ApplicationService, IMubaadaraAttachmentAppService, ITransientDependency
    {
        private readonly IRepository<MubaadaraAttachment, Guid> _mubaadaraAttachmentRepository;
        private readonly IDocumentManager _documentManager;
        private readonly IRepository<MubaadaraAttachmentDocument, Guid> _mubaadaraAttachmentDocumentRepository;
        private readonly IBlobContainer<MubaadaraAttachmentContainer> _mubaadaraAttachmentDocumentContainer;

        public MubaadaraAttachmentAppService(
            IRepository<MubaadaraAttachment, Guid> mubaadaraAttachmentRepository,
            IDocumentManager documentManager,
            IRepository<MubaadaraAttachmentDocument, Guid> mubaadaraAttachmentDocumentRepository,
            IBlobContainer<MubaadaraAttachmentContainer> mubaadaraAttachmentDocumentContainer
        )
        {
            _mubaadaraAttachmentRepository = mubaadaraAttachmentRepository;
            _documentManager = documentManager;
            _mubaadaraAttachmentDocumentRepository = mubaadaraAttachmentDocumentRepository;
            _mubaadaraAttachmentDocumentContainer = mubaadaraAttachmentDocumentContainer;
        }


        public async Task<MubaadaraAttachmentDto> CreateAsync(object input)
        {
            var mubaadaraAttachmentInput = new MubaadaraAttachmentDto();
            JsonConvert.PopulateObject(input.ToString(), mubaadaraAttachmentInput);
            var mubaadaraAttachment = ObjectMapper.Map<MubaadaraAttachmentDto, MubaadaraAttachment>(mubaadaraAttachmentInput);
            mubaadaraAttachment = await _mubaadaraAttachmentRepository.InsertAsync(mubaadaraAttachment);
            Guid documentTypeId = PmsConsts.PhotoDocumentTypeId;

            if (mubaadaraAttachmentInput.File != null && mubaadaraAttachmentInput.File.Content.Length > 0)
            {
                await _documentManager.CreateDocumentAsync(mubaadaraAttachmentInput.File.Content, mubaadaraAttachment.Id, documentTypeId, mubaadaraAttachment.AttachmentName, mubaadaraAttachmentInput.File.ContentType, Enums.ReffrenceDocumentType.MubaadaraAttachment);
            }
            var mubaadaraAttachmentDto = ObjectMapper.Map<MubaadaraAttachment, MubaadaraAttachmentDto>(mubaadaraAttachment);
            return mubaadaraAttachmentDto;
        }

        public async Task<MubaadaraAttachmentDto> GetAsync(Guid id)
        {
            var mubaadaraAttachment = await _mubaadaraAttachmentRepository.GetAsync(id);
            var mubaadaraAttachmentDto = ObjectMapper.Map<MubaadaraAttachment, MubaadaraAttachmentDto>(mubaadaraAttachment);
            return mubaadaraAttachmentDto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _mubaadaraAttachmentRepository.DeleteAsync(id);
            await _mubaadaraAttachmentDocumentRepository.DeleteAsync(id);
            await _mubaadaraAttachmentDocumentContainer.DeleteAsync(id.ToString());
        }

        public async Task<MubaadaraAttachmentDto> UpdateAsync(Guid id, object input)
        {
            var mubaadaraAttachment = await _mubaadaraAttachmentRepository.GetAsync(id);
            JsonConvert.PopulateObject(input.ToString(), mubaadaraAttachment);
            mubaadaraAttachment = await _mubaadaraAttachmentRepository.UpdateAsync(mubaadaraAttachment);
            var mubaadaraAttachmentDto = ObjectMapper.Map<MubaadaraAttachment, MubaadaraAttachmentDto>(mubaadaraAttachment);
            return mubaadaraAttachmentDto;

            //UPDATE ProjectAttachment DOCUMENT
            var mubaadaraAttachmentInput = new MubaadaraAttachmentDto();
            JsonConvert.PopulateObject(input.ToString(), mubaadaraAttachmentInput);
            Guid documentTypeId = PmsConsts.PhotoDocumentTypeId;


            var mubaadaraAttachmentDocument = await _mubaadaraAttachmentDocumentRepository.GetAsync(c => c.ReffrenceId == id);
            ObjectMapper.Map<MubaadaraAttachmentDto, MubaadaraAttachmentDocument>(mubaadaraAttachmentInput, mubaadaraAttachmentDocument);
            await _mubaadaraAttachmentDocumentRepository.UpdateAsync(mubaadaraAttachmentDocument);

            if (mubaadaraAttachmentInput.Files.Count > 0)
            {
                //UPDATE FILE
                foreach (var file in mubaadaraAttachmentInput.Files)
                {
                    if (file.ContentType.Contains("pdf"))
                    {
                        documentTypeId = PmsConsts.PdfDocumentTypeId;
                    }
                    await _documentManager.CreateDocumentAsync(file.Content, mubaadaraAttachment.Id, documentTypeId, mubaadaraAttachment.AttachmentName, file.ContentType, Enums.ReffrenceDocumentType.MubaadaraAttachment);
                };
            }
        }
    }
}
