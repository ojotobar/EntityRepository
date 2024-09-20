using System.Linq.Expressions;
using Entity.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity.Repository
{
    public class EntityRepository<T, TU> : IEntityRepository<T> where T : BaseEntity where TU : DbContext
    {
        private readonly TU _context;
        public EntityRepository(TU context)
        {
            _context = context;
        }

        public async Task InsertAsync(T entity, bool saveNow = true, 
            CancellationToken cancellation = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellation);
            if (saveNow)
            {
                await SaveAsync(cancellation);
            }
        }

        public async Task InsertRangeAsync(List<T> entities, bool saveNow = true,
            CancellationToken cancellation = default)
        {
            await _context.Set<T>().AddRangeAsync(entities, cancellation);
            if (saveNow)
            {
                await SaveAsync(cancellation);
            }
        }

        public async Task UpdateAsync(T entity, bool saveNow = true, 
            CancellationToken cancellation = default)
        {
            _context.Set<T>().Update(entity);
            if (saveNow)
            {
                await SaveAsync(cancellation);
            }
        }

        public async Task UpdateRangeAsync(List<T> entities, bool saveNow = true, 
            CancellationToken cancellation = default)
        {
            _context.Set<T>().UpdateRange(entities);
            if (saveNow)
            {
                await SaveAsync(cancellation);
            }
        }

        public async Task DeleteAsync(T entity, bool saveNow = true, 
            CancellationToken cancellation = default)
        {
            _context.Set<T>().Remove(entity);
            if (saveNow)
            {
                await SaveAsync(cancellation);
            }
        }

        public async Task DeleteRangeAsync(List<T> entities, bool saveNow = true, 
            CancellationToken cancellation = default)
        {
            _context.Set<T>().RemoveRange(entities);
            if (saveNow)
            {
                await SaveAsync(cancellation);
            }
        }

        public async Task<T?> FindByIdAsync(Guid id, bool trackChanges) =>
            trackChanges ? 
                await _context.Set<T>().FirstOrDefaultAsync(i => i.Id.Equals(id)) :
                await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(i => i.Id.Equals(id));

        public IQueryable<T> AsQueryable(Expression<Func<T, bool>> predicate, bool trackChanges) =>
            !trackChanges ? _context.Set<T>()
                    .Where(predicate)
                    .AsNoTracking() : _context.Set<T>()
                    .Where(predicate);

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate) =>
            await _context.Set<T>().CountAsync(predicate);

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate) =>
            await _context.Set<T>().AnyAsync(predicate);

        public async Task<int> SaveAsync(CancellationToken cancellation = default) =>
            await _context.SaveChangesAsync(cancellation);
    }
}