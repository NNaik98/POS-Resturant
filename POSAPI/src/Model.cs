using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DotNetCoreAPI
{
    public class Model : DbContext
    {

        public Model() { }

        public Model(DbContextOptions<Model> options) : base(options) { }

    }
}
