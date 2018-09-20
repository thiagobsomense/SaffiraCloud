using Microsoft.EntityFrameworkCore;
using SaffiraCloud.ApplicationCore.Entities;
using SaffiraCloud.ApplicationCore.Interfaces.Repositories;
using SaffiraCloud.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SaffiraCloud.Infra.Data.Repositories
{
    public class EFRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly BaseContext _db = new BaseContext();

        public async Task Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAll(List<T> entities)
        {
            _db.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<List<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetId(long id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> Post(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task PostAll(List<T> entities)
        {
            await _db.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public virtual async Task<T> Put(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task PutAll(List<T> entities)
        {
            _db.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<List<T>> Search(Expression<Func<T, bool>> predicado)
        {
            return await _db.Set<T>().Where(predicado).ToListAsync();
        }
    }
}
