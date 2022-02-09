namespace $safeprojectname$.Services
{
    using AutoMapper;
    using $safeprojectname$.Models;
    using $safeprojectname$.Repositories;

    public class TestService : ITestService
    {
        private readonly ITestRepository _Repository;
        private readonly IMapper _Mapper;

        public TestService(
            ITestRepository repository,
            IMapper mapper
            )
        {
            _Repository = repository;
            _Mapper = mapper;
        }

        public TestDomain CreateTest(TestDomain domain)
        {
            return _Repository.CreateTest(domain);
        }

        public TestDomain GetTest(string name)
        {
            return _Repository.GetTest(name);
        }
    }
}
