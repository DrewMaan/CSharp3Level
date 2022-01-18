using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Interfaces
{
	public interface IMailScheduler
	{
		void Start();
		void Stop();
		SchedulerTask AddToPlan(
			DateTime time,
			Consignor consignor,
			EmailsList emails,
			Server server);
	}
}
