using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MailSender
{
	/// <summary>
	/// Логика взаимодействия для ConsignorEditDialog.xaml
	/// </summary>
	public partial class ConsignorEditDialog : Window
	{
		private ConsignorEditDialog() => InitializeComponent();

		private void OnButtonClick(object sender, RoutedEventArgs e)
		{
			DialogResult = !((Button)e.OriginalSource).IsCancel;
			Close();
		}

		public static bool ShowDialog(string title, ref string name, ref string address, ref string description)
		{
			var window = new ConsignorEditDialog()
			{
				Title = title,
				ConsignorName = { Text = name },
				ConsignorAddress = { Text = address },
				ConsignorDescription = { Text = description },
				Owner = Application.Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive)
			};

			if (window.ShowDialog() != true) return false;

			name = window.ConsignorName.Text;
			address = window.ConsignorAddress.Text;
			description = window.ConsignorDescription.Text;

			return true;
		}

		public static bool Create(out string name, out string address, out string description)
		{
			name = null;
			address = null;
			description = null;

			return ShowDialog("Добавить отправителя", ref name, ref address, ref description);
		}
	}
}
