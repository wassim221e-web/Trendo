using MediatR;
using Trendo.Application.Customer.Queries.GetAll;
using Trendo.Application.Order.Query.GetAll;

namespace Trendo.Application.Order.Command.Add;

public class AddOrderCommand
{
    public class Request: IRequest<GetAllOrdersQuery.Response.OrdersRes>, IRequest<GetAllOrdersQuery.Response>
    {
       
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}