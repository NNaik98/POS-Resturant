using POSAPI.EffectiveDating;
using System.Collections.Generic;

namespace POSAPI.src
{
    public class MenuItem : SalesItem
    {
        public string Description { get; set; }

        public MenuCategory Category { get; set; }

        public IEnumerable<MenuItemSnapshot> Versions { get; set; }
    }

    public class MenuItemSnapshot : Snapshot
    {
        public string Id { get; set; }

        public float Price { get; set; }
    }
}
