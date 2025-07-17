using MediatR;
using Microsoft.AspNetCore.Identity;
using Trendo.Application.Customer.Queries.GetAll;
using Trendo.Domain.Entities.Security;

namespace Trendo.Application.Customer.Commands.Add;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand.Request, GetAllCustomersQuery.Response.CustomerRes>
{
    private readonly UserManager<User> _userManager;

    public AddCustomerHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<GetAllCustomersQuery.Response.CustomerRes> Handle(AddCustomerCommand.Request request, CancellationToken cancellationToken)
    {
        var customer = new Domain.Entities.Security.Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
     
            DateCreated = DateTime.UtcNow
        };

        var result = await _userManager.CreateAsync(customer, request.Password);

        if (!result.Succeeded)
            throw new Exception("cant add customer.");

        return new GetAllCustomersQuery.Response.CustomerRes
        {
            Id = customer.Id,
           FullName = customer.FirstName + " " + customer.LastName,
            Email = customer.Email,
            
        };
    }
}