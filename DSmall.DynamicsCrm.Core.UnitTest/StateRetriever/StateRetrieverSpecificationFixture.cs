namespace DSmall.DynamicsCrm.Core.UnitTest
{
    using System.Collections.Generic;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Metadata;
    using Moq;

    /// <summary>The state retriever specification fixture.</summary>
    public class StateRetrieverSpecificationFixture
    {
        /// <summary>Gets or sets the under test.</summary>
        public IStateRetriever UnderTest { get; set; }

        /// <summary>Gets or sets the organization service.</summary>
        public Mock<IOrganizationService> OrganizationService { get; set; }

        /// <summary>Gets or sets the entity name.</summary>
        public string EntityName { get; set; }

        /// <summary>Gets or sets the status code.</summary>
        public int StatusCode { get; set; }

        /// <summary>Gets or sets the state code.</summary>
        public int StateCode { get; set; }

        /// <summary>The perform test setup.</summary>
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
