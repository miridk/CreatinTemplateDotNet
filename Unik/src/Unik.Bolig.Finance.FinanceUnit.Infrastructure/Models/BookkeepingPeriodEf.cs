using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Bolig.Finance.FinanceUnit.Infrastructure.Models
{
	public class BookkeepingPeriodEf
	{
		[Key]
		public int Id { get; set; }

		public DateTime From { get; set; }

		public DateTime To { get; set; }
	}
}
