using ZooApi.Entities;

namespace ZooApi.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Bird> Birds { get; }
        IRepository<Fish> Fishes { get; }
        Task<int> CompleteAsync();
    }
}
