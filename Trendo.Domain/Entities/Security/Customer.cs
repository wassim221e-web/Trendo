using Trendo.Domain.BaseEntity;

namespace Trendo.Domain.Entities.Security;

public class Customer:User,IBaseEntity
{
    public string Address { get; set; }
    public string Brand { get; set; }
    
}