using System;

namespace ChatApp.Models
{
	public class MessageViewModel
	{
		public Guid RoomId { get; set; }

		public string RoomName { get; set; }

		public string Text { get; set; }
	}
}
