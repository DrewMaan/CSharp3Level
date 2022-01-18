using MailSender.Models.Base;
using System;

namespace MailSender.Models
{
	public class SchedulerTask : BaseEntity
	{
		public DateTime Time { get; set; }
		public Consignor Consignor { get; set; }
		public EmailsList Emails { get; set; }
		public Server Server { get; set; }
	}
}
