using Microsoft.EntityFrameworkCore;
using NewsApi.Core.Models;

namespace NewsApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
    }
}
