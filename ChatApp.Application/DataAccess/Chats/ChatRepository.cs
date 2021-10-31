using ChatApp.Application.Common;
using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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
			return _context.Chats.Include(u => u.Users).ToListAsync();
		}

		public Task<Chat> GetChatById(Guid id)
		{
			return _context.Chats.Include(m => m.Messages)
								 .FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task CreateChat(Chat model)
		{
			var chat = await _context.Chats.FirstOrDefaultAsync(c => c.Id == model.Id);

			if (chat == null)
			{
				_context.Chats.Add(model);

				await _context.SaveChangesAsync();
			}
		}

		public async Task DeleteChat(Guid id)
		{
			var chat = await _context.Chats.FirstOrDefaultAsync(c => c.Id == id);

			if (chat != null)
			{
				_context.Chats.Remove(chat);

				await _context.SaveChangesAsync();
			}
		}
	}
}
