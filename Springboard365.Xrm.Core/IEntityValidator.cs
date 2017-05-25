namespace Springboard365.Xrm.Core
{
    using Microsoft.Xrm.Sdk;

    public interface IEntityValidator
    {
        TEntityType GetValidCrmTargetEntity<TEntityType>(IPluginExecutionContext pluginExecutionContext, EntityImageType imageType)
            where TEntityType : Entity;
    }
}