namespace TrackingChangesBimModel.Application.Contracts.Persistence;

public interface IRepositoryBase<T> where T : Domain.Common.EntityBase
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string? includeString = null,
        bool disableTracking = true);
    Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        List<Expression<Func<T, object>>>? includes = null,
        bool disableTracking = true);
    Task<T?> GetByIdAsync(Guid id);
    Task<T> AddASync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
