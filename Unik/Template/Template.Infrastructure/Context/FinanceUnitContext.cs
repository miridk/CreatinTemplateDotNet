using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Infrastructure.Models;

namespace Template.Infrastructure.Context
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
