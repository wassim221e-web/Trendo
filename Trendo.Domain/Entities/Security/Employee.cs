namespace Trendo.Domain.Entities.Security;

public class Employee:User
{
    public string Position { get; set; }
    public string Branch { get; set; }
    public string Status { get; set; }  
    public DateTime CreatedAt { get; set; }
}