using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSAPI.src
{
    public class SystemUser
    {
        public string Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string DisplayName { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Username { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Password { get; set; }
    }
}


