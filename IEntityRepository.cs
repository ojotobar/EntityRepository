using System.Linq.Expressions;

namespace Entity.Repository
{
    public interface IEntityRepository<T>
    {
        Task InsertAsync(T entity, bool saveNow = true, CancellationToken cancellation = default);
        Task InsertRangeAsync(List<T> entities, bool saveNow = true, CancellationToken cancellation = default);
        Task UpdateAsync(T entity, bool saveNow = true, CancellationToken cancellation = default);
        Task UpdateRangeAsync(List<T> entities, bool saveNow = true, CancellationToken cancellation = default);
        Task DeleteAsync(T entity, bool saveNow = true, CancellationToken cancellation = default);
        Task DeleteRangeAsync(List<T> entities, bool saveNow = true, CancellationToken cancellation = default);
        Task<T?> FindByIdAsync(Guid id, bool trackChanges);
        IQueryable<T> AsQueryable(Expression<Func<T, bool>> predicate, bool trackChanges);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<int> SaveAsync(CancellationToken cancellation = default);
    }
}
