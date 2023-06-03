using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSAPI.src
{
    public class MenuCategory
    {
        public string Id { get; protected set; }

        [Column(TypeName = "varchar(255)")]
        public string Name { get; protected set; }

        public virtual IEnumerable<MenuItem> Items { get; set; }

        public MenuCategory()
        {

        }

        public MenuCategory(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
