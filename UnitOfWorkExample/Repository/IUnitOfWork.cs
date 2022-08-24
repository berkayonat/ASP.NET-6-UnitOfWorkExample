using UnitOfWorkExample.Model;

namespace UnitOfWorkExample.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }
        public int Complete();
    }
}
