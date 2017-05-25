namespace Springboard365.Xrm.Core.Test
{
    using Microsoft.Xrm.Sdk;
    using Moq;
    using Springboard365.Core;

    public class CrmFieldNameHelperSpecificationFixture
    {
        public CrmFieldNameHelper UnderTest { get; private set; }

        public Mock<IAttributeUtilities> AttributeUtilities { get; private set; }

        public void PerformTestSetup()
        {
            SetupAttributeUtilities();
            UnderTest = new CrmFieldNameHelper(AttributeUtilities.Object);
        }

        private void SetupAttributeUtilities()
        {
            AttributeUtilities = new Mock<IAttributeUtilities>();
            AttributeUtilities
                .Setup(utilities => utilities.GetAttributeFor<AttributeLogicalNameAttribute, DummyEntity>(type => type.FirstName))
                .Returns(new AttributeLogicalNameAttribute("firstname"));
        }
    }
}