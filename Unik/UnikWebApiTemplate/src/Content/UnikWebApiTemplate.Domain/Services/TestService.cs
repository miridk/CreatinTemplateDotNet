using AutoMapper;
using UnikWebApiTemplate.Domain.Models;
using UnikWebApiTemplate.Domain.Repositories;

namespace UnikWebApiTemplate.Domain.Services
{
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
