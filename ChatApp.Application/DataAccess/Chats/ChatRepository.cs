using ChatApp.Application.Common;
using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Application.DataAccess.Chats
{
	public class ChatRepository : IChatRepository
	{
		private readonly IAppDbContext _context;

		public ChatRepository(IAppDbContext context)
		{
			_context = context;
		}

		public Task<List<Chat>> GetAllChats()
		{
			return _context.Chats.ToListAsync();
		}
	}
}
