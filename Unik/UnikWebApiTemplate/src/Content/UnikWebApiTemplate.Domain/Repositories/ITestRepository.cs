using UnikWebApiTemplate.Domain.Models;

namespace UnikWebApiTemplate.Domain.Repositories
{
    public interface ITestRepository
    {
        TestDomain CreateTest(TestDomain domain);
        TestDomain GetTest(string name);
    }
}