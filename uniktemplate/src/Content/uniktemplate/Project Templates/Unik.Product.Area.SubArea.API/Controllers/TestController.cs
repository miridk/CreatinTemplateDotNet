using Microsoft.AspNetCore.Mvc;
using $safeprojectname$.Models;
using $ext_safeprojectname$.Domain.Models;
using $ext_safeprojectname$.Domain.Services;

namespace $safeprojectname$.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _Service;

        public TestController(
            ITestService service
            )
        {
            _Service = service;
        }

        [HttpPost]
        public IActionResult CreateTest(TestDto dto)
        {
            return Ok(_Service.CreateTest(new TestDomain(dto.Name)));
        }

        [Route("{name}")]
        [HttpGet]
        public IActionResult GetTest(string name)
        {
            return Ok(_Service.GetTest(name));
        }
    }
}
