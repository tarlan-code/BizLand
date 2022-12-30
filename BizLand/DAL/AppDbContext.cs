using BizLand.Models;
using Microsoft.EntityFrameworkCore;

namespace BizLand.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Tophero> TopHero { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
