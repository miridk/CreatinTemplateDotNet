using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Models
{
	public  class Financeunit
	{
		public Financeunit()
		{

		}
		public Financeunit(int financeUnitID, string financeUnitName, string financeUnitAlias)
		{
			Id = financeUnitID;
			Name = financeUnitName;
			Alias = financeUnitAlias;
		}

		public int Id { get; set;}
		public string Name { get; set;}
		public string Alias { get; set;}
	}
}
