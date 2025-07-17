using System;
using System.Linq.Expressions;
using MediatR;
using Trendo.Domain.Entities.Security;

namespace Trendo.Application.Customer.Queries.GetById;

public class GetByIdCustomerQuery
{
    public class Request : IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

     
        public static Expression<Func<Domain.Entities.Security.Customer, Response>> Selector =>
            c => new Response
            {
                Id = c.Id,
                FullName = c.FirstName + " " + c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber
            };
    }
}