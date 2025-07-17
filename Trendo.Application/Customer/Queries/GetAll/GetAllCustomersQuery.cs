using MediatR;

namespace Trendo.Application.Customer.Queries.GetAll;

public class GetAllCustomersQuery
{
    public class Request:IRequest<Response>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }

    public class Response
    {
        public int Count { get; set; }
        public List<CustomerRes> Customers { get; set; }
        public class CustomerRes
        {
            public Guid Id { get; set; }
            public int Number { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
            public DateTime DateCreated { get; set; }
        }
    }
}