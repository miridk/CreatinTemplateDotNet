using Microsoft.EntityFrameworkCore;

namespace Template.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Template> Templates { get; set; }

    }
}
