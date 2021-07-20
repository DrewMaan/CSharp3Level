using System;
using System.Windows.Input;
using MailSender.Infrastructure.Commands;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
	public class SchedulerItemEditDialogViewModel : ViewModel
	{
		public event EventHandler EditCompleted;
		public event EventHandler EditCanceled;

		private string _messageBody;

		public string MessageBody
		{
			get => _messageBody;
			set => _ = Set(ref _messageBody, value);
		}

		#region Command OkCommand - Ok

		/// <summary>Ok</summary>
		private LambdaCommand _okCommand;

		/// <summary>Ok</summary>
		public ICommand OkCommand => _okCommand ??= new(OnOkCommandExecuted);

		/// <summary>Логика выполнения - Ok</summary>
		private void OnOkCommandExecuted(object p)
		{
			EditCompleted?.Invoke(this, EventArgs.Empty);
		}

		#endregion

		#region Command CancelCommand - Cancel

		/// <summary>Cancel</summary>
		private LambdaCommand _cancelCommand;

		/// <summary>Cancel</summary>
		public ICommand CancelCommand => _cancelCommand ??= new(OnCancelCommandExecuted);

		/// <summary>Логика выполнения - Cancel</summary>
		private void OnCancelCommandExecuted(object p)
		{
			EditCanceled?.Invoke(this, EventArgs.Empty);
		}

		#endregion
	}
}
