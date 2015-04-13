namespace DSmall.DynamicsCrm.Core
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The entity validator interface.</summary>
    public interface IEntityValidator
    {
        /// <summary>The get valid crm target entity.</summary>
        /// <param name="pluginExecutionContext">The plugin context.</param>
        /// <param name="imageType">The image type.</param>
        /// <typeparam name="TEntityType"> The entity type.</typeparam>
        /// <returns>The <see cref="TEntityType"/>.</returns>
        TEntityType GetValidCrmTargetEntity<TEntityType>(IPluginExecutionContext pluginExecutionContext, EntityImageType imageType)
            where TEntityType : Entity;
    }
}