﻿using System;

namespace ChatApp.Domain.Entities
{
	public class ChatUser
	{
		public Guid Id { get; set; }

		public Guid UserId { get; set; }

		public User User { get; set; }

		public Guid ChatId { get; set; }

		public Chat Chat { get; set; }
	}
}
