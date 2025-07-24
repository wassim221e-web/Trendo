
using Microsoft.AspNetCore.Identity;

namespace Trendo.Domain.Entities.Security;

public class User:IdentityUser<Guid>,IAuditable
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public DateTime? DateDeleted { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Number { get; set; }  
    public string? ImagePath { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

}
