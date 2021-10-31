using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Application.Common
{
	public interface IAppDbContext
	{
		public DbSet<Message> Messages { get; set; }

		public DbSet<Chat> Chats { get; set; }

		public DbSet<ChatUser> ChatUsers { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
	}
}
