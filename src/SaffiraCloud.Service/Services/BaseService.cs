using SaffiraCloud.ApplicationCore.Entities;
using SaffiraCloud.ApplicationCore.Interfaces.Repositories;
using SaffiraCloud.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SaffiraCloud.Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task Delete(T entity)
        {
            if (entity == null)
                throw new Exception("Não existem dados para exclusão.");

            await _repository.Delete(entity);
        }

        public async Task DeleteAll(List<T> entities)
        {
            if (entities.Count == 0)
                throw new Exception("Não existem dados para exclusão.");

            await _repository.DeleteAll(entities);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetId(long id)
        {
            return await _repository.GetId(id);
        }

        public virtual async Task<T> Post(T entity)
        {
            entity.DtCadastro = DateTime.Now;
            entity.DtAtualizado = DateTime.Now;

            await _repository.Post(entity);
            return entity;
        }

        public virtual async Task PostAll(List<T> entities)
        {
            await _repository.PostAll(entities);
        }

        public virtual async Task<T> Put(T entity)
        {
            entity.DtAtualizado = DateTime.Now;

            await _repository.Put(entity);
            return entity;
        }

        public virtual async Task PutAll(List<T> entities)
        {
            await _repository.PutAll(entities);
        }

        public async Task<List<T>> Search(Expression<Func<T, bool>> predicado)
        {
            return await _repository.Search(predicado);
        }
    }
}
