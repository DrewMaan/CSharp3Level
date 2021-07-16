using System.Collections.Generic;
using MailSender.Models.Base;

namespace MailSender.Models
{
	public class MessageTask : BaseEntity
	{
		public Consignor Consignor { get; set; }

		public IList<Recipient> Recipients { get; set; }

		public Message Message { get; set; }
	}
}