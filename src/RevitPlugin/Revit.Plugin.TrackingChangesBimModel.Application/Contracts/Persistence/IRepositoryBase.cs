

namespace Revit.Plugins.TrackingChangesBimModel.Application.Contracts.Persistence;

public interface IRepositoryBase<T> where T : EntityBase
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>>? predicate = null,
        Expression<Func<IQueryable<T>, IOrderedQueryable>>? orderBy = null,
        string? includeString = null,
        bool disableTracking = true);
    Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        List<Expression<Func<T, object>>>? includes = null,
        bool disableTracking = true);
    Task<T?> GetByIdAsync(T entity);
    Task<T> AddSync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
