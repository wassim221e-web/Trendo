using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Trendo.Domain.Specifications;

public abstract class BaseSpecification<T> : ISpecification<T>
{
    private bool _isPagingEnabled;

    protected BaseSpecification()
    {
        Includes = new List<Expression<Func<T, object>>>();
    }

    protected BaseSpecification(Expression<Func<T, bool>> criteria) : this()
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>>? Criteria { get; private set; }

    public List<Expression<Func<T, object>>> Includes { get; }

    public Expression<Func<T, object>>? OrderBy { get; private set; }

    public Expression<Func<T, object>>? OrderByDescending { get; private set; }

    public int? Take { get; private set; }

    public int Skip { get; private set; }

    public bool IsPagingEnabled => _isPagingEnabled;

  
    protected void AddInclude(Expression<Func<T, object>> includeExpression)
        => Includes.Add(includeExpression);

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        => OrderBy = orderByExpression;

  
    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        => OrderByDescending = orderByDescExpression;

    
    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        _isPagingEnabled = true;
    }

    
    protected void SetCriteria(Expression<Func<T, bool>> criteria)
        => Criteria = criteria;
}