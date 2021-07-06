using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.ViewModels.Base
{
	public class MyToolBarViewModelBase : ViewModel
	{
		private readonly string _header;

		MyToolBarViewModelBase(string header)
		{
			_header = header;
		}

		public string Header => _header;
	}
}
