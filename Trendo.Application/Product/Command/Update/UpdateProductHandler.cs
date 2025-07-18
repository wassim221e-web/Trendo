using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;

namespace Trendo.Application.Product.Command.Update;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand.Request, UpdateProductCommand.Response>
{
    private readonly IRepository<Domain.Entities.Product> _repository;

    public UpdateProductHandler(IRepository<Domain.Entities.Product> repository)
    {
        _repository = repository;
    }

    public async Task<UpdateProductCommand.Response> Handle(UpdateProductCommand.Request request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.Query()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product == null)
        {
            return new UpdateProductCommand.Response
            {
                Success = false,
                Message = "المنتج غير موجود"
            };
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.ImageUrl = request.ImageUrl;
        product.Price = request.Price;
        product.CategoryId = request.CategoryId;

        await _repository.SaveChangesAsync();

        return new UpdateProductCommand.Response
        {
            Success = true,
            Message = "تم تحديث المنتج بنجاح"
        };
    }
}
