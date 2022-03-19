using Unik.Bolig.Finance.FinanceUnit.Domain.Models;
using Unik.Bolig.Finance.FinanceUnit.Infrastructure.Models;

namespace Unik.Bolig.Finance.FinanceUnit.Infrastructure.Mappers
{
	public interface IEfMapper
	{
		FinanceUnitEf Create(Financeunit financeUnit);
		Financeunit Map(FinanceUnitEf financeUnitEf);
	}
}