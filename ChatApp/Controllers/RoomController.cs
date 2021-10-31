using ChatApp.Application.DataAccess.Chats;
using ChatApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
	public class RoomController : Controller
	{
		private readonly IChatRepository _chatRepository;

		public RoomController(IChatRepository chatRepository)
		{
			_chatRepository = chatRepository;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Index(Guid id)
		{
			var model = new RoomViewModel();

			model.IsAuth = User.Identity.IsAuthenticated;

			if (!model.IsAuth)
			{
				return RedirectToAction("Index");
			}

			model.Chat = await _chatRepository.GetChatById(id);

			return View(model);
		}
	}
}
