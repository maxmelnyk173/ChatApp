using ChatApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Application.DataAccess.Chats
{
	public interface IChatRepository
	{
		public Task<List<Chat>> GetAllChats();
	}
}
