using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender
{
	/// <summary>
	/// Логика взаимодействия для ServerEditDialog.xaml
	/// </summary>
	public partial class ServerEditDialog : Window
	{
		private ServerEditDialog() => InitializeComponent();



		private void OnButtonClick(object sender, RoutedEventArgs e)
		{
			DialogResult = !((Button) e.OriginalSource).IsCancel;
			Close();
		}

		private void OnPortTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!(sender is TextBox textBox) || textBox.Text == "") return;

			e.Handled = !int.TryParse(textBox.Text, out _);
		}

		public static bool ShowDialog(string title, ref string name, ref string address, ref int port, ref bool ssl,
			ref string description, ref string login, ref string password)
		{
			var window = new ServerEditDialog()
			{
				Title = title,
				ServerName = {Text = name},
				ServerAddress = {Text = address},
				ServerPort = {Text = port.ToString()},
				ServerSSL = {IsChecked = ssl},
				ServerDescription = {Text = description},
				UserLogin = {Text = login},
				UserPassword = {Password = password},
				Owner = Application.Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive)
			};

			if (window.ShowDialog() != true) return false;

			name = window.ServerName.Text;
			address = window.ServerAddress.Text;
			port = int.Parse(window.ServerPort.Text);
			ssl = window.ServerSSL.IsChecked != null && (bool)window.ServerSSL.IsChecked;
			description = window.ServerDescription.Text;

			login = window.UserLogin.Text;
			password = window.UserPassword.Password;

			return true;
		}

		public static bool Create(out string name, out string address, out int port, out bool ssl,
			out string description, out string login, out string password)
		{
			name = null;
			address = null;
			port = 25;
			ssl = false;
			description = null;
			login = null;
			password = null;

			return ShowDialog("Создать сервер", ref name, ref address, ref port, ref ssl, ref description, ref login,
				ref password);
		}
	}
}
