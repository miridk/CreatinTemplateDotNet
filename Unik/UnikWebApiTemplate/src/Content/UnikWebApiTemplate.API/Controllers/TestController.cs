using Microsoft.AspNetCore.Mvc;
using UnikWebApiTemplate.API.Models;
using UnikWebApiTemplate.Domain.Models;
using UnikWebApiTemplate.Domain.Services;

namespace UnikWebApiTemplate.API.Controllers
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
