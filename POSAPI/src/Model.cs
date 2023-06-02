using Microsoft.EntityFrameworkCore;
using POSAPI.src;
using System.Linq;


namespace POSAPI
{
    public class Model : DbContext
    {

        public DbSet<SystemUser> SystemUsers { get; set; }

        public DbSet<UserDetails> UserDetails { get; set; }

        public Model() { }

        public Model(DbContextOptions<Model> options) : base(options) { }
        
    }
}
