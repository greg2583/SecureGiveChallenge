using System;
using System.ComponentModel.DataAnnotations;

namespace SecureGiveChallenge.Models
{
	public class User
	{
		public int UserId { get; set; }

		[Required(ErrorMessage = "Please enter a first name")]
        public string? FirstName { get; set; }
        
		[Required(ErrorMessage = "Please enter a last name")]
        public string? LastName { get; set; }

        [RegularExpression(@"^[EV]+$", ErrorMessage = "Please select a user type option")]
        public Char UserType { get; set; }

	}
}
