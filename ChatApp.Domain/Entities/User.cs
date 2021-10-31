using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ChatApp.Domain.Entities
{
	public class User : IdentityUser
	{
		public ICollection<ChatUser> Chats { get; set; }
	}
}
