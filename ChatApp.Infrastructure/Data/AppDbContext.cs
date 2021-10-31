using ChatApp.Application.Common;
using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Infrastructure.Data
{
	public class AppDbContext : IdentityDbContext<User>, IAppDbContext
	{
		public AppDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Message> Messages { get; set; }

		public DbSet<Chat> Chats { get; set; }

		public DbSet<ChatUser> ChatUsers { get; set; }

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
