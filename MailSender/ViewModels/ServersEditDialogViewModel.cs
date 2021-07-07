using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Accessibility;
using MailSender.Infrastructure.Commands;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
	public class ServersEditDialogViewModel : ViewModel
	{
		public event EventHandler EditCompleted;
		public event EventHandler EditCanceled;

		private string _name;
		public string Name
		{
			get => _name;
			set => _ = Set(ref _name, value);
		}

		private string _address;
		public string Address
		{
			get => _address;
			set => _ = Set(ref _address, value);
		}

		private int _port;
		public int Port
		{
			get => _port;
			set => _ = Set(ref _port, value);
		}

		private bool _useSsl;
		public bool UseSSL
		{
			get => _useSsl;
			set => _ = Set(ref _useSsl, value);
		}

		private string _login;
		public string Login
		{
			get => _login;
			set => _ = Set(ref _login, value);
		}

		private string _password;
		public string Password
		{
			get => _password;
			set => _ = Set(ref _password, value);
		}

		private string _descriprion;
		public string Descriprion
		{
			get => _descriprion;
			set => _ = Set(ref _descriprion, value);
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
