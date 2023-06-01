using System.ComponentModel.DataAnnotations;

namespace POSAPI.src
{
    public class SystemUser
    {
        [Key]
        public string ID { get; set; }
        public string DisplayName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

    }
}


