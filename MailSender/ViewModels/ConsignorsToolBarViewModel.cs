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
		private readonly ConsignorsRepository consignorsRepository;
		private readonly IConsignorUserDialog consignorUserDialog;

		public ConsignorsToolBarViewModel(ConsignorsRepository consignorsRepository,
			IConsignorUserDialog consignorUserDialog)
		{
			this.consignorsRepository = consignorsRepository;
			this.consignorUserDialog = consignorUserDialog;

			_title = "Отправители";

			Initialize();
		}

		private void Initialize()
		{
			foreach (var consignor in consignorsRepository.GetAll()) Items.Add(consignor);
		}

		#region Commands
		private ICommand _addCommand;

		public ICommand AddCommand => _addCommand ??= new LambdaCommand(OnAddCommandExecute);

		private void OnAddCommandExecute(object obj)
		{
			if (consignorUserDialog.AddConsignor(out var consignor))
			{
				consignorsRepository.Add(consignor);
				Items.Add(consignor);
			}
		}

		private ICommand _editCommand;

		public ICommand EditCommand => _editCommand ??= new LambdaCommand(OnEditCommandExecute);

		private void OnEditCommandExecute(object obj)
		{
			if (obj is not Consignor consignor) return;
			if (consignorUserDialog.EditConsignor(consignor))
				consignorsRepository.Update(consignor);
		}

		private ICommand _removeCommand;

		public ICommand RemoveCommand => _removeCommand ??= new LambdaCommand(OnRemoveCommandExecute);

		private void OnRemoveCommandExecute(object obj)
		{
			if (obj is not Consignor consignor) return;
			{
				consignorsRepository.Remove(consignor);
				Items.Remove(consignor);
			}
		}
		#endregion
	}
}