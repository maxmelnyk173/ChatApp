using ChatApp.Domain.Entities;
using System.Threading.Tasks;

namespace ChatApp.Application.DataAccess.Messages
{
	public interface IMessageRepository
	{
		public Task CreateMessage(Message message);
	}
}
