namespace DSmall.DynamicsCrm.Core
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The state retriever interface.</summary>
    public interface IStateRetriever
    {
        /// <summary>The get state.</summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="entityName">The entity name.</param>
        /// <returns>The <see cref="OptionSetValue"/>.</returns>
        OptionSetValue GetStateCodeFromStatusCode(int statusCode, string entityName);
    }
}