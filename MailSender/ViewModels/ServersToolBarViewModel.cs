using System.Windows.Input;
using MailSender.Infrastructure.Commands;
using MailSender.Interfaces;
using MailSender.Models;
using MailSender.Servcies;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
	public class ServersToolBarViewModel : MyToolBarViewModelBase<Server>
	{
		private ServersRepository serversRepository;
		private IServerUserDialog serverDialog;

		public ServersToolBarViewModel(ServersRepository serversRepository, IServerUserDialog serverDialog)
		{
			this.serversRepository = serversRepository;
			this.serverDialog = serverDialog;
			_title = "Список серверов";

			Initialize();
		}

		private void Initialize()
		{
			if(serversRepository is null) return;
			foreach (var server in serversRepository.GetAll()) Items.Add(server);
		}

		#region Commands
		private ICommand _addCommand;

		public ICommand AddCommand => _addCommand ??= new LambdaCommand(OnAddCommandExecute);

		private void OnAddCommandExecute(object obj)
		{
			if (serverDialog.AddServer(out var server))
			{
				serversRepository.Add(server);
				Items.Add(server);
			}
		}

		private ICommand _editCommand;

		public ICommand EditCommand => _editCommand ??= new LambdaCommand(OnEditCommandExecute);

		private void OnEditCommandExecute(object obj)
		{
			if (obj is not Server server) return;
			if(serverDialog.EditServer(server))
				serversRepository.Update(server);
		}

		private ICommand _removeCommand;

		public ICommand RemoveCommand => _removeCommand ??= new LambdaCommand(OnRemoveCommandExecute);

		private void OnRemoveCommandExecute(object obj)
		{
			if (obj is not Server server) return;
			{
				serversRepository.Remove(server);
				Items.Remove(server);
			}
		}
		#endregion
	}
}
