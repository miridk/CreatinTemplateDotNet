using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Models;

namespace Template.Domain.Repositories
{
	public interface IFinanceUnitRepository
	{
		Task<IEnumerable<Financeunit>> GetFinanceUnitsAsync();
		Task<IEnumerable<Financeunit>> GetFinanceUnitsAsync(string searchQuery, int pageSize, int pageNumber);
		Task<Financeunit> GetFinanceUnitAsync(int id);
		Task<Financeunit> CreateFinanceUnitAsync(Financeunit financeUnit);
		Task<Financeunit> UpdateFinanceUnitAsync(int id, Financeunit financeUnit);
		Task<bool> ChecIfFinanceUnitExistsAsync(int id);
		Task DeleteFinanceUnitAsync(int id);
	}
}
