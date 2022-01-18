using MailSender.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Models
{
	public class EmailsList : BaseEntity
	{
		public ICollection<Recipient> Recipients { get; set; } = new HashSet<Recipient>();
		public Message Message { get; set; }
	}

	public class SchedulerTask : BaseEntity
	{
		public DateTime Time { get; set; }
		public Consignor Consignor { get; set; }
		public EmailsList Emails { get; set; }
		public Server Server { get; set; }
	}
}
