using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Emailing.Templates;
using Volo.Abp.TextTemplating;
using Volo.Abp.DependencyInjection;
using Scriban;
using System.Net.Mail;
using System.Net.Security;

namespace MOD.Pms.Emailing
{
    public class EmailTemplateDefinitionProvider : TemplateDefinitionProvider
    {
        public override void Define(ITemplateDefinitionContext context)
        {
            //var emailLayoutTemplate = context.GetOrNull(StandardEmailTemplates.Message);
            //emailLayoutTemplate
            //    .WithVirtualFilePath(
            //      "/Emailing/Templates/EmailTemplate.tpl",
            //        isInlineLocalized: true
            //    );
            //context.Add(emailLayoutTemplate);

            context.Add(
                new TemplateDefinition("mubaadaraEmailLayoutTemplate")
                    .WithVirtualFilePath(
                    "/Emailing/Templates/MubaadaraEmailTemplate.tpl",
                        isInlineLocalized: true));

            context.Add(
                new TemplateDefinition("EmailLayoutTemplate")
                    .WithVirtualFilePath(
                   "/Emailing/Templates/EmailTemplate.tpl",
                        isInlineLocalized: true));

        }
    }
}
 