namespace DSmall.DynamicsCrm.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The state retriever specifications.</summary>
    [TestFixture]
    public class StateRetrieverSpecifications : SpecificationBase
    {
        private StateRetrieverSpecificationFixture testFixture;

        private OptionSetValue result;

        /// <summary>The should return correct state code.</summary>
        [Test]
        public void ShouldReturnCorrectStateCode()
        {
            Assert.AreEqual(result.Value, testFixture.StateCode);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = testFixture.UnderTest.GetStateCodeFromStatusCode(testFixture.StatusCode, testFixture.EntityName);
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();

            testFixture = new StateRetrieverSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}
