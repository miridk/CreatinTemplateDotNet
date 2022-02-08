using Microsoft.EntityFrameworkCore;

namespace TAG_{'modelName'}.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TAG_{'modelName'}> TAG_{'modelName'}s { get; set; }

    }
}
