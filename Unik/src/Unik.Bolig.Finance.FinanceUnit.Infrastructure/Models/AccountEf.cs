using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Bolig.Finance.FinanceUnit.Infrastructure.Models
{
	public class AccountEf
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		public Type Type { get; set; }

		[Required]
		[MaxLength(100)]
		public string Alias { get; set; }
	}
}
