using System.ComponentModel.DataAnnotations;

namespace POSAPI.src.RequestModels
{
    public class RegisterRequest
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^(((server|admin)($|(,(server|admin)))))$", ErrorMessage = "Role must be in the list: (server, admin)")]
        public string Role { get; set; }
    }
}
