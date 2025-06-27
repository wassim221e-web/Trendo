namespace Trendo.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

public class TrendoDbContext:DbContext
{
    public TrendoDbContext(DbContextOptions<TrendoDbContext> options) : base(options) {}
} 
