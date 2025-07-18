using MediatR;
using Trendo.Application.Catogery.Queries.GetAll;

namespace Trendo.Application.Catogery.Command.Add;

public class AddCategoryCommand
{
    public class Request:IRequest<GetAllCategoriesQuery.Response.CategoryDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
