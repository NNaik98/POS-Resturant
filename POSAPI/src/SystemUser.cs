using System.ComponentModel.DataAnnotations;

namespace POSAPI.src
{
    public class SystemUser
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}


