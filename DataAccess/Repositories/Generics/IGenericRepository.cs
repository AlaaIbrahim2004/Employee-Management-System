using DataAccess.Models;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Generics
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll(bool track = false);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetById(int id);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetEnumerable();
        IQueryable<TEntity> GetQueryable();
    }

}
