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
			using var client = new SmtpClient(ServiceParameters.Host, ServiceParameters.Port)
			{
				UseDefaultCredentials = false,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				EnableSsl = true,
				Credentials = new NetworkCredential
				{
					UserName = Login.Text,
					Password = Password_edit.Text
				}
			};
			try
			{
				client.Send(ServiceParameters.Message);
				MessageBox.Show("Почта успешно отправлена", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch (SmtpException smtp_exception)
			{
				MessageBox.Show(smtp_exception.Message, "Ошибка при отправке почты", MessageBoxButton.OK, MessageBoxImage.Error);
			}
        }
	}
}
