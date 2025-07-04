using Microsoft.AspNetCore.Identity;

namespace Trendo.Domain.Entities.Security;

public class UserRole:IdentityUserRole<Guid>
{
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}