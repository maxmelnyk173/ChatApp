using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Application.DataAccess.Chats
{
	public interface IChatRepository
	{
		public Task<List<Chat>> GetAllChats();

		public Task<Chat> GetChatById(Guid id);

		public Task CreateChat(Chat model);

		public Task DeleteChat(Guid id);

		public Task AddChatUser(ChatUser model);
	}
}
