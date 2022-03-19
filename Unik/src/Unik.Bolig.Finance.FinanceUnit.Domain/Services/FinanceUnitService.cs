using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Bolig.Finance.FinanceUnit.Domain.Models;
using Unik.Bolig.Finance.FinanceUnit.Domain.Repositories;

namespace Unik.Bolig.Finance.FinanceUnit.Domain.Services
{
	public class FinanceUnitService : IFinanceUnitService
	{
		private readonly IFinanceUnitRepository _financeUnitRepository;


		public FinanceUnitService(IFinanceUnitRepository financeUnitRepository)
		{
			_financeUnitRepository = financeUnitRepository;
		}

		async Task<bool> IFinanceUnitService.CheckIfFinanceUnitExistsAsync(int id)
		{
			return await _financeUnitRepository.ChecIfFinanceUnitExistsAsync(id);
		}

		async Task<Financeunit> IFinanceUnitService.CreateFinanceUnitAsync(Financeunit financeUnitDto)
		{
			var financeUnit = await _financeUnitRepository.CreateFinanceUnitAsync(financeUnitDto);
			return financeUnit;
		}

		async Task IFinanceUnitService.DeleteFinanceUnitAsync(int id)
		{
			await _financeUnitRepository.DeleteFinanceUnitAsync(id);
		}

		async Task<Financeunit> IFinanceUnitService.GetFinanceUnitByIdAsync(int id)
		{
			return await _financeUnitRepository.GetFinanceUnitAsync(id);
		}

		Task<Financeunit> IFinanceUnitService.GetFinanceUnitForpatch(int id)
		{
			throw new NotImplementedException();
		}

		async Task<IEnumerable<Financeunit>> IFinanceUnitService.GetFinanceUnitsAsync()
		{
			return await _financeUnitRepository.GetFinanceUnitsAsync();
		}

		async Task<IEnumerable<Financeunit>> IFinanceUnitService.GetFinanceUnitsAsync(string searchQuery, int pageSize, int pageNumber)
		{
			//if(string.IsNullOrEmpty(searchQuery))
			//{
			//	return await ((IFinanceUnitService)this).GetFinanceUnitsAsync();
			//}
			return await _financeUnitRepository.GetFinanceUnitsAsync(searchQuery, pageSize, pageNumber);
		}
		async Task<Financeunit> IFinanceUnitService.UpdateFinanceUnit(int id, Financeunit financeUnitDto)
		{
			Financeunit financeUnit;
			if (id == -1)
				financeUnit = await _financeUnitRepository.CreateFinanceUnitAsync(financeUnitDto);
			else
				financeUnit = await _financeUnitRepository.UpdateFinanceUnitAsync(id, financeUnitDto);

			return financeUnit;
		}

	}
}
