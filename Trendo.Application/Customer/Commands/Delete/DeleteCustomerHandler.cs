using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Entities.Security;
using Trendo.Domain.Repository;

namespace BuyZone.Application.Customer.Commands.Delete;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand.Request, DeleteCustomerCommand.Response>
{
    private readonly IRepository<Trendo.Domain.Entities.Security.Customer> _repository;

    public DeleteCustomerHandler(IRepository<Trendo.Domain.Entities.Security.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<DeleteCustomerCommand.Response> Handle(DeleteCustomerCommand.Request request, CancellationToken cancellationToken)
    {
        var customer = await _repository
            .Query()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (customer == null)
        {
            return new DeleteCustomerCommand.Response
            {
                Success = false,
                Message = "العميل غير موجود"
            };
        }

        _repository.Delete(customer);


        return new DeleteCustomerCommand.Response
        {
            Success = true,
            Message = "تم حذف العميل بنجاح"
        };
    }
}