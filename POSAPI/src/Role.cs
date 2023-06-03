using System.ComponentModel.DataAnnotations;

namespace POSAPI.src
{
    public class Role
    {
        public string Id { get; protected set; }

        [Required]
        public string Name { get; protected set; }

        public Role()
        {

        }

        public Role(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
