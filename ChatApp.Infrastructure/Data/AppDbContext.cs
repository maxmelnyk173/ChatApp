using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Data
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public AppDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Message> Messages { get; set; }

		public DbSet<Chat> Chats { get; set; }

		public DbSet<ChatUser> ChatUsers { get; set; }
	}
}
