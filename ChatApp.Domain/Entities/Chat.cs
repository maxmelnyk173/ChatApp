﻿using System;
using System.Collections.Generic;

namespace ChatApp.Domain.Entities
{
	public class Chat
	{
		public Chat()
		{
			Messages = new List<Message>();

			Users = new List<ChatUser>();
		}

		public Guid Id { get; set; }

		public string Name { get; set; }

		public ICollection<Message> Messages { get; set; }

		public ICollection<ChatUser> Users { get; set; }
	}
}
