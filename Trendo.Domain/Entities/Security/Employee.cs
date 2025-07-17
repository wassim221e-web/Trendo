using Trendo.Domain.BaseEntity;

namespace Trendo.Domain.Entities.Security;

public class Employee:User, IBaseEntity
{
    public string Position { get; set; }
    public string Branch { get; set; }
    public string Status { get; set; }  
    public DateTime CreatedAt { get; set; }
    public Employee() {}

  
    public Employee(string firstName, string lastName, string email, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        UserName = email; // مهم لعمل Identity
        CreatedAt = DateTime.UtcNow;
        Status = "Active"; // قيمة افتراضية مثلاً
    }
}
