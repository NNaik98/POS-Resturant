using POSAPI.EffectiveDating;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSAPI.src
{
    public class MenuItem : SalesItem
    {
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; }

        [Required]
        public virtual MenuCategory Category { get; set; }

        [Required]
        public virtual IEnumerable<MenuItemSnapshot> Versions { get; set; }
    }

    public class MenuItemSnapshot : Snapshot
    {
        public double Price { get; set; }

        [Required]
        public virtual MenuItem Item { get; set; }
    }
}
