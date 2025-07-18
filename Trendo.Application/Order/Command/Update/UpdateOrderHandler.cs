using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;

namespace Trendo.Application.Order.Command.Update;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand.Request, UpdateOrderCommand.Response>
{
    private readonly IRepository<Domain.Entities.Order> _repository;

    public UpdateOrderHandler(IRepository<Domain.Entities.Order> repository)
    {
        _repository = repository;
    }

    public async Task<UpdateOrderCommand.Response> Handle(UpdateOrderCommand.Request request,
        CancellationToken cancellationToken)
    {
        var order = await _repository.Query()
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        if (order == null)
        {
            return new UpdateOrderCommand.Response
            {
                Success = false,
                Message = "الطلب غير موجود"
            };
        }

        order.CustomerId = request.CustomerId;
        order.ProductId = request.ProductId;
        order.Price = request.Price;


        _repository.Update(order);
        await _repository.SaveChangesAsync();

        return new UpdateOrderCommand.Response
        {
            Success = true,
            Message = "تم تحديث الطلب بنجاح"
        };
    }
}