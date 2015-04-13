namespace DSmall.DynamicsCrm.Core
{
    using System;
    using System.Linq.Expressions;
    using Microsoft.Xrm.Sdk;

    /// <summary>The crm field name helper interface.</summary>
    public interface ICrmFieldNameHelper
    {
        /// <summary> The get crm field name. </summary>
        /// <param name="toResolve"> The to resolve. </param>
        /// <typeparam name="TEntity"> Type of Entity to target. </typeparam>
        /// <returns> The <see cref="string"/>. </returns>
        string GetCrmFieldName<TEntity>(Expression<Func<TEntity, object>> toResolve)
            where TEntity : Entity;
    }
}