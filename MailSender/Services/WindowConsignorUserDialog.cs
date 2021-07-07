using MailSender.Interfaces;
using MailSender.Models;
using MailSender.ViewModels;
using MailSender.Views;

namespace MailSender.Services
{
	public class WindowConsignorUserDialog : IConsignorUserDialog
	{
		public bool AddConsignor(out Consignor consignor)
		{
			consignor = new Consignor();

			var model = new ConsignorsEditDialogViewModel
			{
				Name = null,
				Address = null,
				Descriprion = null
			};

			var view = new ConsignorEditDialog
			{
				DataContext = model
			};

			model.EditCompleted += (s, e) =>
			{
				view.DialogResult = true;
				view.Close();
			};

			model.EditCanceled += (s, e) =>
			{
				view.DialogResult = false;
				view.Close();
			};

			if (view.ShowDialog() != true)
				return false;

			consignor.Name = model.Name;
			consignor.Address = model.Address;
			consignor.Description = model.Descriprion;

			return true;
		}

		public bool EditConsignor(Consignor consignor)
		{
			var model = new ConsignorsEditDialogViewModel
			{
				Name = consignor.Name,
				Address = consignor.Address,
				Descriprion = consignor.Description
			};

			var view = new ConsignorEditDialog
			{
				DataContext = model
			};

			model.EditCompleted += (s, e) =>
			{
				view.DialogResult = true;
				view.Close();
			};

			model.EditCanceled += (s, e) =>
			{
				view.DialogResult = false;
				view.Close();
			};

			if (view.ShowDialog() != true)
				return false;

			consignor.Name = model.Name;
			consignor.Address = model.Address;
			consignor.Description = model.Descriprion;

			return true;
		}
	}
}