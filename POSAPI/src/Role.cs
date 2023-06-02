using System.ComponentModel.DataAnnotations;

namespace POSAPI.src
{
    public class Role
    {
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
