using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UnitOfWorkExample.Data;

namespace UnitOfWorkExample.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(int id)
        {

            var exist = await dbSet.FindAsync(id);


            if (exist == null) return false;

            dbSet.Remove(exist);

            return true;


        }

        public bool Update(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

    }
}
