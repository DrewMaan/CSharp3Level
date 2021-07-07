using MailSender.Models;

namespace MailSender.Interfaces
{
	public interface IConsignorUserDialog
	{
		bool AddConsignor(out Consignor consignor);

		bool EditConsignor(Consignor consignor);
	}
}
