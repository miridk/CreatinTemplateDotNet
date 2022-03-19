using Unik.Bolig.Finance.FinanceUnit.Domain.Models;

namespace Unik.Bolig.Finance.FinanceUnit.Domain.Services
{
	public interface IFinanceUnitService
	{
		Task<Financeunit> CreateFinanceUnitAsync(Financeunit financeUnitDto);
		Task<Financeunit> GetFinanceUnitByIdAsync(int id);
		Task<bool> CheckIfFinanceUnitExistsAsync(int id);
		Task<IEnumerable<Financeunit>> GetFinanceUnitsAsync();
		Task<IEnumerable<Financeunit>> GetFinanceUnitsAsync(string searchQuery, int pageSize, int pageNumber);
		Task<Financeunit> UpdateFinanceUnit(int id, Financeunit financeUnitDto);
		Task<Financeunit> GetFinanceUnitForpatch(int id);
		Task DeleteFinanceUnitAsync(int id);
	}
}