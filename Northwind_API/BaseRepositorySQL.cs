using Northwind_API.Models;
using System.Linq.Expressions;

namespace Northwind_API
{
    public class BaseRepositorySQL<TEntity> : IRepository<TEntity>
    {
        protected readonly NorthwindContext _dbContext;
        public BaseRepositorySQL(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TEntity>> SearchForAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
