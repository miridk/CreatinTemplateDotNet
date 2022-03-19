﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Infrastructure.Models;

namespace Template.Infrastructure.Models
{
	public class FinanceUnitEf
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[Required]
		[MaxLength(100)]
		public string Alias { get; set; }

		//public List<BookkeepingPeriodEf>? BookkeepingPeriodEfs { get; set; }

		//public ChartOfAccountEf? ChartOfAccountEfs { get; set;}

	}
}
