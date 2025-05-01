using MVC03.DataAccess.Data.Contexts;
using MVC03.DataAccess.Models.Shared;
using MVC03.DataAccess.Repositories.Interfaces;

namespace MVC03.DataAccess.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext _dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking) return _dbContext.Set<TEntity>().ToList();
            else return _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }


        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }
    }
}
