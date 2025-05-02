using MVC03.DataAccess.Data.Contexts;
using MVC03.DataAccess.Models.Shared;
using MVC03.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MVC03.DataAccess.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext _dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _dbContext.Set<TEntity>().ToList();
            else
                return _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _dbContext.Set<TEntity>()
                .Where(e => e.IsDeleted != true)
                .Select(selector)
                .ToList();
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>()
                .Where(predicate).ToList();
        }
        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);
        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }


    }
}
