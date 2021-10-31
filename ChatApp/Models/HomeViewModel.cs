using ChatApp.Domain.Entities;
using System.Collections.Generic;

namespace ChatApp.Models
{
	public class HomeViewModel : BaseViewModel
	{
		public List<Chat> Chats { get; set; }
	}
}
