using ApiCoreNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiNetCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Person> Person { get; set; }
    }
}
