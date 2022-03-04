namespace $safeprojectname$.Repositories
{
    using System.Linq;
    using $ext_safeprojectname$.Domain.Models;
    using $safeprojectname$.Contexts;
    using $safeprojectname$.Models;
    using $ext_safeprojectname$.Domain.Repositories;

    public class TestRepository : ITestRepository
    {
        public TestRepository(
            TestDbContext context
            )
        {
            _Context = context;
        }

        private readonly TestDbContext _Context;

        public TestDomain CreateTest(TestDomain domain)
        {
            var testEf = new TestEf
            {
                Name = domain.Name
            };

            _Context.Tests.Add(testEf);

            _Context.SaveChanges();

            return domain;
        }

        public TestDomain GetTest(string name)
        {
            var ef = _Context.Tests.FirstOrDefault(test => test.Name == name);
            return TestDomain.Restore(ef.Name);
        }
    }
}
