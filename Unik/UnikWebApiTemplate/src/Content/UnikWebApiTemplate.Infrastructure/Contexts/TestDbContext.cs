using Microsoft.EntityFrameworkCore;
using UnikWebApiTemplate.Infrastructure.Models;

namespace UnikWebApiTemplate.Infrastructure.Contexts
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> opt) : base(opt)
        {
        }

        public DbSet<TestEf> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestDbContext).Assembly);
            modelBuilder.HasDefaultSchema("PrefixedName");
        }
    }
}