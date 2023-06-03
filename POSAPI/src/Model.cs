using Microsoft.EntityFrameworkCore;
using POSAPI.EffectiveDating;
using POSAPI.src;
using System;
using System.Collections.Generic;
using System.Linq;


namespace POSAPI
{
    public class Model : DbContext
    {
        public DbSet<SystemUser> SystemUsers { get; protected set; }

        public DbSet<Role> Roles { get; protected set; }

        public DbSet<MenuCategory> MenuCategories { get; protected set; }

        public DbSet<SalesItem> SalesItems { get; protected set; }

        public DbSet<OpenItem> OpenItems { get; protected set; }

        public DbSet<MenuItem> MenuItems { get; protected set; }

        public DbSet<Snapshot> Snapshots { get; protected set; }

        public DbSet<MenuItemSnapshot> MenuItemSnapshots { get; protected set; }

        public Model() { }

        public Model(DbContextOptions<Model> options) : base(options) { }

        public string GetNewId<T>() where T : class
        {

            var guid = "";
            bool isAlreadyUsed = false;
            var retryCount = 0;
            do
            {
                try
                {
                    guid = Guid.NewGuid().ToString();
                    isAlreadyUsed = Set<T>().AsEnumerable().Any(o => o.GetType().GetProperty("Id").Equals(guid));
                }
                catch (Exception)
                {
                    if (retryCount < 3)
                    {
                        retryCount++;
                        continue;
                    }
                }
            }
            while (isAlreadyUsed);

            return guid.Replace("-", "");
        }

        public void Init()
        {
            try
            {
                var requiredRoles = new List<string> { "Admin", "Server" };
                foreach (var reqRole in requiredRoles)
                {
                    if (Roles.Any(r => r.Name == reqRole) != true) // doesn't exist yet
                    {
                        var role = new Role(id: GetNewId<Role>(), reqRole);
                        Roles.Add(role);
                    }
                }

                var requiredCategories = new List<string> { "Starters",
                                                            "Tandoori",
                                                            "Chicken",
                                                            "Lamb",
                                                            "Seafood",
                                                            "Vegetarian",
                                                            "Biryani",
                                                            "Kids",
                                                            "Tandoori Bread",
                                                            "Basmati rice",
                                                            "Sundries",
                                                            "Drinks",
                                                            "Lees pub" };
                foreach (var reqCat in requiredCategories)
                {
                    if (MenuCategories.Any(r => r.Name == reqCat) != true) // doesn't exist yet
                    {
                        var cat = new MenuCategory(id: GetNewId<MenuCategory>(), reqCat);
                        MenuCategories.Add(cat);
                    }
                }

                SaveChanges();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
