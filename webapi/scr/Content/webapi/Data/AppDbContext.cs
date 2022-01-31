using Microsoft.EntityFrameworkCore;
using webapiApiService.Models;

namespace webapiApiService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<webapiApi> webapiApis { get; set; }
    }
}