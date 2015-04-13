namespace DSmall.DynamicsCrm.Core
{
    using System.IO;
    using System.Linq;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Metadata;

    /// <summary>The state retriever.</summary>
    public class StateRetriever : IStateRetriever
    {
        private const string StatusCodeFieldName = "statuscode";
        private readonly IOrganizationService organizationService;
        
        /// <summary>Initialises a new instance of the <see cref="StateRetriever"/> class.</summary>
        /// <param name="organizationService">The organization service.</param>
        public StateRetriever(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        /// <summary>The get state.</summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="entityName">The entity name.</param>
        /// <returns>The <see cref="OptionSetValue"/>.</returns>
        public OptionSetValue GetStateCodeFromStatusCode(int statusCode, string entityName)
        {
            var attributeRequest = new RetrieveAttributeRequest
            {
                EntityLogicalName = entityName,
                LogicalName = StatusCodeFieldName,
                RetrieveAsIfPublished = true
            };
            var attributeResponse = (RetrieveAttributeResponse)organizationService.Execute(attributeRequest);
            var statusAttributeMetadata = (StatusAttributeMetadata)attributeResponse.AttributeMetadata;

            var statusOptionMetadata = (StatusOptionMetadata)statusAttributeMetadata.OptionSet.Options
                                                                .Single(metadata => metadata.Value == statusCode);

            var state = statusOptionMetadata.State;
            if (state == null)
            {
                throw new InvalidDataException("State is null");
            }

            return new OptionSetValue((int)state);
        }
    }
}