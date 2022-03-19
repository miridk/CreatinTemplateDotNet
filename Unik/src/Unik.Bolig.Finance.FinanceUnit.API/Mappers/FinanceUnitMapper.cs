using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Bolig.Finance.FinanceUnit.API.Models;
using Unik.Bolig.Finance.FinanceUnit.Domain.Models;

namespace Unik.Bolig.Finance.FinanceUnit.API.Mappers
{
	public class FinanceUnitMapper : IFinanceUnitMapper
	{
		public Financeunit Create(FinanceUnitDto financeUnitDto)
		{
			return new Financeunit(financeUnitDto.Id, financeUnitDto.Name, financeUnitDto.Alias);
		}

		public Financeunit Create(FinanceUnitCreationDto financeUnitCreationDto)
		{

			return new Financeunit(0, financeUnitCreationDto.Name, financeUnitCreationDto.Alias);
		}

		public Financeunit Create(FinanceUnitUpdateDto financeUnitCreationDto)
		{

			return new Financeunit(0, financeUnitCreationDto.Name, financeUnitCreationDto.Alias);
		}

		public FinanceUnitDto? Map(Financeunit financeUnit)
		{
			if (financeUnit == null)
				return null;
			return new FinanceUnitDto()
			{
				Id = financeUnit.Id,
				Name = financeUnit.Name,
				Alias = financeUnit.Alias
			};
		}

		public FinanceUnitUpdateDto? MapToUpdateDto(Financeunit financeUnit)
		{
			if (financeUnit == null)
				return null;
			return new FinanceUnitUpdateDto()
			{
				Name = financeUnit.Name,
				Alias = financeUnit.Alias
			};
		}
	}
}
