namespace DSmall.DynamicsCrm.Core
{
    using System;
    using System.IO;
    using System.Linq.Expressions;
    using DSmall.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary> The crm field name helper. </summary>
    public class CrmFieldNameHelper : ICrmFieldNameHelper
    {
        private readonly IAttributeUtilities attributeUtilities;

        /// <summary> Initialises a new instance of the <see cref="CrmFieldNameHelper" /> class. </summary>
        /// <param name="attributeUtilities"> The attribute utilities. </param>
        public CrmFieldNameHelper(IAttributeUtilities attributeUtilities)
        {
            this.attributeUtilities = attributeUtilities;
        }

        /// <summary> The get crm field name. </summary>
        /// <param name="toResolve"> The to resolve. </param>
        /// <typeparam name="TEntity"> Type of Entity to target. </typeparam>
        /// <returns> The <see cref="string"/>. </returns>
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