using Microsoft.AspNetCore.Mvc;
using Template.Domain.Services;

namespace Template.API.Controllers
{

	// This is a temp controller until is decided where it should be placed. This is just example how to handle child items
	[ApiController]
	[Route("api/financeunits{financeUnitId}/defaultAaccounts")] // Is the financeUnit that owns default accounts
	public class DefaultAccountController : ControllerBase 
	{
		private readonly ILogger<DefaultAccountController> _logger;
		private readonly IFinanceUnitService _financeUnitService;

		public DefaultAccountController(ILogger<DefaultAccountController> logger, IFinanceUnitService financeUnitService)
		{
			_logger = logger;
			_financeUnitService = financeUnitService;
		}

		[HttpGet(Name = "Get all default accounts for a FinanceUnit")]
		//[HttpHead]
		public async Task<ActionResult> GetDefaultAccountsForAFinanceUnitAsync(int fianceUnitId)
		{
			var financeUnit = await _financeUnitService.GetFinanceUnitByIdAsync(fianceUnitId);
			if (financeUnit == null)
			{
				return NotFound();
			}
			throw new NotImplementedException();
		}

		[HttpGet(template: "{defaultAccountId}", Name = "Get specific default account for a FinanceUnit")]
		//[HttpHead]
		public async Task<ActionResult> GetSpecificDefaultAccountForAFinanceUnitAsync(int fianceUnitId, int defaultAccountId)
		{
			var financeUnit = await _financeUnitService.GetFinanceUnitByIdAsync(fianceUnitId);
			if (financeUnit == null)
			{
				return NotFound();
			}
			// Check if the default account exist
			throw new NotImplementedException();
		}

		//[HttpPost]
		//public async Task<ActionResult> PostNewDefaultAccountToFinanceUnitAsync(int fianceUnitId)
		//{
		//	if(!await _financeUnitService.CheckIfFinanceUnitExistsAsync(fianceUnitId))
		//	{
		//		return NotFound();
		//	}
		//}
	}
}
