using SaffiraCloud.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SaffiraCloud.ApplicationCore.Interfaces.Services
{
    public interface IBaseService<T> : IDisposable where T : BaseEntity
    {
        Task<T> Post(T entity);
        Task PostAll(List<T> entities);
        Task<T> Put(T entity);
        Task PutAll(List<T> entities);
        Task<List<T>> GetAll();
        Task<T> GetId(long id);
        Task<List<T>> Search(Expression<Func<T, bool>> predicado);
        Task Delete(T entity);
        Task DeleteAll(List<T> entities);
    }
}
