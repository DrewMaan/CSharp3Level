﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Models
{
	public class SchedulerItem
	{
		public TimeSpan TimeSend { get; set; }

		public string MessageBody { get; set; }
	}
}
