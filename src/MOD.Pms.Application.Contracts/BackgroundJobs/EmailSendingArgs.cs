using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.BackgroundJobs;

namespace MOD.Pms.BackgroundJobs
{
    [BackgroundJobName("SendingEmail")]
    public class EmailSendingArgs
	{
		public List<string>? EmailAddressList { get; set; }
		public string? Subject { get; set; }
		public string? Body { get; set; }

	}
}
