using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;

namespace Trendo.Application.Customer.Commands.Update;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand.Request, UpdateCustomerCommand.Response>
{
    private readonly IRepository<Domain.Entities.Security.Customer> _repository;

    public UpdateCustomerHandler(IRepository<Domain.Entities.Security.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<UpdateCustomerCommand.Response> Handle(UpdateCustomerCommand.Request request, CancellationToken cancellationToken)
    {
        var customer = await _repository.Query()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (customer == null)
        {
            return new UpdateCustomerCommand.Response
            {
                Success = false,
                Message = "العميل غير موجود"
            };
        }

        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.Email = request.Email;

     
        _repository.Update(customer);
        await _repository.SaveChangesAsync();

        return new UpdateCustomerCommand.Response
        {
            Success = true,
            Message = "تم التحديث بنجاح"
        };
    }
}