using ZooApi.Data;
using ZooApi.Entities;
using ZooApi.Interfaces;

namespace ZooApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IRepository<Birds> Birds { get; }
        public IRepository<Fishes> Fishes { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Birds = new Repository<Birds>(_context);
            Fishes = new Repository<Fishes>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
