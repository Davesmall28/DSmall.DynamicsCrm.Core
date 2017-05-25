namespace Springboard365.Xrm.Core
{
    using System;
    using System.Linq.Expressions;
    using Microsoft.Xrm.Sdk;

    public interface ICrmFieldNameHelper
    {
        string GetCrmFieldName<TEntity>(Expression<Func<TEntity, object>> toResolve)
            where TEntity : Entity;
    }
}