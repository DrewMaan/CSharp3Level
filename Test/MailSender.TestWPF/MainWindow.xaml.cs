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
			using var service = new EmailSendService(LoginEdit.Text, PasswordEdit.SecurePassword, txtbSubjectMessage.Text, txtbMessage.Text);

			try
			{
				service.SendMessage();
				MessageBox.Show("Почта успешно отправлена", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch (SmtpException smtp_exception)
			{
				var errorWindow = new SendErrorWindow(smtp_exception.Message);
				errorWindow.ShowDialog();
			}
		}

		private void ButtonSend_OnClickStackPanel(object sender, RoutedEventArgs e)
		{
			using var service = new EmailSendService(LoginEditStackPanel.Text, PasswordEditStackPanel.SecurePassword, txtbSubjectMessageStackPanel.Text, txtbMessageStackPanel.Text);

			try
			{
				service.SendMessage();
				MessageBox.Show("Почта успешно отправлена", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch (SmtpException smtp_exception)
			{
				var errorWindow = new SendErrorWindow(smtp_exception.Message);
				errorWindow.ShowDialog();
			}
		}

		private void ButtonSend_OnClickDockPanel(object sender, RoutedEventArgs e)
		{
			using var service = new EmailSendService(LoginEditDockPanel.Text, PasswordEditDockPanel.SecurePassword, txtbSubjectMessageDockPanel.Text, txtbMessageDockPanel.Text);

			try
			{
				service.SendMessage();
				MessageBox.Show("Почта успешно отправлена", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch (SmtpException smtp_exception)
			{
				var errorWindow = new SendErrorWindow(smtp_exception.Message);
				errorWindow.ShowDialog();
			}
		}
	}
}
