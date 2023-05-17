using System.Collections.Generic;

namespace SecureGiveChallenge.Models
{
	public class SampleData
	{
		private static List<User> usersList = new List<User>();
		public static IEnumerable<User> UsersList
		{
			get { return usersList; }
		}
		public static void Create(User newUser)
		{
			usersList.Add(newUser);
		}
	}
}
