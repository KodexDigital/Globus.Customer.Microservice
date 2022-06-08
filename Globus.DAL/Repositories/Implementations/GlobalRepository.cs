using Globus.DAL.Data;
using Globus.DAL.Repositories.Declarations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Globus.DAL.Repositories.Implementations
{
    public class GlobalRepository<TEntity> : IGlobalRepository<TEntity> where TEntity : class
    {
        private readonly CustomerDbContext context;
        protected internal readonly DbSet<TEntity> dbSet;

        public GlobalRepository(CustomerDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public async Task<IEnumerable<TEntity>> GetAsync() => await dbSet.ToListAsync();
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await dbSet.FirstOrDefaultAsync(predicate);
        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate)
           => await dbSet.AnyAsync(predicate);
    }
}
