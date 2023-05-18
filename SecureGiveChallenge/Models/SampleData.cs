using System.Collections.Generic;
using System.Linq;

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
			if (usersList.Count == 0)
			{
				newUser.UserId = 1;
			}
			else
			{
                var maxID = usersList.Max(k => k.UserId);
                newUser.UserId = maxID + 1;
            }			
			usersList.Add(newUser);
		}
        public static void Delete(User user)
        {
			try
			{
				usersList.Remove(user);
			}
			catch (Exception ex)
			{

			}
            
        }

		public static void Update(User user, int UserId)
		{
			try
			{
                User? foundUser = SampleData.UsersList.FirstOrDefault(k => k.UserId == UserId);
                foundUser.FirstName = user.FirstName;
                foundUser.LastName = user.LastName;
                foundUser.UserType = user.UserType;
            }
			catch (Exception ex) { }
            
        }
    }
}
