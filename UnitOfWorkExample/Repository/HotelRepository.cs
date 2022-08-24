using UnitOfWorkExample.Data;
using UnitOfWorkExample.Model;

namespace UnitOfWorkExample.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(AppDbContext context) : base(context)
        {
        }
    }
}
