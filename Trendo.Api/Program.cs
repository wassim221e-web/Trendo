using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Trendo.Domain.Entities.Security;
using Trendo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ✅ إضافة الخدمات (Clean Architecture)
builder.Services.AddInfrastructure(builder.Configuration);

// ✅ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ MVC / Controllers
builder.Services.AddControllers();

var app = builder.Build();

// ✅ Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ ترتيب مهم
app.UseAuthentication();
app.UseAuthorization();

// ✅ الربط مع Controllers
app.MapControllers();

app.Run();