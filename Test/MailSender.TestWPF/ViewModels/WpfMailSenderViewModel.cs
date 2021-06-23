using System.ComponentModel;
using MailSender.TestWPF.ViewModels.Base;

namespace MailSender.TestWPF.ViewModels
{
	public class WpfMailSenderViewModel : ViewModel
	{
		private string title = "Главное окно приложения!";

		/// <summary>
		/// Заголовок окна
		/// </summary>
		public string Title
		{
			get => title;
			set => _ = Set(ref title, value);
		}
	}
}
