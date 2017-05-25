namespace Springboard365.Xrm.Core
{
    using System;
    using System.IO;
    using System.Linq.Expressions;
    using Springboard365.Core;
    using Microsoft.Xrm.Sdk;

    public class CrmFieldNameHelper : ICrmFieldNameHelper
    {
        private readonly IAttributeUtilities attributeUtilities;

        public CrmFieldNameHelper(IAttributeUtilities attributeUtilities)
        {
            this.attributeUtilities = attributeUtilities;
        }

        public string GetCrmFieldName<TEntity>(Expression<Func<TEntity, object>> toResolve)
            where TEntity : Entity
        {
            var attributeOnField = attributeUtilities.GetAttributeFor<AttributeLogicalNameAttribute, TEntity>(toResolve);
            if (attributeOnField == null)
            {
                throw new InvalidDataException(GetMissingCrmLogicalNameErrorMessage(toResolve));
            }

            return attributeOnField.LogicalName;
        }

        private static string GetMissingCrmLogicalNameErrorMessage<TEntity>(Expression<Func<TEntity, object>> toResolve)
        {
            var memberExpression = toResolve.Body as MemberExpression;
            var memberName = "unknown member";
            if (memberExpression != null)
            {
                memberName = memberExpression.Member.Name;
            }

            return string.Format("No logical crm name attrribute found for : {0}", memberName);
        }
    }
}