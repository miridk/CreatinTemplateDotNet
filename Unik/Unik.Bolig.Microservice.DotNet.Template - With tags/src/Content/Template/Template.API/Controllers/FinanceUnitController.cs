using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Template.API;
using Template.API.Mappers;
using Template.API.Models;
using Template.API.QueryParameters;
using Template.Domain.Models;
using Template.Domain.Services;

namespace Template.Controllers
{
	[ApiController]
	[Route("api/financeunits")] // Better to specifically use naming rather than based on the controller name Route("api/[controller]")
	public class FinanceUnitController : ControllerBase
	{
		private readonly ILogger<FinanceUnitController> _logger;
		private readonly IFinanceUnitService _financeUnitService;
		private readonly IFinanceUnitMapper _financeUnitMapper;

		public FinanceUnitController(ILogger<FinanceUnitController> logger, IFinanceUnitService financeUnitService, IFinanceUnitMapper financeUnitMapper)
		{
			_logger = logger;
			_financeUnitService = financeUnitService;
			_financeUnitMapper = financeUnitMapper;
		}

		[HttpGet(Name = "Get a collection of FinanceUnits")]
		[HttpHead]
		public async Task<ActionResult<IEnumerable<FinanceUnitDto>>> GetFianceUnitsAsync([FromQuery] FinanceUnitQueryParameters financeUnitQueryParameters)
		{
			return new OkObjectResult(await _financeUnitService.GetFinanceUnitsAsync(financeUnitQueryParameters.SearchQuery, financeUnitQueryParameters.PageSize, financeUnitQueryParameters.PageNumber));
		}

		[HttpGet(template: "{fianceUnitId}", Name = "Get a specific FinanceUnit")]
		public async Task<ActionResult<FinanceUnitDto>> GetFianceUnitAsync(int fianceUnitId)
		{
			var financeUnit = await _financeUnitService.GetFinanceUnitByIdAsync(fianceUnitId);
			if (financeUnit == null)
			{
				return NotFound();
			}

			return new OkObjectResult(financeUnit);
		}

		[HttpPost]
		public async Task<ActionResult<FinanceUnitDto>> PostFinanceUnitAsync(FinanceUnitCreationDto financeUnit)
		{
			var result = await _financeUnitService.CreateFinanceUnitAsync(_financeUnitMapper.Create(financeUnit));
			return new OkObjectResult(_financeUnitMapper.Map(result));
		}

		[HttpPut]
		public async Task<ActionResult<FinanceUnitDto>> PostFinanceUnitAsync(int financeUnitId, [FromBody]FinanceUnitUpdateDto financeUnitDto)
		{
			if(!await _financeUnitService.CheckIfFinanceUnitExistsAsync(financeUnitId))
			{
				return new OkObjectResult(_financeUnitMapper.Map(await _financeUnitService.UpdateFinanceUnit(-1, _financeUnitMapper.Create(financeUnitDto))));
			}
			await _financeUnitService.UpdateFinanceUnit(financeUnitId, _financeUnitMapper.Create(financeUnitDto));
			return NoContent();
		}

		// Https://tools.ietf.org/html/rfc6902
		//[HttpPatch]
		//public async Task<ActionResult<FinanceUnitDto>> PatchFinanceUnitAsync(int financeUnitId, [FromBody] JsonPatchDocument<FinanceUnitUpdateDto> patchDocument)
		//{
		//	// try https://docs.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-6.0   %% https://docs.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-6.0
		//	if (! await _financeUnitService.CheckIfFinanceUnitExistsAsync(financeUnitId))
		//	{
		//		return NotFound();

		//		// The current way of handling this it might not be possible in a easy way
		//		//var financeUpdateUnit = new FinanceUnitUpdateDto();
		//		//patchDocument.ApplyTo(financeUpdateUnit);
		//		//financeUpdateUnit.id
		//	}

		//	FinanceUnitUpdateDto financeUnit = _financeUnitMapper.Map(await _financeUnitService.GetFinanceUnitForpatch(financeUnitId));

		//	patchDocument.ApplyTo(financeUnit);

		//	if(!TryValidateModel(financeUnit))
		//	{
		//		return ValidationProblem(ModelState);
		//	}

		//	await _financeUnitService.UpdateFinanceUnit(financeUnitId, financeUnit);
		//	return NoContent();
		//}

		[HttpGet("({ids})", Name = "GetFinanceUnitCollection")]
		public async Task<IActionResult> GetAuthorCollection([FromRoute][ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
		{
			if (ids == null)
			{
				return BadRequest();
			}

			// Fix this since paging broke it
			var financeUnitDtos = await _financeUnitService.GetFinanceUnitsAsync(ids.ToString(), 10, 1);

			if (ids.Count() != financeUnitDtos.Count())
			{
				return NotFound();
			}


			return new OkObjectResult(financeUnitDtos);
		}

        [HttpPost("postCollection")]
        public async Task<ActionResult<IEnumerable<FinanceUnitDto>>> PostFinanceUnitCollectionAsync(IEnumerable<FinanceUnitCreationDto> financeUnitCollection)
        {
            var financeUnitDtos = new List<FinanceUnitDto>();
            foreach (var unit in financeUnitCollection)
            {
				financeUnitDtos.Add(_financeUnitMapper.Map(await _financeUnitService.CreateFinanceUnitAsync(_financeUnitMapper.Create(unit))));
            }


            var idsAsString = string.Join(",", financeUnitDtos.Select(a => a.Id));
            return CreatedAtRoute("GetFinanceUnitCollection", new { ids = idsAsString }, financeUnitDtos.AsEnumerable());
        }

        [HttpOptions]
		public IActionResult GetFinanceUnitOptions()
		{
			Response.Headers.Add("Allow", "GET,OPTIONS,POST");
			return Ok();
		}

		[HttpDelete(template: "{fianceUnitId}", Name = "Delete a specific FinanceUnit")]
		public async Task<ActionResult> DeleteFinanceUnit(int fianceUnitId)
		{
			if(!await _financeUnitService.CheckIfFinanceUnitExistsAsync(fianceUnitId))
			{
				return NotFound();
			}

			await _financeUnitService.DeleteFinanceUnitAsync(fianceUnitId);

			return NoContent();

		}



		public override ActionResult ValidationProblem([ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
		{
			var options = HttpContext.RequestServices.GetRequiredService<IOptions<ApiBehaviorOptions>>();
			return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
		}
	}
}