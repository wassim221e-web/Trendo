
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MediatR;
using Trendo.Domain.Entities;

namespace Trendo.Application.Product.Queries.GetAll
{
    public class GetAllProductsQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public int Count { get; set; }
            public List<ProductRes> Products { get; set; } = new();

            public class ProductRes
            {
                public Guid Id { get; set; }
                public int Number { get; set; }
                public string Name { get; set; }
                public string ImageUrl { get; set; }
                public string Description { get; set; }
                public double Price { get; set; }
                public Guid CategoryId { get; set; }
                public string Category { get; set; } = null!;
                public int OrderCount { get; set; }

                public static Expression<Func<Domain.Entities.Product, ProductRes>> Selector() => e => new ProductRes
                {
                    Id = e.Id,
                    Number = e.Number,
                    Name = e.Name,
                    ImageUrl = e.ImageUrl,
                    Description = e.Description,
                    Price = e.Price,
                    CategoryId = e.CategoryId,
                    Category = e.Category.Name,
                    OrderCount = e.Orders.Count
                };
            }
        }
    }
}