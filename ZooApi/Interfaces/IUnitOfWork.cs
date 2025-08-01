using ZooApi.Entities;

namespace ZooApi.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Birds> Birds { get; }
        IRepository<Fishes> Fishes { get; }
        Task<int> CompleteAsync();
    }
}
