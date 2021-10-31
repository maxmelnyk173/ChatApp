using ChatApp.Application.DataAccess.Chats;
using ChatApp.Application.DataAccess.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IChatRepository, ChatRepository>();
			services.AddScoped<IMessageRepository, MessageRepository>();

			return services;
		}
	}
}
