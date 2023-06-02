using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSAPI.src
{
    public class MenuCategory
    {
        public string Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        public virtual IEnumerable<MenuItem> Items {get;set;}
    }
}
