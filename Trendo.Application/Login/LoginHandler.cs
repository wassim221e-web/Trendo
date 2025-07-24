using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.Security.Claims;
using System.Text;
using Trendo.Domain.Entities.Security;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Trendo.Application.Auth.Command;

public class LoginHandler : IRequestHandler<LoginCommand.Request, LoginCommand.Response>
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public LoginHandler(UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<LoginCommand.Response> Handle(LoginCommand.Request request, CancellationToken cancellationToken)
    {
        // 🔍 البحث عن المستخدم بالإيميل
        var user = await _userManager.FindByEmailAsync(request.Email);

        // ❌ تحقق من صحة كلمة المرور
        if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new Exception("البريد الإلكتروني أو كلمة المرور غير صحيحة.");
        }

        // ✅ إعداد الـ Claims (معلومات داخل الـ Token)
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // ID عشوائي للتوكن
        };

        // 🔁 إضافة الأدوار (Roles)
        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        // 🔐 إعداد المفتاح السري لتوقيع الـ JWT
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

        // 🛠️ توليد JWT Token
        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            expires: DateTime.UtcNow.AddHours(3), // صلاحية التوكن 3 ساعات
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        // 🔁 توليد Refresh Token عشوائي (غير مكشوف)
        string refreshToken = Guid.NewGuid().ToString();

        // ⏳ تاريخ انتهاء الـ Refresh Token
        DateTime refreshTokenExpiration = DateTime.UtcNow.AddDays(7);

        // 💾 تخزين الـ Refresh Token في المستخدم
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = refreshTokenExpiration;

        // 📝 تحديث المستخدم في قاعدة البيانات
        await _userManager.UpdateAsync(user);

        // ✅ رجّع النتيجة مع JWT وRefresh Token
        return new LoginCommand.Response
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo,
            RefreshToken = refreshToken,
            RefreshTokenExpiration = refreshTokenExpiration
        };
    }
}
