using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Infrastructure.Models
{
	public class ChartOfAccountEf
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }
		
		[Required]
		[MaxLength(100)]
		public string Alias { get; set; }


		public List<AccountEf>? AccountEfs { get; set; }

	}
}
