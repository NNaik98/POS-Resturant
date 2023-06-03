using Microsoft.EntityFrameworkCore.Metadata.Internal;
using POSAPI.Security;
using POSAPI.src.RequestModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSAPI.src
{
    public class SystemUser
    {
        public string Id { get; protected set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string DisplayName { get; protected set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Username { get; protected set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Password { get; protected set; }

        public virtual List<Role> Roles { get; protected set; }

        public SystemUser()
        {

        }

        public SystemUser(string id, RegisterRequest details, List<Role> roles)
        {
            Id = id;
            DisplayName = details.DisplayName;
            Username = details.Username;
            Roles = roles;
            Password = SecurityHelper.GetHash(details.Password, Username + Id);
        }
    }
}


