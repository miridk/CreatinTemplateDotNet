using System.Linq;
using UnikWebApiTemplate.Domain.Models;
using UnikWebApiTemplate.Domain.Repositories;
using UnikWebApiTemplate.Infrastructure.Contexts;
using UnikWebApiTemplate.Infrastructure.Models;

namespace UnikWebApiTemplate.Infrastructure.Repositories
{
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
