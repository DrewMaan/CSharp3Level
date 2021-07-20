using MailSender.Models;

namespace MailSender.Interfaces
{
	public interface ISchedulerItemUserDialog
	{
		bool EditSchedulerItem(SchedulerItem schedulerItem);
		bool AddSchedulerItem(out SchedulerItem schedulerItem);
	}
}