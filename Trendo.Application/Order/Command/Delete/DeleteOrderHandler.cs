using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;

namespace Trendo.Application.Order.Command.Delete;

public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand.Request, DeleteOrderCommand.Response>
{
    private readonly IRepository<Domain.Entities.Order> _repository;

    public DeleteOrderHandler(IRepository<Domain.Entities.Order> repository)
    {
        _repository = repository;
    }

    public async Task<DeleteOrderCommand.Response> Handle(DeleteOrderCommand.Request request, CancellationToken cancellationToken)
    {
        var order = await _repository.Query()
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        if (order == null)
        {
            return new DeleteOrderCommand.Response
            {
                Success = false,
                Message = $"الطلب بالمعرف {request.Id} غير موجود"
            };
        }

        _repository.Delete(order);
        await _repository.SaveChangesAsync();

        return new DeleteOrderCommand.Response
        {
            Success = true,
            Message = "تم حذف الطلب بنجاح"
        };
    }
}