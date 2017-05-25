namespace Springboard365.Xrm.Core.Test
{
    using System.Collections.Generic;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Metadata;
    using Moq;

    public class StateRetrieverSpecificationFixture
    {
        public IStateRetriever UnderTest { get; set; }

        public Mock<IOrganizationService> OrganizationService { get; set; }

        public string EntityName { get; set; }

        public int StatusCode { get; set; }

        public int StateCode { get; set; }

        public void PerformTestSetup()
        {
            StateCode = 1;
            StatusCode = 1;
            EntityName = "contact";

            SetupOrganizationService();

            UnderTest = new StateRetriever(OrganizationService.Object);
        }

        private void SetupOrganizationService()
        {
            OrganizationService = new Mock<IOrganizationService>();
            OrganizationService.Setup(service => service.Execute(It.IsAny<RetrieveAttributeRequest>()))
                .Returns(GetDummyRetrieveAttributeResponse);
        }

        private RetrieveAttributeResponse GetDummyRetrieveAttributeResponse()
        {
            return new RetrieveAttributeResponse
            {
                Results = new ParameterCollection
                {
                    new KeyValuePair<string, object>("AttributeMetadata", GetDummyStatusAttributeMetadata()),
                }
            };
        }

        private StatusAttributeMetadata GetDummyStatusAttributeMetadata()
        {
            var optionMetadataList = new List<OptionMetadata>
            {
                new StatusOptionMetadata(StatusCode, StateCode)
            };

            return new StatusAttributeMetadata
            {
                OptionSet = new OptionSetMetadata(new OptionMetadataCollection(optionMetadataList))
            };
        }
    }
}