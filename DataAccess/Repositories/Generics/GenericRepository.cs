using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Generics
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        public GenericRepository(AppDbContext dpContext)
        {
            _dbContext = dpContext;
        }
        public TEntity? GetById(int id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            return entity;
        }
        public IEnumerable<TEntity> GetAll(bool track = false)
        {
            if (track)
            {
                return _dbContext.Set<TEntity>().ToList();
            }
            else return _dbContext.Set<TEntity>().AsNoTracking().ToList();

        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }
        public void Add(TEntity entity)
        {
            _dbContext.Add(entity);
        }
        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }
        public void Remove(TEntity entity)
        {
            _dbContext.Remove(entity);
        }

        public IEnumerable<TEntity> GetEnumerable()
        {
            return _dbContext.Set<TEntity>().ToList();

        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbContext.Set<TEntity>();
        }

    }
}
