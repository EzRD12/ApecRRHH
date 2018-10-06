using System.ComponentModel.DataAnnotations;

namespace Web.Api.Models
{
    public sealed class LoginRequest
    {
        /// <summary>
        /// Represent an user email
        /// </summary>
        [Required(ErrorMessage = "EmailRequired")]
        public string Email { get; set; }

        /// <summary>
        /// An user password
        /// </summary>
        [Required(ErrorMessage = "PasswordRequired")]
        public string Password { get; set; }
    }
}
