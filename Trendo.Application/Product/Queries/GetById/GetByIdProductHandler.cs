using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;

namespace Trendo.Application.Product.Queries.GetById;

    public class GetByIdProductHandler : IRequestHandler<GetByIdProductQuery.Request, GetByIdProductQuery.Response>
    {
        private readonly IRepository<Domain.Entities.Product> _repository;

        public GetByIdProductHandler(IRepository<Domain.Entities.Product> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdProductQuery.Response> Handle(GetByIdProductQuery.Request request, CancellationToken cancellationToken)
        {
            var product = await _repository.Query()
                .Include(e=>e.Orders)
                .Include(e=>e.Category)
                .Where(p => p.Id == request.Id)
                .Select(GetByIdProductQuery.Response.Selector())
                .FirstOrDefaultAsync(cancellationToken);

            return product!;
        }
    }