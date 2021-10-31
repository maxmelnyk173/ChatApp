using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChatApp.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ChatApp"));

			services.AddIdentity<User, IdentityRole>(o =>
			{
				o.Password.RequireDigit = false;
				o.Password.RequireLowercase = false;
				o.Password.RequireNonAlphanumeric = false;
				o.Password.RequireUppercase = false;
				o.Password.RequiredLength = 4;
			})
			.AddEntityFrameworkStores<AppDbContext>()
			.AddDefaultTokenProviders();

			services.ConfigureApplicationCookie(config =>
			{
				config.Cookie.Name = "ChatApp";
				config.LoginPath = "/";
				config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
			});

			return services;
		}
	}
}
