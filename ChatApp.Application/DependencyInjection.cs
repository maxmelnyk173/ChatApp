using ChatApp.Application.DataAccess.Chats;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IChatRepository, ChatRepository>();

            return services;
        }
    }
}
