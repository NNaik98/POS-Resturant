using Microsoft.EntityFrameworkCore;
using POSAPI;

namespace POSAPI_Tests.InMemoryDb
{
    internal class InMemoryDb
    {
        public static Model GetInMemoryDb(DbContextOptions<Model>? options = null)
        {
            var dbOptions = options != null ? options : GetDbOptions();
            var _model = new Model(dbOptions);

            return _model;
        }

        public static DbContextOptions<Model> GetDbOptions()
        {
            return new DbContextOptionsBuilder<Model>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        }
    }
}
