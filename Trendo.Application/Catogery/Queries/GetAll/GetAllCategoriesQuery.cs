using System.Linq.Expressions;
using MediatR;

namespace Trendo.Application.Catogery.Queries.GetAll;

public class GetAllCategoriesQuery
{
    public class Request : IRequest<Response>
    {

    }

    public class Response
    {
        public int Count { get; set; }
        public List<CategoryDto> Categories { get; set; } = new();

        public class CategoryDto
        {
            public Guid Id { get; set; }
            public int Number { get; set; }
            public string Name { get; set; }
            public int NumberOfProducts { get; set; }
            public string Description { get; set; }

            public static Expression<Func<Domain.Entities.Category, CategoryDto>> Selector() => c => new()
            {
                Id = c.Id,
                Number = 1,
                Name = c.Name,
                NumberOfProducts = 2,
                Description = c.Description
            };
        }
    }
}