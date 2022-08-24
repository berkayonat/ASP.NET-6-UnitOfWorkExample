using UnitOfWorkExample.Data;
using UnitOfWorkExample.Model;

namespace UnitOfWorkExample.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepository<Country> Countries { get; }
        public IGenericRepository<Hotel> Hotels { get; }
        public UnitOfWork(AppDbContext context, IHotelRepository hotelRepository, ICountryRepository countryRepository)
        {
            _context = context;
            Countries = countryRepository;
            Hotels = hotelRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
