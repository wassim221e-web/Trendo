using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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
        // ✅ ملف الخدمات العامة
        services.AddScoped<IFileService, FileService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // ✅ قاعدة البيانات
        services.AddDbContext<TrendoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        // ✅ إعدادات الهوية Identity
        services.AddIdentity<User, Role>(options =>
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

        // ✅ المصادقة باستخدام JWT
        var jwtSettings = configuration.GetSection("JWT");
        var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(secretKey)
            };
        });

        // ✅ التصريح (authorization)
        services.AddAuthorization();

        return services;
    }
}
