using Microsoft.EntityFrameworkCore;
using UnitOfWorkExample.Model;

namespace UnitOfWorkExample.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
