using System.Windows.Input;
using MailSender.Infrastructure.Commands;
using MailSender.Interfaces;
using MailSender.Models;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
	public class ServersToolBarViewModel : MyToolBarViewModelBase<Server>
	{
		private IRepository<Server> _serversRepository;
		private IServerUserDialog _serverDialog;

		public ServersToolBarViewModel(IRepository<Server> serversRepository, IServerUserDialog serverDialog)
		{
			_serversRepository = serversRepository;
			_serverDialog = serverDialog;
			_title = "Список серверов";

			Initialize();
		}

		private void Initialize()
		{
			if(_serversRepository is null) return;
			foreach (var server in _serversRepository.GetAll()) Items.Add(server);
		}

		#region Commands
		private ICommand _addCommand;

		public ICommand AddCommand => _addCommand ??= new LambdaCommand(OnAddCommandExecute);

		private void OnAddCommandExecute(object obj)
		{
			if (_serverDialog.AddServer(out var server))
			{
				_serversRepository.Add(server);
				Items.Add(server);
			}
		}

		private ICommand _editCommand;

		public ICommand EditCommand => _editCommand ??= new LambdaCommand(OnEditCommandExecute);

		private void OnEditCommandExecute(object obj)
		{
			if (obj is not Server server) return;
			if(_serverDialog.EditServer(server))
				_serversRepository.Update(server);
		}

		private ICommand _removeCommand;

		public ICommand RemoveCommand => _removeCommand ??= new LambdaCommand(OnRemoveCommandExecute);

		private void OnRemoveCommandExecute(object obj)
		{
			if (obj is not Server server) return;
			{
				_serversRepository.Remove(server.Id);
				Items.Remove(server);
			}
		}
		#endregion
	}
}
