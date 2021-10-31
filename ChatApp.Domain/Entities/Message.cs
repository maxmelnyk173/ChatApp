using System;

namespace ChatApp.Domain.Entities
{
	public class Message
	{
		public Guid Id { get; set; }

		public string UserName { get; set; }

		public string Text { get; set; }

		public DateTime Timestamp { get; set; }

		public Guid ChatId { get; set; }

		public virtual Chat Chat { get; set; }
	}
}
