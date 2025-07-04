using Microsoft.AspNetCore.Identity;

namespace Trendo.Domain.BaseEntity;

public abstract class BaseEntity: IdentityUser,IAuditable
{
    public int Id { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public DateTime? DateDeleted { get; set; }
}