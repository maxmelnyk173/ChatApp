using ChatApp.Application.DataAccess.Chats;
using ChatApp.Domain.Entities;
using ChatApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IChatRepository _chatRepository;

		public HomeController(IChatRepository chatRepository)
		{
			_chatRepository = chatRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var model = new HomeViewModel();

			model.IsAuth = User.Identity.IsAuthenticated;

			if (model.IsAuth)
			{
				model.Chats = await _chatRepository.GetAllChats();
			}

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> CreateRoom()
		{
			var name = HttpContext.Request.Form.FirstOrDefault().Value.ToString();

			await CreateChat(name);

			return RedirectToAction("Index");
		}

		private async Task<Chat> CreateChat(string name)
		{
			var chat = new Chat()
			{
				Id = Guid.NewGuid(),
				Name = name
			};

			await _chatRepository.CreateChat(chat);

			return chat;
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> DeleteRoom(Guid id)
		{
			await _chatRepository.DeleteChat(id);

			return RedirectToAction("Index");
		}

		private Guid GetCurentUserId()
		{
			return Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
		}
	}
}
