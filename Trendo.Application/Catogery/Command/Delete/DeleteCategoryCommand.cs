using MediatR;

namespace Trendo.Application.Catogery.Command.Delete;

public class DeleteCategoryCommand
{
    public class Request:IRequest
    {
        public Guid Id { get; set; }
    }

}