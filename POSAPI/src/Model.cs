using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using POSAPI.EffectiveDating;
using POSAPI.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace POSAPI
{
    public class Model : DbContext
    {
        public DbSet<SystemUser> SystemUsers { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<MenuCategory> MenuCategories { get; set; }

        public DbSet<SalesItem> SalesItems { get; set; }

        public DbSet<OpenItem> OpenItems { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Snapshot> Snapshots { get; set; }

        public DbSet<MenuItemSnapshot> MenuItemSnapshots { get; set; }

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
                        var role = new Role() { Id = GetNewId<Role>(), Name = reqRole };
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
                        var cat = new MenuCategory() { Id = GetNewId<MenuCategory>(), Name = reqCat };
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
