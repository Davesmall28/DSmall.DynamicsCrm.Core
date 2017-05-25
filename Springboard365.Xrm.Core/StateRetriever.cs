namespace Springboard365.Xrm.Core
{
    using System.IO;
    using System.Linq;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Metadata;

    public class StateRetriever : IStateRetriever
    {
        private const string StatusCodeFieldName = "statuscode";
        private readonly IOrganizationService organizationService;

        public StateRetriever(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

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