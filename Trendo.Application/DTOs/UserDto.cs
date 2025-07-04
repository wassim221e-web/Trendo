namespace Trendo.Application.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string EmployeeNumber { get; set; }
    public string JobPosition { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Country { get; set; }
    public string CountryCode { get; set; }
}