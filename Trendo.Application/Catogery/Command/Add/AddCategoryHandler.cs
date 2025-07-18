using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Application.Catogery.Queries.GetAll;
using Trendo.Domain.Entities;
using Trendo.Domain.Repository;

namespace Trendo.Application.Catogery.Command.Add;
    
    public class AddCategoryHandler:IRequestHandler<AddCategoryCommand.Request,GetAllCategoriesQuery.Response.CategoryDto>
    {
        private readonly IRepository<Category> _repository;

        public AddCategoryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetAllCategoriesQuery.Response.CategoryDto> Handle(AddCategoryCommand.Request request, CancellationToken cancellationToken)
        {
            var category = new Domain.Entities.Category(request.Name, request.Description);
            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();
            return await _repository.Query()
                .Where(c=>c.Id==category.Id).Select(GetAllCategoriesQuery.Response.CategoryDto.Selector())
                .FirstAsync(cancellationToken);
        }
    }
