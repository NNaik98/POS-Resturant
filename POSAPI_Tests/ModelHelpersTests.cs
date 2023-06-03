using POSAPI.src;

using static POSAPI_Tests.InMemoryDb.InMemoryDb;

namespace POSAPI_Tests
{
    public class ModelHelpersTests
    {
        [Fact]
        public void GetNewId()
        {
            var options = GetDbOptions();
            using var model_t1 = GetInMemoryDb(options);
            model_t1.SystemUsers.Add(new()
            {
                Id = "randomtext",
                DisplayName = "user",
                Username = "user",
                Password = "pass",
                Roles = new() { }
            }) ;
            model_t1.SaveChanges();                                                 // user created in a transaction, e.g. the register endpoint

            using var model_t2 = GetInMemoryDb(options);
            for (var i = 0; i < 10; i++)
            {
                var result = model_t2.GetNewId<SystemUser>();
                Assert.False(model_t2.SystemUsers.Any(u => u.Id == result));        // unique id generated - not ideal test with just 10 iterations - probably a waste
            }
        }

        [Fact]
        public void Init()
        {
            var options = GetDbOptions();
            using var model_t1 = GetInMemoryDb(options);
            model_t1.Init();                                                        // create some of the data if missing
            model_t1.SaveChanges();

            using var model_t2 = GetInMemoryDb(options);
            
            Assert.True(model_t2.MenuCategories.Any());
            Assert.True(model_t2.MenuCategories.Any());
        }
    }
}
