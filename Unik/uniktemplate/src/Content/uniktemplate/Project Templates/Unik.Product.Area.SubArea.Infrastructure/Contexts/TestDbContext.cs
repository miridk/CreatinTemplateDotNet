namespace $safeprojectname$.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using $safeprojectname$.Models;

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