using ZooApi.Data;
using ZooApi.Entities;
using ZooApi.Interfaces;

namespace ZooApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IRepository<Bird> Birds { get; }
        public IRepository<Fish> Fishes { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Birds = new Repository<Bird>(_context);
            Fishes = new Repository<Fish>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
