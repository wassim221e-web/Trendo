using Microsoft.EntityFrameworkCore;
using Trendo.Domain.BaseEntity;
using Trendo.Domain.Repository;
using Trendo.Domain.Specifications;
using Trendo.Infrastructure.DbContext;

namespace Trendo.Infrastructure.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly TrendoDbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public Repository(TrendoDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = _dbContext.Set<T>();
    }

    #region Basic CRUD Operations

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task AddAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _dbSet.AddAsync(entity);
    }

    public virtual void Update(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        entity.DateUpdated = DateTime.UtcNow;
        _dbSet.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        entity.DateDeleted = DateTime.UtcNow;
        _dbSet.Remove(entity);
    }

    #endregion

    #region Querying

    public virtual IQueryable<T> Query()
    {
        return _dbSet.AsQueryable();
    }

    public virtual IQueryable<T> TrackingQuery(bool tracking = true)
    {
        return tracking ? _dbSet.AsTracking() : _dbSet.AsNoTracking();
    }

    #endregion

    #region Specification Pattern Support

    public virtual async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        var query = ApplySpecification(spec);
        return await query.ToListAsync();
    }

    public virtual async Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec)
    {
        var query = ApplySpecification(spec);
        return await query.FirstOrDefaultAsync();
    }

    public virtual async Task<int> CountAsync(ISpecification<T> spec)
    {
        var query = ApplySpecification(spec);
        return await query.CountAsync();
    }

    protected virtual IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        if (spec == null)
            throw new ArgumentNullException(nameof(spec));

        return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), spec);
    }

    #endregion
}
