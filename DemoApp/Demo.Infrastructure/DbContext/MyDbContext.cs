using Demo.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Fragrance> Fragrances { get; set; }
    }
}
