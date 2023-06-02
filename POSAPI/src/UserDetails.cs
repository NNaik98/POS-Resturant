using System.ComponentModel.DataAnnotations;

namespace POSAPI.src
{
    public class UserDetails
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Username { get; set; }
       
        [Required]
        public string Password { get; set; }
       
        [Required]
        public string Role { get; set; }
    }
}
