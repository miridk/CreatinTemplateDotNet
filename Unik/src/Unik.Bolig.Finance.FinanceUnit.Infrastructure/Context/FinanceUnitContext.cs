using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Bolig.Finance.FinanceUnit.Infrastructure.Models;

namespace Unik.Bolig.Finance.FinanceUnit.Infrastructure.Context
{
	public class FinanceUnitContext : DbContext
	{
		public FinanceUnitContext(DbContextOptions<FinanceUnitContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
		public DbSet<FinanceUnitEf> FinanceUnit { get; set; }
	}
}
