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

        public DbSet<Birds> Birds { get; set; }
        public DbSet<Fishes> Fishes { get; set; }
    }
}
