using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapiApiService.Data;
using webapiApiService.Dtos;
using webapiApiService.Models;
using webapiApiService.SyncDataServices.Http;

namespace webapiApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class webapiApisController : ControllerBase
    {
        private readonly IwebapiApiRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public webapiApisController(IwebapiApiRepo repository, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _repository = repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }
        [HttpGet]
        public ActionResult<IEnumerable<webapiApiReadDto>> GetwebapiApis()
        {
            Console.WriteLine("--> Getting webapiApis....");

            var webapiApiItem = _repository.GetAllwebapiApis();

            return Ok(_mapper.Map<IEnumerable<webapiApiReadDto>>(webapiApiItem));
        }

        [HttpGet("{id}", Name = "GetwebapiApiById")]
        public ActionResult<webapiApiReadDto> GetwebapiApiById(int id)
        {
            var webapiApiItem = _repository.GetwebapiApiById(id);
            if (webapiApiItem != null)
            {
                return Ok(_mapper.Map<webapiApiReadDto>(webapiApiItem));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<webapiApiReadDto>> CreatewebapiApi(webapiApiCreateDto webapiApiCreateDto)
        {
            var webapiApiModel = _mapper.Map<webapiApi>(webapiApiCreateDto);
            _repository.CreatewebapiApi(webapiApiModel);
            _repository.SaveChanges();

            var webapiApiReadDto = _mapper.Map<webapiApiReadDto>(webapiApiModel);

            try
            {
                await _commandDataClient.SendwebapiApiToCommand(webapiApiReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetwebapiApiById), new { Id = webapiApiReadDto.Id }, webapiApiReadDto);
        }
    }
}