using MediatR;
using Trendo.Application.Catogery.Queries.GetAll;

namespace Trendo.Application.Catogery.Command.Update;

public class UpdateCategoryCommand
{
    public class Request:IRequest<GetAllCategoriesQuery.Response.CategoryDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}