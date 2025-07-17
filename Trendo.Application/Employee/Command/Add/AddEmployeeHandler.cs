using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Trendo.Application.Employee.Query.GetAllEmployee;
using Trendo.Domain.Entities.Security;
using Trendo.Domain.Repository;

namespace Trendo.Application.Employee.Command.Add;

public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand.Request, GetAllEmployeeQuery.Response.EmployeeRes>
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IRepository<Domain.Entities.Security.Employee> _repository;

    public AddEmployeeHandler(
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        IRepository<Domain.Entities.Security.Employee> repository)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _repository = repository;
    }

    public async Task<GetAllEmployeeQuery.Response.EmployeeRes> Handle(AddEmployeeCommand.Request request, CancellationToken cancellationToken)
    {
        
        var employee = new Domain.Entities.Security.Employee(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber
        );

        var result = await _userManager.CreateAsync(employee, request.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new Exception($"فشل إنشاء الموظف: {errors}");
        }

     
        var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
        if (role != null)
        {
            await _userManager.AddToRoleAsync(employee, role.Name ?? string.Empty);
        }

        var employeeRes = await _repository.Query()
            .Where(e => e.Id == employee.Id)
            .Select(GetAllEmployeeQuery.Response.EmployeeRes.Selector)
            .FirstOrDefaultAsync(cancellationToken);

        return employeeRes!;
    }
}
