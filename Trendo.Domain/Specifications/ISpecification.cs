using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Trendo.Domain.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        Expression<Func<T, object>>? OrderBy { get; }

        Expression<Func<T, object>>? OrderByDescending { get; }

        int? Take { get; }

        int Skip { get; }

        bool IsPagingEnabled { get; }
    }
}