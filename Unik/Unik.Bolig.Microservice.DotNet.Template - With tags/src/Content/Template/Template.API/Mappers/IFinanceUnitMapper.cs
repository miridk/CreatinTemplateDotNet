using Template.API.Models;
using Template.Domain.Models;

namespace Template.API.Mappers
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