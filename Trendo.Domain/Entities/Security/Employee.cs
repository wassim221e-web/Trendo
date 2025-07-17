using Trendo.Domain.BaseEntity;

namespace Trendo.Domain.Entities.Security;

public class Employee:User, IBaseEntity
{
    public string Position { get; set; }
    public string Branch { get; set; }
    public string Status { get; set; }  
    public DateTime CreatedAt { get; set; }
}