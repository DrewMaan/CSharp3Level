using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Accessibility;
using MailSender.TestWPF.Infrastructure.Commands;
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

		private double leftPosition;
		private double bottomPosition;

		public double LeftPosition
		{
			get => leftPosition;
			set => _ = Set(ref leftPosition, value);
		}

		private double BottomPosition
		{
			get => bottomPosition;
			set => _ = Set(ref bottomPosition, value);
		}

		private ICommand showMessageCommand;

		public ICommand ShowMessageCommand => showMessageCommand ??=
			new LambdaCommand(OnShowMessageCommandExecute, CanShowMessageCommandExecute);

		private bool CanShowMessageCommandExecute(object p) => p != null;

		private void OnShowMessageCommandExecute(object p)
		{
			MessageBox.Show(p.ToString());
		}
	}
}
