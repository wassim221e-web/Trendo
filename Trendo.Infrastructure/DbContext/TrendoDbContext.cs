namespace Trendo.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

public class TrendoDbContext:DbContext
{
    public TrendoDbContext(DbContextOptions<TrendoDbContext> options) : base(options) {}

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<IAuditable>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.DateUpdated = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }


} 
