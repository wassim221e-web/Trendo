using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;
using Trendo.Infrastructure.DbContext;

namespace Trendo.Infrastructure.Repository;
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly TrendoDbContext _dbContext;

    public Repository(TrendoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }
    
    public IQueryable<T> Query()
        => _dbContext.Set<T>();

   
    public IQueryable<T> TrackingQuery(bool tracking)
        => tracking
            ? _dbContext.Set<T>().AsTracking()
            : _dbContext.Set<T>().AsNoTracking();
}





