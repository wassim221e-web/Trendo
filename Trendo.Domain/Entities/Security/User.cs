
using Microsoft.AspNetCore.Identity;

namespace Trendo.Domain.Entities.Security;

public class User:IdentityUser<Guid>,IAuditable
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public DateTime? DateDeleted { get; set; }
    public string FirstName { get; set; }
    public string EmployeeNumber { get; set; }  
    public string FullName { get; set; }        
    public string JobPosition { get; set; }     
    public string Country { get; set; }  
    public string CountryCode { get; set; }
    public string? ProfileImagePath { get; set; }
}
