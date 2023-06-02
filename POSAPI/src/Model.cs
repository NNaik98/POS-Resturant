using Microsoft.EntityFrameworkCore;
using POSAPI.EffectiveDating;
using POSAPI.src;
using System.Linq;


namespace POSAPI
{
    public class Model : DbContext
    {
        public DbSet<SystemUser> SystemUsers { get; set; }

        public DbSet<MenuCategory> MenuCategories { get; set; }
        
        public DbSet<SalesItem> SalesItems { get; set; }

        public DbSet<OpenItem> OpenItems { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }
        
        public DbSet<Snapshot> Snapshots { get; set; }
        
        public DbSet<MenuItemSnapshot> MenuItemSnapshots { get; set; }

        public Model() { }

        public Model(DbContextOptions<Model> options) : base(options) { }
        
    }
}
