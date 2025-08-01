using Microsoft.EntityFrameworkCore;
using ZooApi.Entities;

namespace ZooApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }

        public DbSet<Bird> Birds { get; set; }
        public DbSet<Fish> Fishes { get; set; }
    }
}
