using Template.Domain.Models;
using Template.Infrastructure.Models;

namespace Template.Infrastructure.Mappers
{
	public interface IEfMapper
	{
		FinanceUnitEf Create(Financeunit financeUnit);
		Financeunit Map(FinanceUnitEf financeUnitEf);
	}
}