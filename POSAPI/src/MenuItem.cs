using POSAPI.EffectiveDating;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

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


        public MenuItem()
        {

        }

        public MenuItem(MenuItemRequest itemToCopy, MenuCategory cat)
        {
            CopyItemRequest(itemToCopy, cat);
        }

        public void CopyItemRequest(MenuItemRequest itemToCopy, MenuCategory cat)
        {
            Id = itemToCopy.Id;
           
            Name = itemToCopy.Name;
            Description = itemToCopy.Description;
            /*double Price = itemToCopy.Price;
            */Category = cat;
        }
    }

    public class MenuItemSnapshot : Snapshot
    {
        public double Price { get; set; }

        [Required]
        public virtual MenuItem Item { get; set; }
    }

}
