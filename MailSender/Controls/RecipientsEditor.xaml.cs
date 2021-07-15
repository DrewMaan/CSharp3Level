using System.Windows.Controls;

namespace MailSender.Controls
{
	/// <summary>
	/// Логика взаимодействия для RecipientsEditor.xaml
	/// </summary>
	public partial class RecipientsEditor
	{
		public RecipientsEditor() => InitializeComponent();

		private void OnIdValidationError(object sender, ValidationErrorEventArgs e)
		{
			// Увидеть текст ошибки в сплывающей подсказке
			if(e.Action == ValidationErrorEventAction.Added)
				((Control) sender).ToolTip = e.Error.ErrorContent.ToString();
			else
				((Control)sender).ClearValue(ToolTipProperty);
		}

		private void OnNameValidationError(object sender, ValidationErrorEventArgs e)
		{
			// Увидеть текст ошибки в сплывающей подсказке
			if (e.Action == ValidationErrorEventAction.Added)
				((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
			else
				((Control)sender).ClearValue(ToolTipProperty);
		}
	}
}
