using Microsoft.EntityFrameworkCore;

namespace Web_Api_CRUD_Template_dotnet6.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Template> Templates { get; set; }

    }
}
