using System.ComponentModel.Design;
using System.Windows.Input;
using MailSender.Infrastructure.Commands;
using MailSender.Interfaces;
using MailSender.Models;
using MailSender.Services;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
	public class ConsignorsToolBarViewModel : MyToolBarViewModelBase<Consignor>
	{
		private readonly IRepository<Consignor> _consignorsRepository;
		private readonly IConsignorUserDialog _consignorUserDialog;

		public ConsignorsToolBarViewModel(IRepository<Consignor> consignorsRepository,
			IConsignorUserDialog consignorUserDialog)
		{
			_consignorsRepository = consignorsRepository;
			_consignorUserDialog = consignorUserDialog;

			_title = "Отправители";

			Initialize();
		}

		private void Initialize()
		{
			foreach (var consignor in _consignorsRepository.GetAll()) Items.Add(consignor);
		}

		#region Commands
		private ICommand _addCommand;

		public ICommand AddCommand => _addCommand ??= new LambdaCommand(OnAddCommandExecute);

		private void OnAddCommandExecute(object obj)
		{
			if (_consignorUserDialog.AddConsignor(out var consignor))
			{
				_consignorsRepository.Add(consignor);
				Items.Add(consignor);
			}
		}

		private ICommand _editCommand;

		public ICommand EditCommand => _editCommand ??= new LambdaCommand(OnEditCommandExecute);

		private void OnEditCommandExecute(object obj)
		{
			if (obj is not Consignor consignor) return;
			if (_consignorUserDialog.EditConsignor(consignor))
				_consignorsRepository.Update(consignor);
		}

		private ICommand _removeCommand;

		public ICommand RemoveCommand => _removeCommand ??= new LambdaCommand(OnRemoveCommandExecute);

		private void OnRemoveCommandExecute(object obj)
		{
			if (obj is not Consignor consignor) return;
			{
				_consignorsRepository.Remove(consignor.Id);
				Items.Remove(consignor);
			}
		}
		#endregion
	}
}