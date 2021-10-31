using ChatApp.Application.Common;
using ChatApp.Domain.Entities;
using System.Threading.Tasks;

namespace ChatApp.Application.DataAccess.Messages
{
	public class MessageRepository : IMessageRepository
	{
		private readonly IAppDbContext _context;

		public MessageRepository(IAppDbContext context)
		{
			_context = context;
		}

		public async Task CreateMessage(Message message)
		{
			_context.Messages.Add(message);

			await _context.SaveChangesAsync();
		}
	}
}
