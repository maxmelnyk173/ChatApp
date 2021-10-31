using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
	public class AccountController : Controller
	{
		private const string _password = "test";

		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;

		public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> Login()
		{
			var name = HttpContext.Request.Form.FirstOrDefault().Value.ToString();

			name = name.Trim();

			if (name != null)
			{
				var user = await _userManager.FindByNameAsync(name);

				if (user == null)
				{
					user = new User
					{
						Id = Guid.NewGuid().ToString(),
						UserName = name
					};

					await _userManager.CreateAsync(user, _password);
				}

				await _signInManager.PasswordSignInAsync(user, _password, false, false);
			}

			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}
	}
}
