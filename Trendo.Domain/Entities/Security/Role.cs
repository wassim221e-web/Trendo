using Microsoft.AspNetCore.Identity;

namespace Trendo.Domain.Entities.Security;

public class Role:IdentityRole<Guid>
{
    public string Description { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}