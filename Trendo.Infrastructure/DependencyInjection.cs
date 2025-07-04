using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trendo.Application.File.Interface;
using Trendo.Domain.Entities.Security;
using Trendo.Domain.Repository;
using Trendo.Infrastructure.DbContext;
using Trendo.Infrastructure.Repository;


namespace Trendo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFileService, FileService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddDbContext<TrendoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddIdentity<User,Role>(options =>
        {
            options.Password.RequireDigit = true;   
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.User.RequireUniqueEmail = true;

        })
        .AddEntityFrameworkStores<TrendoDbContext>()
        .AddUserManager<UserManager<User>>()
        .AddRoleManager<RoleManager<Role>>()
        .AddSignInManager<SignInManager<User>>()
        .AddDefaultTokenProviders();
        
        
        
        return services;
    }
}
