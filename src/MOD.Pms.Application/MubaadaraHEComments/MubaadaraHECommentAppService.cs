using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOD.Pms.Common;
using MOD.Pms.Enums;
using MOD.Pms.Localization;
using MOD.Pms.MubaadaraHEComments;
using MOD.Pms.Mubaadaras;
using MOD.Pms.MubaadarasMembers;
using MOD.Pms.MubaadaraWorkflows;
using MOD.Pms.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Emailing.Smtp;
using Volo.Abp.Emailing.Templates;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;
using Volo.Abp.TextTemplating;
using static MOD.Pms.Permissions.PmsPermissions;

namespace MOD.Pms.MubaadaraAttachments
{
    [Authorize]

    public class MubaadaraHECommentAppService : ApplicationService, IMubaadaraHECommentAppService
    {
        private readonly IRepository<MubaadaraHEComment, Guid> _mubaadaraHECommentRepository;
        private readonly ITemplateRenderer _templateRenderer;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly SmtpEmailSender _emailSender;
        private readonly IDataFilter _dataFilter;
        private readonly IRepository<Mubaadara, Guid> _mubaadaraRepository;
        private readonly ILookupRepository _lookupsRepository;
        private readonly IRepository<MubaadarasWorkflow, Guid> _mubaadaraWorkflowRepository;
        private readonly IRepository<MubaadaraMember, Guid> _mubaadaraMembersRepository;
        private readonly IStringLocalizer<PmsResource> _l;

        public MubaadaraHECommentAppService(
            IRepository<MubaadaraHEComment, Guid> mubaadaraHECommentRepository,
            IDataFilter dataFilter,
            IRepository<MubaadarasWorkflow, Guid> mubaadaraWorkflowRepository,
            SmtpEmailSender emailSender,
            ITemplateRenderer templateRenderer,
            IRepository<Mubaadara, Guid> mubaadaraRepository,
            ILookupRepository lookupsRepository,
            IRepository<MubaadaraMember, Guid> mubaadaraMembersRepository,
            IIdentityUserRepository identityUserRepository,
            IStringLocalizer<PmsResource> l)
        {
            _mubaadaraWorkflowRepository = mubaadaraWorkflowRepository;
            _mubaadaraMembersRepository = mubaadaraMembersRepository;
            _mubaadaraHECommentRepository = mubaadaraHECommentRepository;
            _templateRenderer = templateRenderer;
            _identityUserRepository = identityUserRepository;
            _emailSender = emailSender;
            _mubaadaraRepository = mubaadaraRepository;
            _lookupsRepository = lookupsRepository;
            _dataFilter = dataFilter;
            _l = l;
        }


        public async Task<CommonOperationResultDto<MubaadaraHECommentsDto>> CreateAsync(object input)
        {
            var mubaadaraHEComments = new MubaadaraHEComment();
            JsonConvert.PopulateObject(input.ToString(), mubaadaraHEComments);
            mubaadaraHEComments = await _mubaadaraHECommentRepository.InsertAsync(mubaadaraHEComments);
            var mubaadaraHECommentsdto = ObjectMapper.Map<MubaadaraHEComment, MubaadaraHECommentsDto>(mubaadaraHEComments);
            using (_dataFilter.Disable<IMultiTenant>())
            {
                // Mubaadara/Lookup lookups must run inside the multi-tenancy
                // filter disable too, not just the email step below - with
                // it enabled, EF Core's tenant query filter can exclude a
                // row that genuinely exists in the table (wrong/no tenant
                // match for the current request), and GetAsync throws
                // EntityNotFoundException even though the row is right
                // there in the database.
                var mubaadara = (await _mubaadaraRepository.GetAsync(mubaadaraHECommentsdto.MubaadaraId));
                var mubaadaraType = (await _lookupsRepository.GetAsync(mubaadara.TypeId)).ArabicName;
                var emailBody = await _templateRenderer.RenderAsync(
                                  "mubaadaraEmailLayoutTemplate", new
                                  {
                                      title = "منظومة خطة سير العمل السنوية",
                                      name = "تم التعليق بواسطة ",
                                      mubaadaraname = "أمين عام وزارة الدفاع ",
                                      type = "العنوان ",
                                      mubaadaratype = string.Format(mubaadara.Title),
                                      messagetype = "التعليق",
                                      message = string.Format(mubaadaraHECommentsdto.Comment),
                                  }); ;
                var user = await _identityUserRepository.GetAsync(mubaadaraHECommentsdto.UserIdTo);
                try
                {
                    // A failed notification email shouldn't roll back the comment itself -
                    // ApplicationService methods run in an implicit transactional unit of
                    // work, so letting an SmtpException bubble up here would undo the
                    // InsertAsync above too, even though the comment was otherwise valid.
                    // This is what was happening whenever the configured SMTP server
                    // (mail.mod.saf) isn't reachable, e.g. in local development.
                    await _emailSender.SendAsync(
                                                      user.Email,
                                                         "تمت إضافة تعليق",
                                                         emailBody
                                                 );
                }
                catch (Exception ex)
                {
                    Logger.LogWarning(ex, "Failed to send HEComment notification email to {Email}", user.Email);
                }
            }
            await CreateMubaadaraWorkflow(mubaadaraHECommentsdto);
            return new CommonOperationResultDto<MubaadaraHECommentsDto>("تمت إضافة التعليق بنجاح و أرسال الاإشعار بالبريد الالكتروني", true);
        }

        public async Task<CommonOperationResultDto<MubaadaraHECommentsDto>> CreateMubaadaraWorkflow(MubaadaraHECommentsDto MubaadaraHECommentsDto)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {

                var mubaadaraMembers = (await _mubaadaraMembersRepository.GetQueryableAsync()).Where(c => c.MubaadaraId == MubaadaraHECommentsDto.MubaadaraId).Select(c => c.UserId);
                foreach (Guid mubaadaraMember in mubaadaraMembers)
                {
                    var UserFromData = await _identityUserRepository.GetAsync((Guid)CurrentUser.Id);
                    var UserToData = await _identityUserRepository.GetAsync(mubaadaraMember);
                    var mubaadarasWorkflow = new MubaadarasWorkflow()
                    {
                        MubaadaraId = MubaadaraHECommentsDto.MubaadaraId,
                        UserIdFrom = (Guid)CurrentUser.Id,
                        UserNameFrom = $"{UserFromData.GetProperty<string>("PositionArabic", "PositionArabic")} - {UserFromData.GetProperty<string>("RankArabic", "RankArabic")} - {UserFromData.GetProperty<string>("ArabicName", "ArabicName")}",
                        UserIdTo = mubaadaraMember,
                        UserNameTo = $"{UserToData.GetProperty<string>("PositionArabic", "PositionArabic")} - {UserToData.GetProperty<string>("RankArabic", "RankArabic")} - {UserToData.GetProperty<string>("ArabicName", "ArabicName")}",
                        Action = _l["AddHEComments"].ToString(),
                        Classification = Enums.Classification.ToAction,
                    };
                    await _mubaadaraWorkflowRepository.InsertAsync(mubaadarasWorkflow);
                }
                ;

                return new CommonOperationResultDto<MubaadaraHECommentsDto>(_l["Message"], true);
            }
        }
    }
}
