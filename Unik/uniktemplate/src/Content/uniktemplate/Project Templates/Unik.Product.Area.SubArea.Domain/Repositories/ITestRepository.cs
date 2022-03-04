namespace $safeprojectname$.Repositories
{
    using $safeprojectname$.Models;

    public interface ITestRepository
    {
        TestDomain CreateTest(TestDomain domain);
        TestDomain GetTest(string name);
    }
}