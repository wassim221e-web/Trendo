using MediatR;
using Trendo.Application.File.Interface;
using Trendo.Domain.Repository;

namespace Trendo.Application.Product.Command.Add;

public class AddProductHandler : IRequestHandler<AddOrUpdateProductCommand.Request, AddOrUpdateProductCommand.Response>
{
    private readonly IRepository<Domain.Entities.Product> _repository;
    private readonly IFileService _fileService;

    public AddProductHandler(IRepository<Domain.Entities.Product> repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<AddOrUpdateProductCommand.Response> Handle(AddOrUpdateProductCommand.Request request,
        CancellationToken cancellationToken)
    {

        var imagePath = await _fileService.Upload(request.Image, "upload");
        var product = new Domain.Entities.Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.CategoryId
        };
        product.ImageUrl = imagePath;
        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();


        return new AddOrUpdateProductCommand.Response
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            Price = product.Price,
            CategoryId = product.CategoryId
        };
    }
}