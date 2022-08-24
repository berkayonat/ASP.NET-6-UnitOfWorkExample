using UnitOfWorkExample.Data;
using UnitOfWorkExample.Model;

namespace UnitOfWorkExample.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
