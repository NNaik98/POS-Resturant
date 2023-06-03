using POSAPI.EffectiveDating;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public virtual List<MenuItemSnapshot> Versions { get; set; }


        public MenuItem()
        {

        }

        public MenuItem(string snapShotID, MenuItemRequest itemToCopy, MenuCategory cat)
        {
            copyItem(snapShotID, itemToCopy,cat);
        }

        public void copyItem(string snapShotID, MenuItemRequest itemToCopy, MenuCategory cat)
        {
            Id = itemToCopy.Id;
            Name = itemToCopy.Name;
            Description = itemToCopy.Description;
            Category = cat;
            MenuItemSnapshot snapshot = new(snapShotID,itemToCopy.Price, itemToCopy.EffectiveDate);

            Versions = new() { snapshot };
        }

      
    }

    public class MenuItemSnapshot : Snapshot
    {
        public double Price { get; set; }

        [Required]
        public virtual MenuItem Item { get; set; }


        public MenuItemSnapshot()
        {
           

        }  
        public MenuItemSnapshot(string id, double price , DateTime EffectiveDate ) : base( id, EffectiveDate )
        {
            Price = price;
        }
       
      


    }

}
