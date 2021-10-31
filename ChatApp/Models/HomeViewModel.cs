using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ChatApp.Models
{
	public class HomeViewModel : BaseViewModel
	{
		public Guid UserId { get; set; }

		public List<Chat> Chats { get; set; }
	}
}
