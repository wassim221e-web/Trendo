using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Trendo.Domain.Entities;
using Trendo.Domain.Entities.Security;

namespace Trendo.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

public class TrendoDbContext:IdentityDbContext<User,Role,Guid,IdentityUserClaim<Guid>,
    UserRole,
    IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>,
    IdentityUserToken<Guid>>
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

public DbSet<Customer> Customers { get; set; }
public DbSet<Employee> Employees { get; set; }
public DbSet<Product> Products { get; set; }
public DbSet<Category> Categories { get; set; }
public DbSet<Order> Orders { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Product>()
        .HasOne(p => p.Category)
        .WithMany(c => c.Products)
        .HasForeignKey(p => p.CategoryId);

    modelBuilder.Entity<Product>()
        .HasMany(p => p.Orders)
        .WithOne(o => o.Product)
        .HasForeignKey(o => o.ProductId);
}

} 
