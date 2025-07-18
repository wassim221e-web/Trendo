using MediatR;
using Trendo.Application.Order.Query.GetAll;
using Trendo.Domain.Repository;

namespace Trendo.Application.Order.Command.Add;

public class AddOrderHandler : IRequestHandler<AddOrderCommand.Request, GetAllOrdersQuery.Response.OrdersRes>
{
    private readonly IRepository<Domain.Entities.Order> _orderRepository;

    public AddOrderHandler(IRepository<Domain.Entities.Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<GetAllOrdersQuery.Response.OrdersRes> Handle(AddOrderCommand.Request request, CancellationToken cancellationToken)
    {
        var price = 34;
        var order = new Domain.Entities.Order(
            customerId: request.CustomerId,
            productId: request.ProductId,
            price: price,
            quantity: request.Quantity
        );

        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();

        return new GetAllOrdersQuery.Response.OrdersRes
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            ProductId = order.ProductId,
            Price = order.Price
        };
    }
}