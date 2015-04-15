namespace DSmall.DynamicsCrm.Core.UnitTest
{
    using DSmall.Core;
    using Microsoft.Xrm.Sdk;
    using Moq;

    /// <summary>The crm field name helper specification fixture.</summary>
    public class CrmFieldNameHelperSpecificationFixture
    {
        /// <summary>Gets the under test.</summary>
        public CrmFieldNameHelper UnderTest { get; private set; }

        /// <summary>Gets the attribute utilities.</summary>
        public Mock<IAttributeUtilities> AttributeUtilities { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            SetupAttributeUtilities();
            UnderTest = new CrmFieldNameHelper(AttributeUtilities.Object);
        }

        private void SetupAttributeUtilities()
        {
            AttributeUtilities = new Mock<IAttributeUtilities>();
            AttributeUtilities
                .Setup(utilities => utilities.GetAttributeFor<AttributeLogicalNameAttribute, DummyEntity>(type => type.CustomerReference))
                .Returns(new AttributeLogicalNameAttribute("customerreference"));
        }
    }
}
