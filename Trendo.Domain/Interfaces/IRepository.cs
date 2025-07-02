using Trendo.Domain.Specifications;

namespace Trendo.Domain.Repository;

public interface IRepository<T> where T : BaseEntity.BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> Query(); 
    IQueryable<T> TrackingQuery(bool tracking); 
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec); 
}

