using System.Linq.Expressions;

namespace Globus.DAL.Repositories.Declarations
{
    public interface IGlobalRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
