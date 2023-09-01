using System.ComponentModel.DataAnnotations;

namespace GuessBender.Client.Auth
{
	public class RegisterModel
	{
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
        [Required(ErrorMessage = "Telephone is required")]
        public string Telephone { get; set; }
        [EmailAddress]
		[Required(ErrorMessage = "Email is required")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }

	}
}
