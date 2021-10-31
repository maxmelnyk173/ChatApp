using ChatApp.Application.DataAccess.Chats;
using ChatApp.Application.DataAccess.Messages;
using ChatApp.Domain.Entities;
using ChatApp.Hubs;
using ChatApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
	public class RoomController : Controller
	{
		private readonly IHubContext<ChatHub> _chat;

		private readonly IMessageRepository _messageRepository;

		private readonly IChatRepository _chatRepository;

		public RoomController(IChatRepository chatRepository,
							IHubContext<ChatHub> chat,
							IMessageRepository messageRepository)
		{
			_chatRepository = chatRepository;
			_chat = chat;
			_messageRepository = messageRepository;
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

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> SendMessage([FromBody] MessageViewModel model)
		{
			var message = new Message()
			{
				UserName = User.Identity.Name,
				ChatId = model.RoomId,
				Text = model.Text,
				Timestamp = DateTime.Now
			};

			await _messageRepository.CreateMessage(message);

			await _chat.Clients.Groups(model.RoomName)
							   .SendAsync("ReceiveMessage", message);

			return Ok();
		}
	}
}
