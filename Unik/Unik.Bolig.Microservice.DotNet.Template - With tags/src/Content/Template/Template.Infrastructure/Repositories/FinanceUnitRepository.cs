using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Models;
using Template.Domain.Repositories;
using Template.Infrastructure.Context;
using Template.Infrastructure.Mappers;
using Template.Infrastructure.Models;

namespace Template.Infrastructure.Repositories
{
	public class FinanceUnitRepository : IFinanceUnitRepository
	{
		private readonly FinanceUnitContext _financeUnitContext;
		private readonly IEfMapper _efMapper;

		public FinanceUnitRepository(FinanceUnitContext financeUnitContext, IEfMapper efMapper )
		{
			_financeUnitContext = financeUnitContext;
			_efMapper = efMapper;
		}

		async Task<bool> IFinanceUnitRepository.ChecIfFinanceUnitExistsAsync(int id)
		{
			return await _financeUnitContext.FinanceUnit.AnyAsync(x => x.Id == id);		}

		async Task<Financeunit> IFinanceUnitRepository.CreateFinanceUnitAsync(Financeunit financeUnit)
		{
			var storedObject = await _financeUnitContext.FinanceUnit.AddAsync(_efMapper.Create(financeUnit));
			await _financeUnitContext.SaveChangesAsync();
			return _efMapper.Map(storedObject.Entity);
		}

		async Task IFinanceUnitRepository.DeleteFinanceUnitAsync(int id)
		{
			var objectToRemove = _financeUnitContext.FinanceUnit.Where(x => x.Id == id ).First();
			_financeUnitContext.FinanceUnit.Remove(objectToRemove);
			await _financeUnitContext.SaveChangesAsync();
		}

		async Task<Financeunit> IFinanceUnitRepository.GetFinanceUnitAsync(int id)
		{
			return _efMapper.Map(await _financeUnitContext.FinanceUnit.FirstOrDefaultAsync(x => x.Id == id));
		}

		async Task<IEnumerable<Financeunit>> IFinanceUnitRepository.GetFinanceUnitsAsync()
		{
			return MapFromEfToDomain(_financeUnitContext.FinanceUnit.AsEnumerable());
		}

		async Task<IEnumerable<Financeunit>> IFinanceUnitRepository.GetFinanceUnitsAsync(string searchQuery, int pageSize, int pageNumber)
		{
			//if(string.IsNullOrEmpty(searchQuery))
			//{
			//	return await ((IFinanceUnitRepository)this).GetFinanceUnitsAsync();
			//}
			var collection = _financeUnitContext.FinanceUnit as IQueryable<FinanceUnitEf>;

			if (!string.IsNullOrEmpty(searchQuery))
			{
				searchQuery = searchQuery.Trim();
				collection = collection.Where(x => x.Alias.Contains(searchQuery) || x.Name.Contains(searchQuery));
			}

			return MapFromEfToDomain(collection.Skip(pageSize * (pageNumber -1)).Take(pageSize).AsEnumerable());
		}

		async Task<Financeunit> IFinanceUnitRepository.UpdateFinanceUnitAsync(int id, Financeunit financeUnit)
		{
			var financeUnitEf = await _financeUnitContext.FinanceUnit.FirstOrDefaultAsync(x => x.Id == id);
			financeUnitEf.Name = financeUnit.Name;
			financeUnitEf.Alias = financeUnit.Alias;
			await _financeUnitContext.SaveChangesAsync();

			return _efMapper.Map(financeUnitEf);
		}

		private IEnumerable<Financeunit> MapFromEfToDomain(IEnumerable<FinanceUnitEf> financeUnitEfs)
		{
			var financeUnits = new List<Financeunit>();

			foreach (var item in financeUnitEfs)
			{
				financeUnits.Add(_efMapper.Map(item));
			}

			return financeUnits.AsEnumerable();
		}
	}
}
