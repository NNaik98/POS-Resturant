using System.ComponentModel.DataAnnotations;

namespace POSAPI.src.RequestModels
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
