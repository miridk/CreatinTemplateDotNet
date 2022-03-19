
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Bolig.Finance.FinanceUnit.Domain.Models;
using Unik.Bolig.Finance.FinanceUnit.Infrastructure.Models;

namespace Unik.Bolig.Finance.FinanceUnit.Infrastructure.Mappers
{
	public class EfMapper : IEfMapper
	{
		public FinanceUnitEf Create(Financeunit financeUnit)
		{
			return new FinanceUnitEf()
			{
				Id = financeUnit.Id,
				Name = financeUnit.Name,
				Alias = financeUnit.Alias,
			};
		}
		public Financeunit Map(FinanceUnitEf financeUnitEf)
		{
			if(financeUnitEf == null)
				return null;
			return new Financeunit()
			{
				Id = financeUnitEf.Id,
				Name = financeUnitEf.Name,
				Alias = financeUnitEf.Alias
			};
		}
	}
}
