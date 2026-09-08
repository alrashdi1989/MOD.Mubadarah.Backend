using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;

namespace MOD.Pms.BackgroundJobs
{
	public class EmailSendingJob : BackgroundJob<EmailSendingArgs>, ITransientDependency
	{
		private readonly IEmailSender _emailSender;

		public EmailSendingJob(IEmailSender emailSender)
		{
			_emailSender = emailSender;
		}

		public override  void  Execute(EmailSendingArgs args)
		{
			foreach (string emailAddress in args.EmailAddressList)
			{
				 _emailSender.SendAsync(
					emailAddress,
					args.Subject,
					args.Body
				);
			}

		}
	}
}

