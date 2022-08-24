﻿using System.Linq.Expressions;
using UnitOfWorkExample.Data;

namespace UnitOfWorkExample.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Delete(int id);
        bool Update(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        
    }

}
