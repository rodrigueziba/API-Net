
using Microsoft.EntityFrameworkCore;
using API_Net.DataAccess;
using API_Net.Repository.Interfaces;
using API_Net.DTOs;
using API_Net.Entities;
using API_Net.Services;
using System.Threading;

namespace API_Net.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ContextDB _contextDB;

        public Repository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public virtual async Task<List<T>> GetAll()
        {
            var entity = await _contextDB.Set<T>().ToListAsync();
            return entity;
        }

        public async Task<bool> Insert(T entity)
        {
            try
            {
                _contextDB.Set<T>().Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                _contextDB.Set<T>().Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
