using Unik.Bolig.Finance.FinanceUnit.API.Models;
using Unik.Bolig.Finance.FinanceUnit.Domain.Models;

namespace Unik.Bolig.Finance.FinanceUnit.API.Mappers
{
	public interface IFinanceUnitMapper
	{
		Financeunit Create(FinanceUnitCreationDto financeUnitCreationDto);
		Financeunit Create(FinanceUnitDto financeUnitDto);
		Financeunit Create(FinanceUnitUpdateDto financeUnitDto);
		FinanceUnitDto? Map(Financeunit financeUnit);
		FinanceUnitUpdateDto? MapToUpdateDto(Financeunit financeUnit);
	}
}