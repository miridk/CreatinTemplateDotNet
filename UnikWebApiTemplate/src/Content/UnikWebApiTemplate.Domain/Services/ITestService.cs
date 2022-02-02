using UnikWebApiTemplate.Domain.Models;

namespace UnikWebApiTemplate.Domain.Services
{
    public interface ITestService
    {
        TestDomain CreateTest(TestDomain domain);
        TestDomain GetTest(string name);
    }
}