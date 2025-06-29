using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Trendo.Domain.Specifications;

public class SpecificationEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
    {
        if (spec == null)
            throw new ArgumentNullException(nameof(spec));

        IQueryable<T> query = inputQuery;

      
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }

        
        if (spec.Includes != null && spec.Includes.Any())
        {
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
        }

       
        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy);
        }
        else if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending);
        }

        if (spec.IsPagingEnabled)
        {
            var skip = spec.Skip;
            var take = spec.Take ?? int.MaxValue;

            if (skip > 0)
                query = query.Skip(skip);

            if (take > 0)
                query = query.Take(take);
        }

        return query;
    }
}