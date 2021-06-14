using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MailSender.TestWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ButtonSend_OnClick(object sender, RoutedEventArgs routedEventArgs)
		{
			using var service = new EmailSendService(LoginEdit.Text, PasswordEdit.SecurePassword);
			try
			{
				service.SendMessage();
				MessageBox.Show("Почта успешно отправлена", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch (SmtpException smtp_exception)
			{
				MessageBox.Show(smtp_exception.Message, "Ошибка при отправке почты", MessageBoxButton.OK, MessageBoxImage.Error);
			}
        }
	}
}
