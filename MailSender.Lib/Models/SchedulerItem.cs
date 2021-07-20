using System;
using MailSender.Models.Base;

namespace MailSender.Models
{
	public class SchedulerItem : BaseEntity
	{
		public TimeSpan TimeSend { get; set; }

		public string MessageBody { get; set; }
	}
}
