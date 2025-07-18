using MediatR;
using Trendo.Application.Catogery.Queries.GetAll;

namespace Trendo.Application.Catogery.Queries.GetById;

public class GetCategoryByIdQuery
{
    public class Request : IRequest<GetAllCategoriesQuery.Response.CategoryDto>
    {
        public Guid Id { get; set; }
    }
}