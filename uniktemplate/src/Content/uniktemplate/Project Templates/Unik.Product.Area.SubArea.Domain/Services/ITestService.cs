using $safeprojectname$.Models;

namespace $safeprojectname$.Services
{
    public interface ITestService
    {
        TestDomain CreateTest(TestDomain domain);
        TestDomain GetTest(string name);
    }
}