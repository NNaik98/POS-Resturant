using POSAPI.EffectiveDating;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSAPI.src
{
    public class MenuItem : SalesItem
    {
        [Column(TypeName = "varchar(255)")]
        public string Description { get; protected set; }

        [Required]
        public virtual MenuCategory Category { get; protected set; }

        [Required]
        public virtual IEnumerable<MenuItemSnapshot> Versions { get; protected set; }
    }

    public class MenuItemSnapshot : Snapshot
    {
        public double Price { get; protected set; }

        [Required]
        public virtual MenuItem Item { get; protected set; }
    }
}
